﻿using System;
using System.Collections.Generic;
using System.IO;
using gMusic.Managers;
using SimpleDatabase;
using SQLite;
using gMusic.Models;
using System.Threading.Tasks;
using Localizations;
using System.Linq;

namespace gMusic.Data
{
    internal class Database : SimpleDatabaseConnection
    {
        public static Database Main { get; set; } = setupDb();
        static Database setupDb(bool shouldDeleteOnFail = true)
        {
            try
            {
                return new Database(new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.FullMutex | SQLiteOpenFlags.Create, true));
            }
            catch (Exception ex)
            {
                if (shouldDeleteOnFail)
                {
                    LogManager.Shared.Report(ex);
                    File.Delete(dbPath);
                }
                else
                    throw ex;
            }

            return setupDb(false);
        }


        static string dbPath => Path.Combine(Locations.LibDir, "db.db");
        SQLiteConnection connection;
        public Database(SQLiteConnection connection) : base(connection)
        {
            this.connection = connection;
            connection.ExecuteScalar<string>("PRAGMA journal_mode=WAL");

            CreateTables(
                typeof(Album),
                typeof(AlbumArtwork),
                typeof(AlbumIds),
                typeof(Artist),
                typeof(ArtistArtwork),
                typeof(ArtistIds),
                typeof(Genre),
                typeof(Song),
                typeof(Track),
                typeof(Playlist),
                typeof(PlaylistSong),
                typeof(RadioStation),
                typeof(RadioStationSong),
                typeof(RadioStationSeed),
                typeof(RadioStationArtwork),
                typeof(ApiModel),
                //typeof (PlaybackManager.SongsOrdered),
                typeof(EqualizerPreset),
                typeof(EqualizerPresetValue),
                //Temp stuff
                typeof(TempAlbum),
                typeof(TempArtist),
                typeof(TempSong),
                typeof(TempTrack),
                typeof(TempGenre),
                typeof(TempPlaylistEntry),
                typeof(TempAlbumArtwork),
                typeof(TempAlbumIds),
                typeof(TempArtistArtwork),
                typeof(TempRadioStationSong),
                typeof(TempArtistIds),
                typeof(TempPlaylist),
                typeof(TempPlaylistSong),
                // Offline Stuff
                typeof(SongOfflineClass),
                typeof(ArtistOfflineClass),
                typeof(PlaylistOfflineClass),
                typeof(GenreOfflineClass),
                typeof(AlbumOfflineClass)
                );

        }

        public void ResetDatabase()
        {
            DropAndCreateTable<TempPlaylistSong>();
            DropAndCreateTable<TempPlaylist>();
            DropAndCreateTable<TempArtistIds>();
            DropAndCreateTable<TempRadioStationSong>();
            DropAndCreateTable<TempArtistArtwork>();
            DropAndCreateTable<TempAlbumIds>();
            DropAndCreateTable<TempAlbumArtwork>();
            DropAndCreateTable<TempPlaylistEntry>();
            DropAndCreateTable<TempGenre>();
            DropAndCreateTable<TempTrack>();
            DropAndCreateTable<TempSong>();
            DropAndCreateTable<TempArtist>();
            DropAndCreateTable<TempAlbum>();
            //DropAndCreateTable<PlaybackManager.SongsOrdered> ();
            DropAndCreateTable<RadioStationArtwork>();
            DropAndCreateTable<RadioStationSeed>();
            DropAndCreateTable<RadioStationSong>();
            DropAndCreateTable<RadioStation>();
            DropAndCreateTable<PlaylistSong>();
            DropAndCreateTable<Playlist>();
            DropAndCreateTable<Track>();
            DropAndCreateTable<Song>();
            DropAndCreateTable<Genre>();
            DropAndCreateTable<ArtistIds>();
            DropAndCreateTable<ArtistArtwork>();
            DropAndCreateTable<Artist>();
            DropAndCreateTable<AlbumIds>();
            DropAndCreateTable<AlbumArtwork>();
            DropAndCreateTable<Album>();

        }

        public void DropTable<T>()
        {
            var map = connection.GetMapping(typeof(T));
            Execute($"drop table if exists {map.TableName}");
        }
        public void DropAndCreateTable<T>()
        {
            DropTable<T>();
            connection.CreateTable<T>();
        }

        public T GetObject<T, T1>(object id) where T1 : T, new() where T : new()
        {
            var obj = GetObject<T>(id);
            return EqualityComparer<T>.Default.Equals(obj, default(T)) ? GetObject<T1>(id) : obj;
        }

        public GroupInfo CreateGroupInfo(Playlist playlist) => new GroupInfo
        {
            Filter = $"PlaylistId = \"{playlist.Id}\"",
            OrderBy = "SOrder"
        };

        public GroupInfo CreateGroupInfo(AutoPlaylist playlist, bool offlineOnly = false)
        {

            var gi = new GroupInfo { Filter = playlist.WhereClause, OrderBy = playlist.OrderByClause, Limit = playlist.Limit };
            if (offlineOnly && Settings.ShowOfflineOnly)
            {
                gi.Filter = gi.Filter + (string.IsNullOrEmpty(gi.Filter) ? " " : " and ") + "OfflineCount > 0";
            }
            return gi;
        }



        public async Task<SearchResults> Search(string searchString)
        {
            var results = new SearchResults();
            if (string.IsNullOrWhiteSpace(searchString))
                return results;
            var songs = await QueryAsync<Song>("select * from song where " +
                                                        string.Format("Name like ('%{0}%') or Artist  like ('%{0}%')" + ((Settings.ShowOfflineOnly) ? " and OfflineCount > 0" : ""), searchString));
            if (songs.Count > 0)
                results.Add(Strings.Songs, songs.OfType<MediaItemBase>().ToList());


            var artists = await Database.Main.QueryAsync<Artist>("select * from Artist where " +
                                                        string.Format("Name like ('%{0}%')" + ((Settings.ShowOfflineOnly) ? " and OfflineCount > 0" : ""), searchString));
            if (artists.Count > 0)
                results.Add(Strings.Artists, artists.OfType<MediaItemBase>().ToList());

            var albums =
                        await Database.Main.QueryAsync<Album>("select * from Album where " +
                                                        string.Format("Name like ('%{0}%')" + ((Settings.ShowOfflineOnly) ? " and OfflineCount > 0" : ""), searchString));

            if (albums.Count > 0)
                results.Add(Strings.Albums, albums.OfType<MediaItemBase>().ToList());

            var playlists =
                    await Database.Main.QueryAsync<Playlist>("select * from Playlist where " +
                                                    string.Format("Name like ('%{0}%')" + ((Settings.ShowOfflineOnly) ? " and OfflineCount > 0" : ""), searchString));

            if (playlists.Count > 0)
                results.Add(Strings.Playlists, playlists.OfType<MediaItemBase>().ToList());

            return results;



        }

    }
}