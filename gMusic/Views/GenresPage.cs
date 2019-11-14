using System;
using gMusic.Data;
using gMusic.Models;
using gMusic.ViewModels;
using Localizations;
using SimpleDatabase;

namespace gMusic.Views {
	public class GenresPage : SimpleDatabaseListViewPage
    {
		public GenresPage ()
		{
			this.ViewModel = new SimpleDatabaseViewModel<Genre> {
				Title = Strings.Genres
			};
		}

        protected async override void ItemSelected(object item)
        {
            var genre = item as Genre;
            if (genre == null)
                return;

            var groupInfo = new GroupInfo()
            {
                Filter = "Id in (select distinct ArtistId from song where Genre = @Genre)",
                Params = { { "@Genre", genre.Id } },
                OrderBy = "NameNorm"
            };
            var offlineGroupInfo2 = groupInfo.Clone();
            offlineGroupInfo2.Filter = offlineGroupInfo2.Filter + " and OfflineCount > 0";

            var artistCount =
                Database.Main.GetDistinctObjectCount<Artist>(Settings.ShowOfflineOnly ? offlineGroupInfo2 : groupInfo, "Id");
            if (artistCount == 1)
            {
                groupInfo = new GroupInfo() { Filter = "Genre = @Genre", Params = { { "@Genre", genre.Id } } };
                offlineGroupInfo2 = groupInfo.Clone();
                offlineGroupInfo2.Filter = offlineGroupInfo2.Filter + " and IsLocal = 1";

                var song = Database.Main.ObjectForRow<Song>(Settings.ShowOfflineOnly ? offlineGroupInfo2 : groupInfo, 0, 0);
                var artist = Database.Main.GetObject<Artist>(song.ArtistId);
                if (artist != null)
                {
                    if (artist.AlbumCount > 1)
                        await this.Navigation.PushAsync(new ArtistDetailsPage(artist));
                    else
                    {
                        var albumId = (await Database.Main.TablesAsync<Song>().Where(x => x.ArtistId == artist.Id).FirstAsync())?.AlbumId;
                        var album = Database.Main.GetObject<Album>(albumId);
                        await this.Navigation.PushAsync(new AlbumDetailsPage(album));
                    }
                    return;
                }
            }
            
            groupInfo = new GroupInfo()
            {
                From = "Artist",
                Filter = "Id in (select distinct ArtistId from song where genre = @Genre)",
                Params = { { "@Genre", genre.Id } },
                OrderBy = "NameNorm"
            };
            await this.Navigation.PushAsync(new ArtistsPage()
            {
                GroupInfo = groupInfo,
                Title = genre.Name,
            });
            

        }
    }
}
