using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using gMusic.Data;
using gMusic.Managers;
using Localizations;
using Xamarin.Forms;

namespace gMusic.Views {
	public partial class WelcomePage : ContentPage {
		public WelcomePage ()
		{
			InitializeComponent ();
			this.Title = Strings.Welcome;
			Header.Text = Strings.WelcomToGmusic;
			LoginButton.Text = Strings.Login;
			SkipButton.Text = Strings.Skip;
		}


		public async Task Login ()
		{
			try {
				var s = await ApiManager.Shared.CreateAndLogin (Api.ServiceType.Google);
				if (s) {
					await this.Navigation.PopModalAsync (true);
				}
			} catch (Exception ex) {
				Console.WriteLine (ex);
			}
		}

		public async Task Skip ()
		{
			Settings.IncludeIpod = Settings.IPodOnly = true;
			await this.Navigation.PopModalAsync ();
		}

		public async void LoginButtonClicked(object sender, EventArgs e)
		{
			await Login ();
		}

		public async  void SkipButtonClicked (object sender, EventArgs e)
		{
			await Skip ();
		}
	}
}
