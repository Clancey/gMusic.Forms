using System;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using gMusic.Views;
using gMusic.iOS.Renderers;

[assembly: ExportRenderer (typeof (GradientListView), typeof (GradientListViewRenderer))]
namespace gMusic.iOS.Renderers {
	public class GradientListViewRenderer : ListViewRenderer  {
		protected override void OnElementChanged (ElementChangedEventArgs<ListView> e)
		{
			base.OnElementChanged (e);
			if(this.Control != null) {
				Control.BackgroundColor = UIColor.FromPatternImage (UIImage.FromBundle ("launchBg")); ;
				Control.BackgroundView = new BluredView (UIBlurEffectStyle.Light);
			}
		}
		
	}
}
