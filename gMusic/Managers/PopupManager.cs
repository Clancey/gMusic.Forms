using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using gMusic.Data;
using gMusic.Models;
using gMusic.Views;
using Localizations;
using Xamarin.Forms;

namespace gMusic.Managers {
	public class PopupManager : ManagerBase<PopupManager> {


		public List<(string Title, Func<Task<bool>> Action)> CreatePopoptions(MediaItemBase mediaItem)
		{
			var actions = new List<(string Title, Func<Task<bool>> Action)> {
				(Strings.Play, ()=>Play(mediaItem)),
				(Strings.Shuffle, ()=>Shuffle(mediaItem)),
			};

			bool hasQueue = !(mediaItem is RadioStation radio) && !(mediaItem is Playlist playlist) ;
			if(hasQueue) {
				actions.Add ((Strings.PlayNext, ()=> PlayNext (mediaItem)));
				actions.Add ((Strings.AddToQueue, ()=> Queue (mediaItem)));
				actions.Add ((Strings.AddingToPlaylist,()=> AddToPlaylist (mediaItem)));
			}

			return actions;
		}

		public async Task<bool> Shuffle (MediaItemBase item)
		{
			Settings.ShuffleSongs = true;
			return await Play (item);
		}
		public async Task<bool> PlayNext (MediaItemBase item)
		{
			await PlaybackManager.Shared.PlayNext (item);
			return true;
		}
		public async Task<bool> Queue (MediaItemBase item)
		{
			//PlaybackManager.Shared.AddToQueue (item);
			return true;
		}
		public async Task<bool> Play(MediaItemBase item)
		{
			PlaybackManager.Shared.Play (item);
			return true;
		}
		public async Task<bool> AddToPlaylist(MediaItemBase item)
		{

			var page = new PlaylistsPage { IsPicker = true, FilterBy = item	};
			await App.Current.MainPage.Navigation.PushModalAsync (new NavigationPage(page));
			try {
				var playlist = await page.WaitForSelection ();
				using (new Spinner (Strings.AddingToPlaylist)) {
					var success = await MusicManager.Shared.AddToPlaylist (item, playlist);
					if (!success)
						App.ShowAlert (Strings.ErrorAddingToPlaylist, Strings.PleaseTryAgain);
				}
				return true;
			} catch(TaskCanceledException) {
				return false;
			}
			
		}
	}
}

