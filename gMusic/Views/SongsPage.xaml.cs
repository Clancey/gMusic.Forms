using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using gMusic.Models;
using gMusic.Views;
using gMusic.ViewModels;

namespace gMusic.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SongsPage : ContentPage
    {
        //TODO:FixMe
        public SongsViewModel viewModel;

        public SongsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new SongsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;


            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.LoadItemsCommand.Execute(null);
        }
    }
}