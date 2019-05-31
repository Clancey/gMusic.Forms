using System;
using Android.Content;
using Android.Views;
using gMusic.Views;
using Xamarin.Forms.Platform.Android;
using AView = Android.Views.View;

namespace gMusic.Droid.Renderers {
	public class BottomDrawerShellFlyoutRenderer : ShellFlyoutRenderer {
		public BottomDrawerShellFlyoutRenderer (IShellContext shellContext, Context context) : base (shellContext, context)
		{
		}
		AView content;
		BottomDrawerShellRenderer bottomDrawerShell;
		protected override void AttachFlyout (IShellContext context, AView content)
		{
			bottomDrawerShell = context as BottomDrawerShellRenderer;
			this.content = content;
			base.AttachFlyout (context, content);
		}
		BottomDrawer drawer;

		public override void AddView (AView child)
		{
			if(child == content) {
				drawer = new BottomDrawer (this.Context);
				drawer.Setup (bottomDrawerShell.Model, child);
				AddView (drawer);
			}
			else
				base.AddView (child);
		}
		
	}
}
