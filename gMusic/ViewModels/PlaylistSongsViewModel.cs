using System;
using System.Collections.Generic;
using gMusic.Data;
using gMusic.Managers;
using gMusic.Models;
using SimpleDatabase;

namespace gMusic.ViewModels {
	public class PlaylistSongsViewModel : SimpleDatabaseViewModel<PlaylistSong> {

		Playlist playlist;

		public Playlist Playlist {
			set {


				Source.GroupInfo = new GroupInfo {
					Filter = "PlaylistId = @playlistId",
					OrderBy = "SOrder",
					Params = {
						["@playlistId"] = value.Id
					}
				};
				playlist = value;
				this.Title = value?.Name;
				//var group = Database.Main.GetGroupInfo<PlaylistSong> ().Clone ();
				//group.Filter = "PlaylistId = @PlaylistId";
				//group.Params ["@PlaylistId"] = value.Id;
				//Title = value.Name;
				//Source.GroupInfo = group;
				//playlist = value;
				///

				//var rowQuery = $"select count(*) from {group.FromString (typeof (PlaylistSong).Name)} where {group.GroupBy} = @GroupByParam {group.FilterString (false)}";
				//var queryInfo = group.ConvertSqlFromNamed (rowQuery, new Dictionary<string, object> { { "@GroupByParam", group.GroupString } });
				//Console.WriteLine (queryInfo.Item1);
			}
			get { return playlist; }
		}

		public virtual async void OnTap (PlaylistSong song)
		{
			await PlaybackManager.Shared.PlayPlaylist (song, Source.GroupInfo,playlist?.Id);
		}
	}
}
