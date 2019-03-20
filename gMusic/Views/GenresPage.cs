using System;
using gMusic.Models;
using gMusic.ViewModels;
using Localizations;

namespace gMusic.Views {
	public class GenresPage : SimpleDatabaseListView{
		public GenresPage ()
		{
			this.ViewModel = new SimpleDatabaseViewModel<Genre> {
				Title = Strings.Genres
			};
		}
	}
}
