using System;
using System.Threading.Tasks;
using gMusic.Managers;
using gMusic.Models;
using gMusic.ViewModels;
using Localizations;
using Xamarin.Forms;

namespace gMusic.Views
{
    public class RadioStationsPage : ContentPage
    {
        public RadioStationsPage()
        {
            this.Title = Strings.RadioStations;
            var panarama = new PanaramaView();
            //panarama.AddPage(Strings.RecentStations, new SimpleDatabaseListViewPage
            //{
            //    ViewModel = new SimpleDatabaseViewModel<RadioStation>()
            //}
            //);
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
    }
}