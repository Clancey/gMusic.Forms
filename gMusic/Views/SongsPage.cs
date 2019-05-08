using System;
using gMusic.Managers;
using gMusic.Models;
using gMusic.ViewModels;
using Localizations;
using Xamarin.Forms;

namespace gMusic.Views {
	public class SongsPage : SimpleDatabaseListView {
		public SongsPage ()
		{
			this.ViewModel = new SimpleDatabaseViewModel<Song> {
				Title = Strings.Songs
			};
		}

		protected override void OnItemSelected (object sender, SelectedItemChangedEventArgs args)
		{
			var song = args.SelectedItem as Song;
			//TODO: pass this into the playback manager
			PlaybackManager.Shared.Play (song);
			//this.Navigation.PushAsync (new SongsPage {
			//	BindingContext = new ArtistSongsViewModel {
			//		Artist = artist,
			//	}
			//});
		}
	}
}
