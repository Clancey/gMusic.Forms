using System;
using FFImageLoading.Svg.Forms;
using Xamarin.Forms;

namespace gMusic
{
    public static class Images
    {
        public static int AlbumArtScreenSize { get; set; }

        public static SvgImageSource DefaultAlbumArt = SvgImageSource.FromResource("gMusic.Resources.Svg.icon.svg");

        public static SvgImageSource PlayButton = SvgImageSource.FromResource("gMusic.Resources.Svg.playButtonBordered.svg");

        public static class Menu
        {
			public static NGraphicsSVGImageSource SearchIcon = new NGraphicsSVGImageSource() { SvgName = "search.svg", MaxSize = 28 , TintColor = Color.White};
			public static NGraphicsSVGImageSource ArtistIcon = new NGraphicsSVGImageSource () { SvgName = "artist.svg", MaxSize = 28, TintColor = Color.White };
			public static NGraphicsSVGImageSource AlbumIcon = new NGraphicsSVGImageSource () { SvgName = "album.svg", MaxSize = 28, TintColor = Color.White };
			public static NGraphicsSVGImageSource GenreIcon = new NGraphicsSVGImageSource () { SvgName = "genres.svg", MaxSize = 28, TintColor = Color.White };
			public static NGraphicsSVGImageSource SongsIcon = new NGraphicsSVGImageSource () { SvgName = "songs.svg", MaxSize = 28, TintColor = Color.White };
			public static NGraphicsSVGImageSource PlaylistIcon = new NGraphicsSVGImageSource () { SvgName = "playlists.svg", MaxSize = 28, TintColor = Color.White };
			public static NGraphicsSVGImageSource SettingsIcon = new NGraphicsSVGImageSource () { SvgName = "settings.svg", MaxSize = 28, TintColor = Color.White };
		}
    }
}
