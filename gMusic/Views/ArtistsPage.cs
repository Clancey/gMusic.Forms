using System;
using gMusic.Models;
using gMusic.ViewModels;
using Localizations;
using Xamarin.Forms;

namespace gMusic.Views {
	public class ArtistsPage : SimpleDatabaseListViewPage {
		public ArtistsPage ()
		{
			this.ViewModel = new SimpleDatabaseViewModel<Artist> {
				Title = Strings.Artists
			};
			//this.ViewModel = new SimpleDatabaseViewModel
		}
		protected override void OnItemSelected (object sender, SelectedItemChangedEventArgs args)
		{
			var artist = args.SelectedItem as Artist;
			this.Navigation.PushAsync (new ArtistDetailsPage(artist));
		}
	}
}
