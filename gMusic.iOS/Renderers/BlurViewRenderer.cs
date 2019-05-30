using System;
using gMusic.iOS.Renderers;
using gMusic.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer (typeof (BlurView), typeof (BlurViewRenderer))]
namespace gMusic.iOS.Renderers {
	public class BlurViewRenderer : ViewRenderer  {
		BluredView bluredView = new BluredView ();
		public BlurViewRenderer ()
		{
			AddSubview (bluredView);
		}
		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();
			bluredView.Frame = this.Bounds;
		}
	}
}
