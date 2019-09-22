using System;
using gMusic.Data;
using gMusic.Managers;
using gMusic.Models;
using gMusic.ViewModels;
using Localizations;
using Xamarin.Forms;

namespace gMusic.Views
{
    public class ArtistDetailsPage : ContentPage
    {
        ListView artistSongs;
        ListView artistAlbumsPage;
        ArtistSongsViewModel songsViewModel;
        public ArtistDetailsPage(Artist artist)
        {
            var albumGroup = new SimpleDatabase.GroupInfo
            {
                From = "Album",
                Params = {
                        { "@ArtistId", artist.Id }
                    },
                Filter = "Id in (select distinct AlbumId from song where ArtistId = @ArtistId )",
                OrderBy = "Year, NameNorm"
            };

            var panarama = new PanaramaView();
            artistAlbumsPage = new ListView
            {
                ItemsSource = new SimpleDatabaseSource<Album>(Database.Main)
                {
                    GroupInfo = albumGroup,
                    IsGrouped = false,
                },
                ItemTemplate = new DataTemplate(typeof(MediaItemCell)),
                HasUnevenRows = true,
            };

            artistAlbumsPage.ItemSelected += ArtistAlbumsPage_ItemSelected;

            panarama.AddPage(Strings.Albums, artistAlbumsPage);
            songsViewModel = new ArtistSongsViewModel
            {
                Artist = artist,
            };
            artistSongs = new ListView
            {
                ItemsSource = songsViewModel.Source,
                IsGroupingEnabled = true,
                GroupDisplayBinding = new Binding("Display"),
                GroupShortNameBinding = new Binding("Display"),
                ItemTemplate = new DataTemplate(typeof(MediaItemCell)),
                HasUnevenRows = true,
            };
            artistSongs.ItemSelected += ArtistSongs_ItemSelected;
            panarama.AddPage(Strings.Songs, artistSongs);
            Content = panarama;
        }

        private void ArtistSongs_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var song = e.SelectedItem as Song;
            if (song == null)
                return;
            artistSongs.SelectedItem = null;
            songsViewModel.OnTap(song);
        }

        private void ArtistAlbumsPage_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var album = e.SelectedItem as Album;
            if (album == null)
                return;
            this.Navigation.PushAsync(new AlbumDetailsPage(album));
        }
    }
}
