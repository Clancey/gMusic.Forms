using System;
using System.Collections.Generic;
using gMusic.Models;
using gMusic.ViewModels;
using Xamarin.Forms;

namespace gMusic.Views {
	public partial class PlaylistSongPage : ContentPage {
		public Playlist Playlist {
			get => ViewModel.Playlist;
			set => ViewModel.Playlist = value;
		}

		PlaylistSongsViewModel ViewModel;
		public PlaylistSongPage ()
		{
			this.BindingContext =  this.ViewModel = new PlaylistSongsViewModel ();
			InitializeComponent ();
		}

		protected void OnItemSelected (object sender, SelectedItemChangedEventArgs args)
		{
			var song = args.SelectedItem as PlaylistSong;
			if (song == null)
				return;
			ViewModel.OnTap (song);
			ItemsListView.SelectedItem = null;
		}
	}
}
