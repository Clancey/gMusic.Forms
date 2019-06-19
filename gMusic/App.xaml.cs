using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using gMusic.Views;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using gMusic.Managers;
using Localizations;
using System.Threading.Tasks;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Analytics;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace gMusic {
	public partial class App : Application {

		public App ()
		{
#if DEBUG
			InMemoryConsole.Current.Activate ();
#endif
			AppCenter.Start (ApiConstants.AppCenterApiKey, typeof (Analytics), typeof (Crashes));

			InitializeComponent ();
			this.Resources.AddGmusicStyles ();
			NotificationManager.Shared.StyleChanged += Shared_StyleChanged;
			PlaybackManager.Shared.Init ();
			MainPage = new RootPage ();
		}

		private void Shared_StyleChanged (object sender, EventArgs e)
		{
			this.Resources.AddGmusicStyles ();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
			LocalWebServer.Shared.Start ();
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

		public static void ShowNotImplmented (Dictionary<string, string> extra = null,
											 [CallerMemberName] string function = "",
											 [CallerFilePath] string sourceFilePath = "",
											 [CallerLineNumber] int sourceLineNumber = 0)
		{
			LogManager.Shared.LogNotImplemented (extra, function, sourceFilePath, sourceLineNumber);
			ShowAlert (Strings.Sorry, $"Coming soon: {function}");
		}
		public static void ShowAlert (string title, string message)
		{
			Current.MainPage.DisplayAlert (title, message, Strings.Ok);
		}

		internal static Task<bool> CheckForOffline ()
		{
			return Task.FromResult (true);
			//throw new NotImplementedException ();
		}

		internal static void Playing ()
		{
			//throw new NotImplementedException ();
		}

		internal static void StoppedPlaying ()
		{
			//throw new NotImplementedException ();
		}
	}
}
