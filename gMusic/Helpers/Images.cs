using System;
using FFImageLoading.Svg.Forms;
using gMusic.Styles;
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
			public static ImageSource SearchIcon = IconFont.CreateFont (IconFont.IconSearch, Color.White, 20);
			public static ImageSource ArtistIcon = IconFont.CreateFont (IconFont.IconArtist, Color.White);
			public static ImageSource AlbumIcon = IconFont.CreateFont (IconFont.IconAlbum, Color.White);
			public static ImageSource GenreIcon = IconFont.CreateFont (IconFont.IconGenres, Color.White);
			public static ImageSource SongsIcon = IconFont.CreateFont (IconFont.IconSongs, Color.White);
			public static ImageSource PlaylistIcon = IconFont.CreateFont (IconFont.IconPlaylists, Color.White);
			public static ImageSource SettingsIcon = IconFont.CreateFont (IconFont.IconSettings, Color.White);
		}

		public static class NowPlayingScreen {
			public static ImageSource ThumbsDown = IconFont.CreateFont (IconFont.IconThumbsDown, Color.White, 28);
			public static ImageSource Previous = IconFont.CreateFont (IconFont.IconPrevious, Color.White, 24);
			public static ImageSource Play = IconFont.CreateFont (IconFont.IconPlayButton, Color.White, 36);
			public static ImageSource Pause = IconFont.CreateFont (IconFont.IconPauseButton, Color.White, 36);
			public static ImageSource Next = IconFont.CreateFont (IconFont.IconNext, Color.White, 24);
			public static ImageSource ThumbsUp = IconFont.CreateFont (IconFont.IconThumbsUp, Color.White, 28);


			public static ImageSource PlayBordered => IconFont.CreateFont (IconFont.IconPlayButtonBordered, Styles.Styles.CurrentStyle.AccentColor, 36);
			public static ImageSource PauseBordered => IconFont.CreateFont (IconFont.IconPauseButtonBordered, Styles.Styles.CurrentStyle.AccentColor, 36);
		}
    }
}
