using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using gMusic.Api;
using gMusic.Managers;
using Localizations;
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
			foreach(var screen in currentSearchScreens)
            {
                screen.Search(text);
            }
			
		}

        List<SearchResultsView> currentSearchScreens = new List<SearchResultsView>();
        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var providers = ApiManager.Shared.CurrentProviders.Where(x => x.Capabilities.IndexOf(MediaProviderCapabilities.Searchable) >= 0).ToList();
            //Panarama.AddPage("Local", new BoxView { BackgroundColor = Color.Green });
            //Panarama.AddPage("Google", new BoxView { BackgroundColor = Color.Fuchsia });
            //Panarama.AddPage("YouTube", new BoxView { BackgroundColor = Color.Blue });
            if (providers.Count + 1 == currentSearchScreens.Count)
                return;
            Panarama.Clear();
            var local = new SearchResultsView { };
            currentSearchScreens.Add(local);
            Panarama.AddPage(Strings.Local, local);
            foreach (var provider in providers)
            {
                var searchPage = new SearchResultsView();
                searchPage.Provider = provider;
                currentSearchScreens.Add(searchPage);
                Panarama.AddPage(ApiManager.ServiceTitle(provider.ServiceType), searchPage);

            }

        }

        string searchText;
		Timer searchTimer;
		public void KeyPressed (string text)
		{
			searchText = text;
			if (searchTimer == null) {
				searchTimer = new Timer (1500);
                searchTimer.Elapsed += (s, e) =>
                {
                    Device.BeginInvokeOnMainThread(() => Search(searchText));
                };
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
