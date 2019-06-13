using System;
using FFImageLoading.Forms;
using Xamarin.Forms;

namespace gMusic.Views {
	public class AlbumArtView : AbsoluteLayout {

		CachedImage image;
		Frame frame;
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

		}
	}
}
