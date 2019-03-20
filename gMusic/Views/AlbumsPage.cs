using System;
using gMusic.Models;
using gMusic.ViewModels;
using Localizations;

namespace gMusic.Views {
	public class AlbumsPage : SimpleDatabaseListView {
		public AlbumsPage ()
		{
			this.ViewModel = new SimpleDatabaseViewModel<Album> {
				Title = Strings.Albums
			};
		}
	}
}
