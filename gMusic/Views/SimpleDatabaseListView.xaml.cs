using System;
using System.Collections.Generic;
using gMusic.Managers;
using gMusic.ViewModels;
using Xamarin.Forms;

namespace gMusic.Views {
	public partial class SimpleDatabaseListView : ContentPage {
		public BaseViewModel ViewModel {
			get => BindingContext as BaseViewModel;
			set => BindingContext = value;
		}

		public SimpleDatabaseListView ()
		{
			InitializeComponent ();
		}


		protected virtual void OnItemSelected (object sender, SelectedItemChangedEventArgs args)
		{
			ItemsListView.SelectedItem = null;
		}


		protected override async void OnAppearing ()
		{
			base.OnAppearing ();
			await ViewModel.ReloadData ();
			NotificationManager.Shared.StyleChanged += Shared_StyleChanged;
		}

		private void Shared_StyleChanged (object sender, EventArgs e)
		{
			ViewModel.ReloadData ();
		}

		protected override void OnDisappearing ()
		{
			base.OnDisappearing ();
			NotificationManager.Shared.StyleChanged -= Shared_StyleChanged;
		}
	}
}
