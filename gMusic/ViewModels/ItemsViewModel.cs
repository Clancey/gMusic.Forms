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

namespace gMusic.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public SimpleDatabaseSource<Song> Items { get; } = new SimpleDatabaseSource<Song>(Database.Main);
        public Command LoadItemsCommand { get; set; }

        GoogleMusicProvider googleMusicProvider = new GoogleMusicProvider(new GoogleMusicApi("1"));

        public ItemsViewModel()
        {
            Title = "Browse";
           
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