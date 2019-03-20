using System;
using gMusic.Models;
using gMusic.ViewModels;
using Localizations;

namespace gMusic.Views {
	public class SongsPage : SimpleDatabaseListView {
		public SongsPage ()
		{
			this.ViewModel = new SimpleDatabaseViewModel<Song> {
				Title = Strings.Songs
			};
		}
	}
}
