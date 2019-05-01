using System;
using Xamarin.Forms;

namespace gMusic.Views {

	public class ImageToggleButton : ToggleButton {
		ImageSource onImageSource;
		public ImageSource OnImageSource {
			get => onImageSource;
			set {
				onImageSource = value;
				SetState ();
			}
		}

		ImageSource offImageSource;
		public ImageSource OffImageSource {
			get => offImageSource;
			set {
				offImageSource = value;
				SetState ();
			}
		}

		protected override void SetState ()
		{
			this.Source = this.Toggled ? onImageSource : offImageSource;
		}
	}

	public class ImageColorToggleButton : ToggleButton {
		public ImageColorToggleButton()
		{
			onColor = Styles.Styles.CurrentStyle.AccentColor;
		}
		Color onColor;
		public Color OnColor {
			get => onColor;
			set {
				onColor = value;
				SetState ();
			}
		}

		Color offColor = Color.Black;
		public Color OffColor {
			get => offColor;
			set {
				offColor = value;
				SetState ();
			}
		}

		protected override void SetState ()
		{
			var fontSource = Source as FontImageSource;
			if (fontSource == null)
				return;
			fontSource.Color = this.Toggled ? onColor : offColor;
		}
	}

	public abstract class ToggleButton : ImageButton {

		bool toggled;
		public bool Toggled {
			get => toggled;
			set {
				toggled = value;
				SetState ();
			}
		}

		public Action<ToggleButton> Tapped { get; set; }
		public ToggleButton ()
		{
			
			this.Clicked += ToggleButton_Clicked;
		}

		private void ToggleButton_Clicked (object sender, EventArgs e)
		{
			Toggled = !toggled;
			Tapped?.Invoke (this);
		}

		protected abstract void SetState ();
	}
}
