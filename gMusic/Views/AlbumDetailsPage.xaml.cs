using System;
using System.Collections.Generic;

using Xamarin.Forms;
using gMusic.Models;
using gMusic.ViewModels;
using gMusic.Data;
using SimpleDatabase;
using gMusic.Views.Controls;

namespace gMusic.Views
{
    public partial class AlbumDetailsPage : ContentPage
    {
        public AlbumDetailsPage(Album album)
        {
            this.Title = album.Name;
            InitializeComponent();
            var groupInfo = new GroupInfo
            {
                From = "Song",
                Params = { { "@AlbumId", album.Id } },
                Filter = "AlbumId = @AlbumId",
                OrderBy = "Disc, Track"
            };


            this.ListView.ItemsSource = new SimpleDatabaseSource<Song>(Database.Main)
            {
                GroupInfo = groupInfo,
                IsGrouped = false,
                
            };
            this.ListView.HasUnevenRows = true;
            this.ListView.Header = new SquareContentView(album);
        }
    }
}
