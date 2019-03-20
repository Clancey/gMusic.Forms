using System;
using gMusic.Models;
using gMusic.ViewModels;
using Localizations;

namespace gMusic.Views {
	public class ArtistsPage : SimpleDatabaseListView {
		public ArtistsPage ()
		{
			this.ViewModel = new SimpleDatabaseViewModel<Artist> {
				Title = Strings.Artists
			};
			//this.ViewModel = new SimpleDatabaseViewModel
		}
	}
}
