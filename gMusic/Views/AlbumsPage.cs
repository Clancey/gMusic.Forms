using System;
using gMusic.Models;
using gMusic.ViewModels;
using Localizations;
using Xamarin.Forms;

namespace gMusic.Views {
	public class AlbumsPage : SimpleDatabaseListViewPage {
		public AlbumsPage ()
		{
			this.ViewModel = new SimpleDatabaseViewModel<Album> {
				Title = Strings.Albums
			};
		}
        //protected override void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        //{
        //    var album = args.SelectedItem as Album;
        //    if (album == null)
        //        return;
        //    this.Navigation.PushAsync(new AlbumDetailsPage(album));
        //}
    }
}
