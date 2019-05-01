using System;
using Xamarin.Forms;

namespace gMusic.Views {

	public class ImageToggleButton : ToggleButton {
		FontImageSource onImageSource;
		public FontImageSource OnImageSource {
			get => onImageSource;
			set {
				onImageSource = value;
				SetState ();
			}
		}

		FontImageSource offImageSource;
		public FontImageSource OffImageSource {
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
			Source.Color = this.Toggled ? onColor : offColor;
		}
	}

	public abstract class ToggleButton : ContentView {

		bool toggled;
		public bool Toggled {
			get => toggled;
			set {
				toggled = value;
				SetState ();
			}
		}

		protected Image Image { get; set; }
		public Action<ToggleButton> Tapped { get; set; }
		public ToggleButton ()
		{
			this.Content = Image = new Image {
				Aspect = Aspect.AspectFit
			};
			this.Content.GestureRecognizers.Add (new TapGestureRecognizer {
				Command = new Command (() => {
					Tapped?.Invoke (this);
				})
			});
		}

		public FontImageSource Source{
			get => Image.Source as FontImageSource;
			set => Image.Source = value;
		}

		private void ToggleButton_Clicked (object sender, EventArgs e)
		{
			Toggled = !toggled;
			Tapped?.Invoke (this);
		}

		protected abstract void SetState ();
	}
}
