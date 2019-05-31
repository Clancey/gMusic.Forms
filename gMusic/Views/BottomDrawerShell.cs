using System;
using Xamarin.Forms;

namespace gMusic.Views {
	public class BottomDrawerShell : Shell {
		public object DrawerPage {
			get => GetValue (DrawerPageProperty);
			set => SetValue (DrawerPageProperty, value);
		}
		public static readonly BindableProperty DrawerPageProperty =
			BindableProperty.Create (nameof (DrawerPage), typeof (object), typeof (Shell), null, BindingMode.OneTime, propertyChanged: HandleDrawerPageChanged);
			
		public BottomDrawerShell ()
		{
		}

		protected void OnDrawerPageChanged(object oldValue, object newValue)
		{

		}

		static void HandleDrawerPageChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var shell = (BottomDrawerShell)bindable;
			shell.OnDrawerPageChanged (oldValue, newValue);
		}


		public float OverHang { get; set; } = 74;

		public float PercentVisible { get; set; }
	}
}
