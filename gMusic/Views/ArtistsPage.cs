using System;
using gMusic.Models;
using gMusic.ViewModels;
using Localizations;
using SimpleDatabase;
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
        protected override void ItemSelected(object item)
        {
			var artist = item as Artist;
			this.Navigation.PushAsync (new ArtistDetailsPage(artist));
		}

        public GroupInfo GroupInfo
        {
            get => (ViewModel as SimpleDatabaseViewModel<Artist>).Source.GroupInfo;
            set => (ViewModel as SimpleDatabaseViewModel<Artist>).Source.GroupInfo = value;
        }
	}
}
