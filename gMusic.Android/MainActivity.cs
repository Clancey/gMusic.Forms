using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using gMusic.Api.GoogleMusic;
using FFImageLoading.Forms.Platform;

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
			SetupNative ();

			LoadApplication (new App());
        }

		void SetupNative()
		{
			CachedImageRenderer.Init(null);
			GoogleMusicApi.ShowAuthenticator = (authenticator) => {
				try {
					var i = new global::Android.Content.Intent (this, typeof (WebAuthenticatorActivity));
					var state = new WebAuthenticatorActivity.State {
						Authenticator = authenticator,
					};
					i.SetFlags (Android.Content.ActivityFlags.NewTask);
					i.PutExtra ("StateKey", WebAuthenticatorActivity.StateRepo.Add (state));
					this.StartActivity (i);
				} catch (Exception ex) {
					authenticator.OnError (ex.Message);
				}
			};
			WebAuthenticatorActivity.UserAgent = "Mozilla/5.0(iPhone;U;CPUiPhoneOS4_0likeMacOSX;en-us)AppleWebKit/532.9(KHTML,likeGecko)Version/4.0.5Mobile/8A293Safari/6531.22.7";
			ApplyFonts ();
		}

		void ApplyFonts()
		{
			Styles.Fonts.NormalFontName = "Heebo-Regular.ttf#Heebo-Regular";
			Styles.Fonts.ThinFontName = "Heebo-Thin.ttf#Heebo-Thin";
			Styles.Fonts.IconFontName = "gMusicIcons.ttf#gMusicIcons-Regular";
		}
    }
}