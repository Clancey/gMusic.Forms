using System;
using System.Collections.Generic;
using gMusic.Managers;
using gMusic.Models;
using gMusic.ViewModels;
using Localizations;
using Xamarin.Forms;

namespace gMusic.Views {
	public partial class CurrentPlaylistPage : ContentPage {
		public CurrentPlaylistPage ()
		{
			InitializeComponent ();
			BindingContext = new CurrentPlaylistViewModel ();
			this.Title = Strings.CurrentPlaylist;
			this.ToolbarItems.Add (new ToolbarItem () {
				IconImageSource = Images.NowPlayingScreen.NavBar.CloseButton,
				Command = new Command (async () => {
					await Navigation.PopModalAsync ();
				})
			});
		}
		CurrentPlaylistViewModel ViewModel => BindingContext as CurrentPlaylistViewModel;

		void List_ItemSelected (object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null)
				return;
			PlaybackManager.Shared.PlaySongAtIndex (e.SelectedItemIndex);
			ListView.SelectedItem = null;
		}
	}

}
