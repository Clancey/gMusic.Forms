using System;
using System.Collections.Generic;

using Xamarin.Forms;
using gMusic.ViewModels;
using gMusic.Models;
using gMusic.Data;

namespace gMusic.Views
{
    public partial class ArtistsPage : ContentPage
    {
        public SimpleDatabaseSource<Artist> ViewModel { get; } = new SimpleDatabaseSource<Artist>(Database.Main);
        public ArtistsPage()
        {
            InitializeComponent();
            ItemsListView.BindingContext = this;
        }
    }
}
