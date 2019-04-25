using System;
using Xamarin.Forms;

namespace gMusic.Views {
	public class SvgImageButton : ContentView {
		public Image Image { get; set; }
		public Action<SvgImageButton> Tapped { get; set; }
		public SvgImageButton ()
		{
			this.Content = Image = new Image ();
			this.Content.GestureRecognizers.Add (new TapGestureRecognizer {
				Command = new Command (() => {
					Tapped?.Invoke (this);
				})
			});
		}
	}
}
