using System;
using System.Collections.Generic;
using gMusic.Api;
using gMusic.Data;
using gMusic.Managers;
using gMusic.Models;
using gMusic.ViewModels;
using Localizations;
using Xamarin.Forms;

namespace gMusic.Views
{
    public partial class SearchResultsView : ContentView
    {
        public SearchResultsView()
        {
            InitializeComponent();
        }
        string oldSearch;
        public async void Search(string search)
        {
            if (oldSearch == search)
                return;
            SearchResults results = null;
            if (Provider == null)
            {
                //DB search
                results = await Database.Main.Search(search);
            }
            else
                results = await Provider?.Search(search);
            ItemsListView.ItemsSource = results.Sections;
        }

        public MusicProvider Provider { get; set; }
        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            base.LayoutChildren(x, y, width, height);
        }
        public async void OnSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            ItemsListView.SelectedItem = null;
            var onlineSong = e.SelectedItem as OnlineSong;
            if (onlineSong != null)
            {
                if (!await MusicManager.Shared.AddTemp(onlineSong))
                {
                    App.ShowAlert(Strings.Sorry, Strings.ThereWasAnErrorPlayingTrack);
                    return;
                }
                await PlaybackManager.Shared.PlayNow(onlineSong, onlineSong.TrackData.MediaType == MediaType.Video);
                return;
            }

            var song = e.SelectedItem as Song;
            if (song != null)
            {
                await PlaybackManager.Shared.PlayNow(song);
                return;
            }

            var album = e.SelectedItem as Album;
            if (album != null)
            {
                //var vc = new AlbumDetailsViewController
                //{
                //    Album = album,
                //};

                //this.NavigationController.PushViewController(vc, true);
                return;
            }

            var onlineArtist = e.SelectedItem as OnlineArtist;
            if (onlineArtist != null)
            {
                //var vc = new OnlineArtistDetailsViewController
                //{
                //    Artist = onlineArtist,
                //};
                //this.NavigationController.PushViewController(vc, true);
                //return;
            }

            var artist = e.SelectedItem as Artist;
            if (artist != null)
            {
                await this.Navigation.PushAsync(new SongsPage
                {
                    BindingContext = new ArtistSongsViewModel
                    {
                        Artist = artist,
                    }
                });
                return;
            }

            var onlineRadio = e.SelectedItem as OnlineRadioStation;
            if (onlineRadio != null)
            {
                using (new Spinner(Strings.CreatingStation))
                {
                    var statsion = await MusicManager.Shared.CreateRadioStation(onlineRadio);
                    await PlaybackManager.Shared.Play(statsion);
                }
                return;
            }
            var radio = e.SelectedItem as RadioStation;
            if (radio != null)
            {
                await PlaybackManager.Shared.Play(radio);
                return;
            }

            var onlinePlaylist = e.SelectedItem as OnlinePlaylist;
            if (onlinePlaylist != null)
            {
                //var vc = new OnlinePlaylistViewController()
                //{
                //    Playlist = onlinePlaylist,
                //};
                //this.NavigationController.PushViewController(vc, true);
                //return;
            }
        }

      
    }
}
