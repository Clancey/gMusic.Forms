using System;
using gMusic.Models;
using gMusic.ViewModels;
using Localizations;

namespace gMusic.Views {
	public class PlaylistsPage : SimpleDatabaseListView {
		public PlaylistsPage ()
		{
			this.ViewModel = new SimpleDatabaseViewModel<Playlist> {
				Title = Strings.Playlists
			};
		}
	}
}
