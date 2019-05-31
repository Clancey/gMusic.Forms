using System;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using System.Linq;

namespace gMusic.iOS.Renderers {
	public class GradientShellFlyoutContentRenderer : ShellFlyoutContentRenderer {
		public GradientShellFlyoutContentRenderer (IShellContext context) : base (context)
		{

		}
		protected override void UpdateBackgroundColor ()
		{

			var tv = View.Subviews.OfType<UITableView> ().FirstOrDefault();
			tv.BackgroundColor = View.BackgroundColor = UIColor.FromPatternImage (UIImage.FromBundle ("launchBg"));
			tv.BackgroundView = new BluredView (UIBlurEffectStyle.Light);
		}
	}
}
