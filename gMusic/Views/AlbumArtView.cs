using System;
using FFImageLoading.Forms;
using Xamarin.Forms;

namespace gMusic.Views {
	public class AlbumArtView : AbsoluteLayout{
		CachedImage image;
		Frame frame;
		public AlbumArtView ()
		{
			frame = new Frame () {
				Content = image = new CachedImage {
					DownsampleToViewSize = true,
				},
				BackgroundColor = Color.LightGray,
				BorderColor = Color.Transparent,
				HasShadow = false,
				Padding = new Thickness (.5),
			};
			this.Children.Add (frame);
			this.VerticalOptions = LayoutOptions.FillAndExpand;
			this.HorizontalOptions = LayoutOptions.FillAndExpand;
		}

		public ImageSource Source {
			get => image.Source;
			set => image.Source = value;
		}


		public double MaxImageSize = 512;
		protected override void LayoutChildren (double x, double y, double width, double height)
		{

			var s = Math.Min (width, height);
			s = Math.Min (MaxImageSize, s);

			var newX = (width - s) / 2;
			var newY = (height - s) / 2;
			var rect = new Rectangle (newX, newY, s, s);

			frame.Layout (rect);

		}
	}
}
