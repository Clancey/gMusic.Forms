using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace gMusic.Droid
{
    [Activity(Label = "gMusic", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static MainActivity Shared { get; set;}
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Shared = this;
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
			Android.NGraphicsExtensions.Scale = Resources.DisplayMetrics.Density;
			base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
			ApplyFonts ();
            LoadApplication(new App());
        }

		void ApplyFonts()
		{
			Styles.Fonts.NormalFontName = "Heebo-Regular.ttf#Heebo-Regular";
			Styles.Fonts.ThinFontName = "Heebo-Thin.ttf#Heebo-Thin";
			Styles.Fonts.IconFontName = "gMusicIcons.ttf#gMusicIcons-Regular";
		}
    }
}