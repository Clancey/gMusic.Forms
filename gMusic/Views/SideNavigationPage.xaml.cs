using System;
using System.Collections.Generic;

using Xamarin.Forms;
using gMusic.ViewModels;
using gMusic.Data;
using gMusic.Managers;

namespace gMusic.Views
{
    public partial class SideNavigationPage : ContentPage
    {
        public SideNavigationPage()
        {
            Title = "gMusic";
            InitializeComponent();
		}
		void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as NavigationItem;
            if (item == null)
                return;
            if (item.Page != null)
            {
                Settings.CurrentMenuIndex = e.SelectedItemIndex;
                (BindingContext as RootPage).Navigate(item);
            }
            (sender as ListView).SelectedItem = null;
        }
		
	}
}
