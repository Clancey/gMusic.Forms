using System;
using System.Threading.Tasks;
using Comet;
using gMusic.Data;
using gMusic.Models;
using gMusic.ViewModels;

namespace gMusic.CometViews
{
    public class ArtistAlbumsView : View
    {
        [Environment]
        readonly Artist artist;
        [Body]
        View body()
        {
            var group = Database.Main.GetGroupInfo<Album>().Clone();
            group.Filter = "ArtistId = @ArtistId";
            group.Params["@ArtistId"] = artist.Id;

            return new ListView<Album>
            {
                Count = () => Database.Main.GetObjectCount<Album>(group),
                ItemFor = (row) => Database.Main.GetObjectByIndex<Album>(row, group),
                ViewFor = (album) => new MediaItemView().SetEnvironment("item", album).Frame(alignment: Alignment.Leading).Padding(5),
            }.OnSelected((a)=>
            {
                gMusic.RootPage.Shared.NavigateToPage(new gMusic.Views.PlaylistSongPage());
            });
        }
    }
}
