using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using gMusic.Models;
using gMusic.Views;
//using gMusic.Apis;
using SimpleAuth;
using System.Linq;
using gMusic.Data;
using gMusic.Api.GoogleMusic;
using Localizations;

namespace gMusic.ViewModels
{
    public class SongsViewModel : BaseViewModel
    {
        public SimpleDatabaseSource<Song> Items { get; } = new SimpleDatabaseSource<Song>(Database.Main);
        public Command LoadItemsCommand { get; set; }

        GoogleMusicProvider googleMusicProvider = new GoogleMusicProvider(new GoogleMusicApi("1"));

        public SongsViewModel()
        {
            Title = Strings.Songs;
           
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                await googleMusicProvider.SyncDatabase();
                Items.ResfreshData();
                //foreach (var item in json)
                //{
                //    Items.Add(item);
                //}
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}