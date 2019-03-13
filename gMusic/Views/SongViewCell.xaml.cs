using System;
using System.Collections.Generic;
using Xamarin.Forms;
using gMusic.Models;

namespace gMusic.Views
{
    public partial class SongViewCell : ViewCell
    {
        public SongViewCell()
        {
            InitializeComponent();
            Image.LoadingPlaceholder = Image.ErrorPlaceholder = Images.DefaultAlbumArt;
        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            UpdateArtwork(BindingContext as MediaItemBase);
        }

        async void UpdateArtwork(MediaItemBase item)
        {
            if (item == null)
                return;
            var urlTask = item.GetArtworkUrl();
            if (!urlTask.IsCompleted)
                Image.Source = Images.DefaultAlbumArt;
            var url = await urlTask;
            if (item != BindingContext)
                return;
            Image.Source = new UriImageSource { Uri = new Uri(url) };
        }
    }
}
