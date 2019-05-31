using System;
using gMusic.iOS.Renderers;
using gMusic.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer (typeof (BottomDrawerShell), typeof (BottomDrawerShellRenderer))]
namespace gMusic.iOS.Renderers {
	public class BottomDrawerShellRenderer : ShellRenderer {
		BottomDrawer Drawer = new BottomDrawer ();
		public BottomDrawerShellRenderer ()
		{
		}
		public override void LoadView ()
		{
			base.LoadView ();

			AddChildViewController (Drawer);
			View.Add (Drawer.View);
		}

		protected override void OnElementSet (Shell element)
		{
			base.OnElementSet (element);
			Drawer.Model = element as BottomDrawerShell;
		}

		IShellItemRenderer __currentShellItemRenderer;
		IShellItemRenderer _currentShellItemRenderer {
			get => __currentShellItemRenderer;
			set {
				try {
					__currentShellItemRenderer = value;
					var prop = this.GetType ().BaseType.GetField (
						nameof (_currentShellItemRenderer), System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
					prop.SetValue (this, value);
				}
				catch(Exception ex) {
					Console.WriteLine (ex);
				}
			}
		}
		protected override void OnCurrentItemChanged ()
		{
			var currentItem = Shell.CurrentItem;
			if (_currentShellItemRenderer?.ShellItem != currentItem) {
				var newController = CreateShellItemRenderer (currentItem);
				MySetCurrentShellItemController (newController);
			}
		}

		protected async void MySetCurrentShellItemController (IShellItemRenderer value)
		{
			var oldRenderer = _currentShellItemRenderer;
			var newRenderer = value;

			_currentShellItemRenderer = value;

			Drawer.SetContentViewController (newRenderer.ViewController);

			newRenderer.ViewController.View.Frame = View.Bounds;

			if (oldRenderer != null) {
				var transition = CreateShellItemTransition ();
				await transition.Transition (oldRenderer, newRenderer);

				oldRenderer.ViewController.RemoveFromParentViewController ();
				oldRenderer.ViewController.View.RemoveFromSuperview ();
				oldRenderer.Dispose ();
			}
		}

		protected override IShellFlyoutContentRenderer CreateShellFlyoutContentRenderer () => new GradientShellFlyoutContentRenderer (this);
	}
}
