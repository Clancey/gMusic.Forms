using System;
using gMusic.Models;
using gMusic.ViewModels;
using Localizations;

namespace gMusic.Views {
	public class GenresPage : SimpleDatabaseListViewPage
    {
		public GenresPage ()
		{
			this.ViewModel = new SimpleDatabaseViewModel<Genre> {
				Title = Strings.Genres
			};
		}
	}
}
