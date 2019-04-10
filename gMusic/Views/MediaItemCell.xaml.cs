using System;
using System.Collections.Generic;
using Xamarin.Forms;
using gMusic.Models;
using gMusic.Styles;
namespace gMusic.Views
{
    public partial class MediaItemCell : ViewCell
    {
        public MediaItemCell()
        {
            InitializeComponent();
			Text.StyleAsMainText ();
			Detail.StyleAsSubText ();
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
			if (string.IsNullOrWhiteSpace (url))
				return;
            Image.Source = new UriImageSource { Uri = new Uri(url) };
        }
    }
}
