using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using gMusic.iOS.Playback;
using gMusic.Playback;
using ManagedBass;
using UIKit;
using Xamarin.Forms;
using gMusic.Managers;
using Xamarin.Forms.Platform.iOS;
using System.IO;

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
#if DEBUG
            Xamarin.Calabash.Start();
#endif
            global::Xamarin.Forms.Forms.Init();
            NativeInit();
            LoadApplication(new App());
            var result = base.FinishedLaunching(app, options);
            var inset = app.KeyWindow.SafeAreaInsets;
            var thick = new Thickness(inset.Left, inset.Top, inset.Right, inset.Bottom);
            NotificationManager.Shared.ProcInsetAreaChanged(thick);
            app.KeyWindow.TintColor = Styles.Styles.CurrentStyle.AccentColor.ToUIColor();
            return result;
        }

        void NativeInit()
        {
            BassIos.Init();
            Utility.DeviceName = Helpers.Device.Name;
            Utility.IsSimulator = Helpers.Device.IsSim;
            FadePlayer.CreatePlayer = (pd) => pd.IsVideo ? (Player)new AVMediaPlayer() : new BassPlayer();
            ApplyStyles();
            NSNotificationCenter.DefaultCenter.AddObserver((NSString)"UIContentSizeCategoryDidChangeNotification", (n) =>
            {
                ApplyStyles();
            });

            App.InputTextFunc = (x) =>
            {
                var alert = new TextInputAlert(x.title);
                return alert.GetText(GetTopMostViewController());
            };
        }
        void ApplyStyles()
        {
            Styles.Styles.HeaderFontSize = (int)UIFont.PreferredTitle1.PointSize;
            Styles.Styles.MainTextFontSize = (int)UIFont.PreferredSubheadline.PointSize;
            Styles.Styles.ButtonFontsize = (int)UIFont.PreferredSubheadline.PointSize;
            Styles.Styles.DetailFontSize = (int)UIFont.PreferredCaption1.PointSize;
            Styles.Fonts.NormalFontName = "Heebo-Regular";
            Styles.Fonts.ThinFontName = "Heebo-Thin";


            Styles.Styles.ResetAllFonts();
        }
        public override void OnActivated(UIApplication uiApplication)
        {
            base.OnActivated(uiApplication);
        }

        static UIViewController GetTopMostViewController()
        {
            var window = UIApplication.SharedApplication.KeyWindow;
            var root = window.RootViewController;
            if (root != null)
            {
                var current = root;
                while (current.PresentedViewController != null)
                {
                    current = current.PresentedViewController;
                }
                return current;
            }
            return window.RootViewController;
        }

        [Export("myBackdoorMethod")] // notice the colon at the end of the method name
        public void MyBackdoor()
        {
            var filename = "db.db";
            string ext = Path.GetExtension("db.db");
            string filenameNoExt = filename.Substring(0, filename.Length - ext.Length);
            string path = Path.Combine("Resources", filenameNoExt);
            var resourcePathname = NSBundle.MainBundle.PathForResource(path, ext.Substring(1, ext.Length - 1));
            //var fStream = new FileStream(resourcePathname, FileMode.Open, FileAccess.Read);

            string BaseDir = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.Personal)).ToString();
            string LibDir = Path.Combine(BaseDir, "Library/");
            string dbPath = Path.Combine(LibDir, "db.db");
            File.Delete(dbPath);

            File.Copy(resourcePathname, LibDir);
        }
    }
}
