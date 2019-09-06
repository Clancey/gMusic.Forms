using System;
using Comet;
using gMusic.Data;
using gMusic.Models;

namespace gMusic.CometViews
{
    public class ArtistSongsView : View
    {
        [Environment]
        readonly Artist artist;
        [Body]
        View body()
        {
            var group = Database.Main.GetGroupInfo<Song>().Clone();
            group.Filter = "ArtistId = @ArtistId";
            group.Params["@ArtistId"] = artist.Id;
            group.From = "Song";

            return new SectionedListView<Song>
            {
                SectionFor = (s) => new Section<Song>
                {
                    Header = new Text("Hi!"),
                    Count = () => {
                        var count = Database.Main.RowsInSection<Song>(group, s);
                        return count;
                     },
                    ItemFor = (row) => Database.Main.ObjectForRow<Song>(group, s, row),
                    ViewFor = (item) => new MediaItemView().SetEnvironment("item", item).Frame(alignment: Alignment.Leading).Padding(5),
                },
                SectionCount = () => {
                    var count = Database.Main.NumberOfSections<Song>(group);
                    return count;
                 },

            };

            return new ListView<Song>
            {
                Count = () => Database.Main.GetObjectCount<Song>(group),
                ItemFor = (row) => Database.Main.GetObjectByIndex<Song>(row, group),
                ViewFor = (album) => new MediaItemView().SetEnvironment("item", album).Frame(alignment: Alignment.Leading).Padding(5),
            }.OnSelected((a) =>
            {
                gMusic.RootPage.Shared.NavigateToPage(new gMusic.Views.PlaylistSongPage());
            });
        }
    }
}
