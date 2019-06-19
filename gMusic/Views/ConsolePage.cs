using System;
using gMusic.Managers;
using Xamarin.Forms;

namespace gMusic.Views {
	public class ConsolePage : ContentPage {
		Label label;
		public ConsolePage ()
		{
			Title = "Console";
			Content = new ScrollView {
				Content = label = new Label { FontSize = 12},
			};
		}
		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			NotificationManager.Shared.ConsoleChanged += Shared_ConsoleChanged;
			label.Text = InMemoryConsole.Current.ToString ();
		}

		private void Shared_ConsoleChanged (object sender, EventArgs e)
		{
			label.Text = InMemoryConsole.Current.ToString ();
		}

		protected override void OnDisappearing ()
		{
			base.OnDisappearing ();
			NotificationManager.Shared.ConsoleChanged -= Shared_ConsoleChanged;
		}
	}
}

