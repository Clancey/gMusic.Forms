using System;
using Xamarin.Forms.Platform.Android;
using AView = Android.Views.View;

namespace gMusic.Droid.Renderers {
	public class GradientShellFlyoutTemplatedContentRenderer : ShellFlyoutTemplatedContentRenderer {
		public GradientShellFlyoutTemplatedContentRenderer (IShellContext context) : base(context)
		{
		}

		AView _rootView;
		AView RootView {
			get => _rootView ?? (_rootView = (AView)(this.GetType ().BaseType.GetField (
					   nameof (_rootView), System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue (this)));
		}
		
		protected override void UpdateFlyoutBackgroundColor ()
		{
			base.UpdateFlyoutBackgroundColor ();
			RootView.SetBackgroundResource (gMusic.Droid.Resource.Drawable.gradient);
		}
	}
}
