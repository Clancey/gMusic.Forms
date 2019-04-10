using System;

using Xamarin.Forms;

namespace gMusic.Styles {
	public class Fonts {
		public static string NormalFontName { get; set; } = "Bodoni 72";
		public static Font NormalFont (double size)
		{
			return Font.OfSize (NormalFontName, size);
		}

		public static string ThinFontName { get; set; } = "Bodoni 72";

		public static Font ThinFont (double size)
		{
			return Font.OfSize (ThinFontName, size) ;
		}
	}
}

