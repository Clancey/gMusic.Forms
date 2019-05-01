using System;
using gMusic.Styles;
using Xamarin.Forms;

namespace gMusic {
	static class IconFont {

		public static FontImageSource CreateFont (string glyph, Color tintColor, double size = 28) =>
			new FontImageSource { FontFamily = Fonts.IconFontName, Glyph = glyph, Color = tintColor, Size = size };


		public const string IconAirplay = "\u0041";
		public const string IconAlbum = "\u0042";
		public const string IconArtist = "\u0043";
		public const string IconCopy = "\u0044";
		public const string IconClose = "\u0045";
		public const string IconDice = "\u0046";
		public const string IconEdit = "\u0047";
		public const string IconEqualizer = "\u0048";
		public const string IconGenres = "\u0049";
		public const string IconIsOffline = "\u004a";
		public const string IconMenu = "\u004b";
		public const string IconMore = "\u004c";
		public const string IconMoreTall = "\u004d";
		public const string IconMusicalNotes = "\u004e";
		public const string IconNext = "\u004f";
		public const string IconOffline = "\u0050";
		public const string IconPauseButton = "\u0051";
		public const string IconPauseButtonBordered = "\u0052";
		public const string IconSongs = "\u0053";
		public const string IconPlayButton = "\u0054";
		public const string IconPlayButtonBordered = "\u0055";
		public const string IconPlaylists = "\u0056";
		public const string IconPrevious = "\u0057";
		public const string IconRadio = "\u0058";
		public const string IconRepeat = "\u0059";
		public const string IconRepeatOne = "\u005a";
		public const string IconSearch = "\u0061";
		public const string IconSettings = "\u0062";
		public const string IconShare = "\u0063";
		public const string IconShuffle = "\u0064";
		public const string IconThumbsDown = "\u0065";
		public const string IconThumbsUp = "\u0066";
		public const string IconTrash = "\u0067";
		public const string IconTrending = "\u0068";
		public const string IconUndo = "\u0069";
		public const string IconVideoIcon = "\u006a";
	}
}
