using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Xamarin.Forms;

namespace gMusic.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init();
            Images.AlbumArtScreenSize = (int)NMath.Max(UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height);
            global::Xamarin.Forms.Forms.Init();
			ApplyStyles ();
			LoadApplication (new App());
			//var font = UIFont.FromName ("SFUIDisplay-Thin", 20).ToFont;

			//UIFont.PreferredBody.PointSize
			//var formsFont = Font
			return base.FinishedLaunching(app, options);
        }
		void ApplyStyles()
		{
			Styles.Style.HeaderFontSize = (int)UIFont.PreferredTitle1.PointSize;
			Styles.Style.MainTextFontSize = (int)UIFont.PreferredSubheadline.PointSize;
			Styles.Style.ButtonFontsize = (int)UIFont.PreferredSubheadline.PointSize;
			Styles.Style.DetailFontSize = (int)UIFont.PreferredCaption1.PointSize;
			Styles.Fonts.NormalFontName = "Heebo-Regular";
			Styles.Fonts.ThinFontName = "Heebo-Thin";
			Styles.Style.ResetAllFonts ();
		}
    }
}
