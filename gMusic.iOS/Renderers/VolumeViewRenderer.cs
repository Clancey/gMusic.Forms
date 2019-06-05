using System;
using gMusic.iOS.Renderers;
using gMusic.Views;
using MediaPlayer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer (typeof (VolumeView), typeof (VolumeViewRenderer))]
namespace gMusic.iOS.Renderers {
	public class VolumeViewRenderer : ViewRenderer {
		public MPVolumeView mPVolumeView;
		public VolumeViewRenderer ()
		{
			AddSubview(mPVolumeView = new MPVolumeView());
		}

		public override SizeRequest GetDesiredSize (double widthConstraint, double heightConstraint)
		{
			mPVolumeView.SizeToFit ();
			var s = mPVolumeView.Bounds.Size;
			return new SizeRequest (new Size (widthConstraint, heightConstraint), new Size (s.Width, s.Height));
		}


		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();
			mPVolumeView.Frame = Bounds;
		}
	}
}
