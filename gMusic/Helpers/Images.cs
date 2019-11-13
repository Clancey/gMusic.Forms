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

		public static FontImageSource MoreDetails => IconFont.CreateFont (IconFont.IconMore, Color.White);


		public static FontImageSource DiceIcon => IconFont.CreateFont (IconFont.IconDice, Color.White);

		public static class Menu
        {
			public static ImageSource SearchIcon => IconFont.CreateFont (IconFont.IconSearch, Color.White, 20);
			public static ImageSource ArtistIcon => IconFont.CreateFont (IconFont.IconArtist, Color.White);
			public static ImageSource AlbumIcon => IconFont.CreateFont (IconFont.IconAlbum, Color.White);
			public static ImageSource GenreIcon => IconFont.CreateFont (IconFont.IconGenres, Color.White);
			public static ImageSource SongsIcon => IconFont.CreateFont (IconFont.IconSongs, Color.White);
			public static ImageSource PlaylistIcon => IconFont.CreateFont (IconFont.IconPlaylists, Color.White);
			public static ImageSource RadioIcon => IconFont.CreateFont (IconFont.IconRadio, Color.White);
            public static ImageSource EqualizerIcon => IconFont.CreateFont(IconFont.IconEqualizer, Color.White);
            public static ImageSource SettingsIcon => IconFont.CreateFont (IconFont.IconSettings, Color.White);
		}

        public static class NowPlayingScreen {
            public static FontImageSource ThumbsDown => IconFont.CreateFont(IconFont.IconThumbsDown, Color.Black, 25);
            public static FontImageSource Previous => IconFont.CreateFont(IconFont.IconPrevious, Color.Black, 25);
            public static FontImageSource Play => IconFont.CreateFont(IconFont.IconPlayButton, Color.Black, 30);
            public static FontImageSource Pause => IconFont.CreateFont(IconFont.IconPauseButton, Color.Black, 30);
            public static FontImageSource Next => IconFont.CreateFont(IconFont.IconNext, Color.Black, 25);
            public static FontImageSource ThumbsUp => IconFont.CreateFont(IconFont.IconThumbsUp, Color.Black, 25);


            public static FontImageSource PlayBordered => IconFont.CreateFont(IconFont.IconPlayButtonBordered, Styles.Styles.CurrentStyle.AccentColor, 36);
            public static FontImageSource PauseBordered => IconFont.CreateFont(IconFont.IconPauseButtonBordered, Styles.Styles.CurrentStyle.AccentColor, 36);

            public static NGraphicsSVGImageSource SliderThumb = new NGraphicsSVGImageSource {
                SvgName = "gMusic.Resources.Svg.playbackSliderThumb.svg",
                Size = new Size(37, 37),
            };

            public static class NavBar {
                public static FontImageSource CloseButton => IconFont.CreateFont(IconFont.IconClose, Styles.Styles.CurrentStyle.AccentColor, 25);
                public static FontImageSource CurrentPlayistButton => IconFont.CreateFont(IconFont.IconPlaylists, Styles.Styles.CurrentStyle.AccentColor, 30);
            }

            public static class BottomBar {
                public static FontImageSource ShareButton => IconFont.CreateFont(IconFont.IconShare, Color.Black, 18);
                public static FontImageSource ShuffleButton => IconFont.CreateFont(IconFont.IconShuffle, Color.Black, 18);
                public static FontImageSource RepeatButton => IconFont.CreateFont(IconFont.IconRepeat, Color.Black, 18);
                public static FontImageSource MoreButton => IconFont.CreateFont(IconFont.IconMore, Color.Black, 25);
            }
		}

        public static class EqualizerView
        {
            public static FontImageSource RenameButton => IconFont.CreateFont(IconFont.IconEdit, Styles.Styles.CurrentStyle.AccentColor, 18);
            public static FontImageSource DuplicateButton => IconFont.CreateFont(IconFont.IconCopy, Styles.Styles.CurrentStyle.AccentColor, 18);
            public static FontImageSource DeleteButton => IconFont.CreateFont(IconFont.IconTrash, Styles.Styles.CurrentStyle.AccentColor, 18);
            public static FontImageSource ResetButton => IconFont.CreateFont(IconFont.IconUndo, Styles.Styles.CurrentStyle.AccentColor, 18);
        }
    }
}
