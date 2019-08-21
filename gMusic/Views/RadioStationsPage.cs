using System;
using System.Threading.Tasks;
using gMusic.Data;
using gMusic.Managers;
using gMusic.Models;
using gMusic.ViewModels;
using Localizations;
using Xamarin.Forms;

namespace gMusic.Views
{
    public class RadioStationsPage : ContentPage
    {
        Command refreshCommand;
        public RadioStationsPage()
        {
            this.Title = Strings.RadioStations;
            refreshCommand = new Command(() =>
            {
                Console.WriteLine("Please refresh");
            });
            var panarama = new PanaramaView();
            panarama.AddPage(Strings.RecentStations, CreateView(false));
            panarama.AddPage(Strings.MyStations, CreateView(true));
            Content = panarama;

            //this.ViewModel = new SimpleDatabaseViewModel<RadioStation> {
            //	Title = Strings.RadioStations
            //};
            this.ToolbarItems.Add(new ToolbarItem
            {
                Command = new Command(() => PlayIFL()),
                IconImageSource = Images.DiceIcon,
            });
        }

        Task iflTask;
        Task PlayIFL()
        {

            if (iflTask?.IsCompleted ?? true)
                iflTask = PlaybackManager.Shared.Play(new RadioStation("I'm Feeling Lucky")
                {
                    Id = "IFL",
                });
            return iflTask;
        }

        ListView CreateView(bool isIncluded)
        {
            var group = Database.Main.GetGroupInfo<RadioStation>().Clone();
            if (isIncluded)
                group.AddFilter("IsIncluded = 1");
            else
            {
                group.Limit = 10;
                group.OrderByDesc = true;
                group.OrderBy = "RecentDateTime";
                group.GroupBy = "";
            }
            var viewModel = new SimpleDatabaseViewModel<RadioStation>()
            {
                Source = {
                    GroupInfo = group,
                    IsGrouped = isIncluded,
                }
               
            };
            var listView = new ListView
            {
                BindingContext = viewModel,
                RefreshCommand = refreshCommand,
                GroupDisplayBinding = new Binding("Display"),
                GroupShortNameBinding = new Binding("Display"),
                IsGroupingEnabled = viewModel.Source.IsGrouped,
                HasUnevenRows = true,
                ItemsSource = viewModel.Source,
                ItemTemplate = new DataTemplate(typeof(MediaItemCell)),

            };

            listView.ItemSelected += ListView_ItemSelected;
            return listView;
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var station = e.SelectedItem as RadioStation;
            if (station == null)
                return;
            (sender as ListView).SelectedItem = null;
            await PlaybackManager.Shared.Play(station);
        }
    }
}