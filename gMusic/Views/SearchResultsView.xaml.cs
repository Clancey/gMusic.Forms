using System;
using System.Collections.Generic;
using gMusic.Api;
using gMusic.Data;
using Xamarin.Forms;

namespace gMusic.Views
{
    public partial class SearchResultsView : ContentView
    {
        public SearchResultsView()
        {
            InitializeComponent();
        }
        string oldSearch;
        public async void Search(string search)
        {
            if (oldSearch == search)
                return;
            SearchResults results = null;
            if (Provider == null)
            {
                //DB search
                results = await Database.Main.Search(search);
            }
            else
                results = await Provider?.Search(search);
            ItemsListView.ItemsSource = results.Sections;
        }

        public MusicProvider Provider { get; set; }
        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            base.LayoutChildren(x, y, width, height);
        }
    }
}
