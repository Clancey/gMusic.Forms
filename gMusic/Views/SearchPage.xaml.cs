using System;
using System.Collections.Generic;
using System.Timers;
using gMusic.Managers;
using Xamarin.Forms;

namespace gMusic.Views {
	public partial class SearchPage : ContentPage {
		public SearchPage ()
		{
			InitializeComponent ();
		}

		void Handle_TextChanged (object sender, Xamarin.Forms.TextChangedEventArgs e)
		{
			KeyPressed (e.NewTextValue);
		}


		public async void Search (string text)
		{
			searchText = text;
			searchTimer?.Stop ();
			//ViewModels.ForEach (x => {
			//	SearchModel (text, x);
			//});

			var result = await ApiManager.Shared.GetMusicProvider (Api.ServiceType.Google).Search (text);
		}

		string searchText;
		Timer searchTimer;
		public void KeyPressed (string text)
		{
			searchText = text;
			if (searchTimer == null) {
				searchTimer = new Timer (1500);
				searchTimer.Elapsed += (s, e) => Search (searchText);
			} else
				searchTimer.Stop ();
			searchTimer.Start ();
		}

		void Handle_SearchButtonPressed (object sender, System.EventArgs e)
		{
			searchTimer.Stop ();
			Search (SearchBar.Text);
		}
	}
}
