using System;
using System.Threading.Tasks;
using Comet;
using gMusic.Models;

namespace gMusic.CometViews
{
    public class MediaItemView : View
    {
        [Environment]
        readonly MediaItemBase item;
        public MediaItemView()
        {
        }
        [Body]
        View body() => new HStack
                {
                    new ArtworkView(item)
                    .Frame(44,44,alignment:Alignment.Leading)
                    .Padding(5),
                    new VStack{
                        new Text(item?.Name),
                        new Text(item?.DetailText)
                    }.FillHorizontal()
                };
    }


    class ArtworkView : View
    {
        //[Environment]
        readonly MediaItemBase item;
        public ArtworkView(Binding<MediaItemBase> item)
        {
            Comet.HotReloadHelper.Register(this, item);
            this.item = item;
        }
        readonly State<string> artworkUrl = "";
        [Body]
        View body()
        {

            GetArtwork(item);
            return new Image(artworkUrl).Frame(44, 44, alignment: Alignment.Leading);
        }
        async Task GetArtwork(MediaItemBase item)
        {
            try
            {
                var urlTask = item.GetArtworkUrl();
                if (!urlTask.IsCompleted)
                {
                    //image.Source = Images.DefaultAlbumArt;
                    //images.ForEach(i => i.IsVisible = false);
                }
                var url = await urlTask;

                artworkUrl.Value = url;
                Console.WriteLine(artworkUrl);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
