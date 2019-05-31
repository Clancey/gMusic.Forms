using System;
using Android.Content;
using gMusic.Droid.Renderers;
using gMusic.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ExportRenderer (typeof (BottomDrawerShell), typeof (BottomDrawerShellRenderer))]
namespace gMusic.Droid.Renderers {
	public class BottomDrawerShellRenderer  : ShellRenderer{
		public BottomDrawerShellRenderer (Context context) : base (context)
		{
			Console.WriteLine ("Hello");
		}

		protected override IShellFlyoutRenderer CreateShellFlyoutRenderer () => new BottomDrawerShellFlyoutRenderer (this,this.AndroidContext);

		protected override IShellFlyoutContentRenderer CreateShellFlyoutContentRenderer () => new GradientShellFlyoutTemplatedContentRenderer (this);

		public BottomDrawerShell Model => Element as BottomDrawerShell;
	}


}
