using System;
using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using Com.EightbitLab.BlurViewBinding;
using gMusic.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using FormsBlurView = gMusic.Views.BlurView;

[assembly: ExportRenderer (typeof (FormsBlurView), typeof (BlurViewRender))]
namespace gMusic.Droid.Renderers {
	public class BlurViewRender : ViewRenderer<FormsBlurView, FrameLayout> {
		public BlurViewRender (Context context) : base (context)
		{
		}

		protected override void OnElementChanged (ElementChangedEventArgs<FormsBlurView> e)
		{
			base.OnElementChanged (e);

			if (Control == null) {
				var context = Context;
				var activity = context as Activity;

				var rootView = (ViewGroup)activity.Window.DecorView.FindViewById (Android.Resource.Id.Content);
				var windowBackground = activity.Window.DecorView.Background;

				var blurView = new BlurView (context);

				blurView.SetOverlayColor (Resource.Color.colorOverlay);

				blurView.SetupWith (rootView)
				   .WindowBackground (windowBackground)
				   .BlurAlgorithm (new RenderScriptBlur (context))
				   .BlurRadius (10f);

				SetNativeControl (blurView);
			}
		}
		
	}
}
