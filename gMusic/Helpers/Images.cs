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
			public static FontImageSource ThumbsDown = IconFont.CreateFont (IconFont.IconThumbsDown, Color.White, 25);
			public static FontImageSource Previous = IconFont.CreateFont (IconFont.IconPrevious, Color.White, 25);
			public static FontImageSource Play = IconFont.CreateFont (IconFont.IconPlayButton, Color.White, 30);
			public static FontImageSource Pause = IconFont.CreateFont (IconFont.IconPauseButton, Color.White, 30);
			public static FontImageSource Next = IconFont.CreateFont (IconFont.IconNext, Color.White, 25);
			public static FontImageSource ThumbsUp = IconFont.CreateFont (IconFont.IconThumbsUp, Color.White, 25);


			public static FontImageSource PlayBordered => IconFont.CreateFont (IconFont.IconPlayButtonBordered, Styles.Styles.CurrentStyle.AccentColor, 36);
			public static FontImageSource PauseBordered => IconFont.CreateFont (IconFont.IconPauseButtonBordered, Styles.Styles.CurrentStyle.AccentColor, 36);
		}
    }
}
