using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using gMusic.Views;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using gMusic.Managers;
using Localizations;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace gMusic
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();


            MainPage = new RootPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
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
		public static void ShowAlert(string title, string message)
		{
			Current.MainPage.DisplayAlert(title,message,Strings.Ok);
		}
	}
}
