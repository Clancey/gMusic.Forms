using System;
using Xamarin.Forms;
using gMusic.Views;
using gMusic.Droid.Renderers;
using Xamarin.Forms.Platform.Android;
using Android.Content;

[assembly: ExportRenderer (typeof (GradientListView), typeof (GradientListViewRenderer))]
namespace gMusic.Droid.Renderers {
	public class GradientListViewRenderer : ListViewRenderer {
		public GradientListViewRenderer (Context context ) : base (context)
		{

		}
		protected override void OnElementChanged (ElementChangedEventArgs<ListView> e)
		{
			base.OnElementChanged (e);
			if (this.Control != null) {
				//Control.SetBackgroundColor (Color.Blue.ToAndroid());
				Control.SetBackgroundResource(gMusic.Droid.Resource.Drawable.gradient);
			}
		}

	}
}
