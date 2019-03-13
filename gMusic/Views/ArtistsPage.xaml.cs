using System;
using System.Collections.Generic;

using Xamarin.Forms;
using gMusic.ViewModels;
using gMusic.Models;
using gMusic.Data;
using Localizations;

namespace gMusic.Views
{
    public partial class ArtistsPage : ContentPage
    {
        public SimpleDatabaseSource<Artist> ViewModel { get; } = new SimpleDatabaseSource<Artist>(Database.Main);
        public ArtistsPage()
        {
            InitializeComponent();
            ItemsListView.BindingContext = this;
            this.Title = Strings.Artists;
        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var artists = e.SelectedItem as Artist;

            var artistSongsPage = new SongsPage();
            artistSongsPage.BindingContext = artistSongsPage.viewModel = new ArtistSongsViewModel { Artist = artists };
            this.Navigation.PushAsync(artistSongsPage);


        }
    }
}
