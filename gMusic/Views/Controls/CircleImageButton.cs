using System;
using Xamarin.Forms;

namespace gMusic.Views {
	public class CircleImageButton : AbsoluteLayout {



		public ImageSource ImageSource {
			get => image.Source;
			set => image.Source = value;
		}

		public EventHandler Clicked;

		Frame frame;
		Image image;
		public CircleImageButton ()
		{
			Children.Add (frame = new Frame {
				BackgroundColor = Color.FromHex ("#80FFFFFF"),
				HasShadow = false,
			});
			Children.Add (image = new Image { Aspect= Aspect.AspectFit});
			this.GestureRecognizers.Add (new TapGestureRecognizer {
				Command = new Command ((obj) => {
					Clicked?.Invoke (this, new EventArgs ());
				})
			});
		}
		
		protected override void LayoutChildren (double x, double y, double width, double height)
		{
			var s = Math.Min (width, height);

			var newX = (width - s) / 2;
			var newY = (height - s) / 2;

			var rect = new Rectangle (newX, newY, s, s);
			frame.CornerRadius = (float)s/2f;
			frame.Layout (rect);

			var imageS = s * .55;

			newX = (width - imageS) / 2;
			newY = (height - imageS) / 2;
			rect = new Rectangle (newX, newY, imageS, imageS);

			image.Layout (rect);
		}

		void SetImage()
		{
			image.Source = ImageSource;
		}
	}
}
