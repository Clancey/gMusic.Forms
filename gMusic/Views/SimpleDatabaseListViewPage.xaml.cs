using System;
using System.Collections.Generic;
using System.Linq;
using gMusic.Managers;
using gMusic.Models;
using gMusic.ViewModels;
using Xamarin.Forms;

namespace gMusic.Views {
	public partial class SimpleDatabaseListViewPage : ContentPage {
		public BaseViewModel ViewModel {
			get => BindingContext as BaseViewModel;
            set => BindingContext = value;
		}

		public SimpleDatabaseListViewPage ()
		{
			InitializeComponent ();
            var layout = CollectionView.ItemsLayout as LinearItemsLayout;
            layout.ItemSpacing = 6;
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

        void CollectionView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            if (!e.CurrentSelection.Any())
                return;
            (sender as CollectionView).SelectedItem = null;
            var item = e.CurrentSelection.First();
            ItemSelected(item);

        }

        protected virtual void ItemSelected(object item)
        {

        }
    }
}
