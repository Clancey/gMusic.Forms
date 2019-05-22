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

		public static readonly BindableProperty ToggledProperty =  BindableProperty.Create (nameof(Toggled), typeof (bool), typeof (ToggleButton), false,propertyChanged: (bindable, oldValue, newValue) => {
			((ToggleButton)bindable).SetState ();
		});
		
		public bool Toggled {
			get => (bool)GetValue(ToggledProperty);
			set => SetValue (ToggledProperty, value);
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
					Toggled = !Toggled;
					Tapped?.Invoke (this);
					SetState ();
				})
			});
		}

		public FontImageSource Source{
			get => Image.Source as FontImageSource;
			set => Image.Source = value;
		}

		protected abstract void SetState ();
	}
}
