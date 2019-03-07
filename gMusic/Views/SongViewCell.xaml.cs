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
            var url = await item.GetArtworkUrl();
            if (item != BindingContext)
                return;
            Image.Source = new UriImageSource { Uri = new Uri(url) };
        }
    }
}
