using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FFImageLoading.Forms;
using gMusic.Models;
using Xamarin.Forms;

namespace gMusic.Views {
	public class AlbumArtView : AbsoluteLayout {

		CachedImage image;
		Frame frame;
		List<CachedImage> images = new List<CachedImage> ();
		public AlbumArtView ()
		{
			frame = new Frame () {
				Content = image = new CachedImage {
					DownsampleToViewSize = true,
					Aspect = Aspect.AspectFill
				},
				BackgroundColor = Color.Gray,
				BorderColor = Color.Transparent,
				HasShadow = false,
				CornerRadius = 0,
				Padding = new Thickness (.5),
			};
			this.Children.Add (frame);
			this.VerticalOptions = LayoutOptions.FillAndExpand;
			this.HorizontalOptions = LayoutOptions.FillAndExpand;
		}

		public ImageSource LoadingPlaceholder {
			get => image.LoadingPlaceholder;
			set => image.LoadingPlaceholder = value;
		}

		public ImageSource ErrorPlaceholder {
			get => image.ErrorPlaceholder;
			set => image.ErrorPlaceholder = value;
		}

		public ImageSource Source {
			get => image.Source;
			set => image.Source = value;
		}
		public double Padding { get; set; } = 0;

		public double MaxImageSize = 512;
		protected override void LayoutChildren (double x, double y, double width, double height)
		{

			var s = Math.Min (width, height);
			s = Math.Min (MaxImageSize, s - Padding);

			var newX = (width - s) / 2;
			var newY = (height - s) / 2;
			var rect = new Rectangle (newX, newY, s, s);

			frame.Layout (rect);

			var half = s / 2;
			rect.Width = rect.Height = half;
			for(var i = 0; i< images.Count;i++) {
				var img = images [i];
				img.Layout (rect);
				if(i == 0 || i == 2) {
					rect.X = half + newX;
				}

				if(i == 1) {
					rect.X = newX;
					rect.Y = newY + half;
				}				

			}

		}


		public async void UpdateArtwork (MediaItemBase item)
		{
            if (item == null)
            {
                SetAsDefault();
                return;
            }
			var urlTask = item.GetArtworkUrl ();
			if (!urlTask.IsCompleted) {
				image.Source = Images.DefaultAlbumArt;
				images.ForEach (i => i.IsVisible = false);
			}
			var url = await urlTask;
			if (item != BindingContext)
				return;
			if (!string.IsNullOrWhiteSpace (url)) {
				SetAsSingleImage (url);
				return;
			}

			if (!(item is IMultiImage multiImage))
				return;

			var urls = await Managers.ArtworkManager.Shared.GetArtwork (multiImage);
			if (urls.Length == 0)
				return;

			if (urls.Length == 1) {
				SetAsSingleImage (urls [0]);
				return;
			}

			SetMultiImages (urls);

		}

		void SetAsSingleImage(string url)
		{
            if(string.IsNullOrWhiteSpace(url))
            {
                Console.WriteLine(url);
            }
			image.Source = new UriImageSource { Uri = new Uri (url) };
			images.ForEach (i => i.IsVisible = false);
		}
        void SetAsDefault()
        {
            image.IsVisible = true;
            image.Source = Images.DefaultAlbumArt;
            images.ForEach(i => i.IsVisible = false);
        }

		void SetMultiImages(string[] urls)
		{
			image.Source = Images.DefaultAlbumArt;

			for(var i = 0; i <urls.Length; i++) {
				var img = images.GetAtIndexOrDefault (i);
				if (img == null) {
					images.Add(img = new CachedImage ());
					Children.Add (img);
				}
				img.Source = new UriImageSource { Uri = new Uri (urls[i]) };
				img.IsVisible = true;
  			}
		}
	}
}
