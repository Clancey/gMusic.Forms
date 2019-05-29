using System;
using System.Collections.Generic;
using gMusic.Managers;
using gMusic.Models;
using gMusic.ViewModels;
using Xamarin.Forms;

namespace gMusic.Views {
	public partial class CurrentPlaylistPage : ContentPage {
		public CurrentPlaylistPage ()
		{
			InitializeComponent ();
			BindingContext = new CurrentPlaylistViewModel ();
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
