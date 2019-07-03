using System;
namespace Xamarin.Forms {
	public static class FormsExtension {
		public static string ToHexString (this Xamarin.Forms.Color color, bool includeAlpha = true)
		{
			var red = (int)(color.R * 255);
			var green = (int)(color.G * 255);
			var blue = (int)(color.B * 255);
			var alpha = (int)(color.A * 255);
			var alphaText = includeAlpha ? $"{alpha:X2}" : "";
			var hex = $"#{alphaText}{red:X2}{green:X2}{blue:X2}";

			return hex;
		}

		public static T AddGesture<T> (this T view, GestureRecognizer gesture) where T : View
		{
			view.GestureRecognizers.Add (gesture);
			return view;
		}
		public static T AddTapGesture<T> (this T view, Action<T> onTap) where T : View
			 => view.AddGesture (new TapGestureRecognizer {
				 Command = new Command (() => onTap (view))
			 });

	}
}
