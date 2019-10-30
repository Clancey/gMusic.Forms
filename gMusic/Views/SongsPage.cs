using System;
using gMusic.Managers;
using gMusic.Models;
using gMusic.ViewModels;
using Localizations;
using Xamarin.Forms;

namespace gMusic.Views {
	public class SongsPage : SimpleDatabaseListViewPage {
		public SongsPage ()
		{
			this.ViewModel = new SimpleDatabaseViewModel<Song> {
				Title = Strings.Songs
			};
		}

        protected override void ItemSelected(object item)
        {
            var song = item as Song;
			var songViewModel = BindingContext as SongsViewModel;

			if (songViewModel != null)
				songViewModel.OnTap (song);
			else if(BindingContext is PlaylistSongsViewModel plsvm) {
				plsvm.OnTap (item as PlaylistSong);
			}
			else 
				PlaybackManager.Shared.Play (song);
		}

		
	}
}
