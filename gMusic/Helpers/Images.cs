using System;
using FFImageLoading.Svg.Forms;
namespace gMusic
{
    public static class Images
    {
        public static int AlbumArtScreenSize {get;set;}

        public static SvgImageSource DefaultAlbumArt = SvgImageSource.FromResource("gMusic.Resources.Svg.icon.svg");

        public static SvgImageSource PlayButton = SvgImageSource.FromResource("gMusic.Resources.Svg.playButtonBordered.svg");
    }
}
