using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gMusic.Api;
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
			if(SouldShowStartRadio(mediaItem)) {
				actions.Add ((Strings.StartRadioStation, () => StartRadioStation (mediaItem)));
			}
			return actions;
		}

		public async Task<bool> StartRadioStation(MediaItemBase item)
		{
			using (new Spinner (Strings.CreatingStation)) {
				try {
					var station = await MusicManager.Shared.CreateRadioStation (item);
					if (station != null) {
						await PlaybackManager.Shared.Play (station);
						return true;
					} else
						App.ShowAlert (Strings.RenameError, Strings.ErrorCreatingStation);
				} catch (Exception ex) {
					LogManager.Shared.Report (ex);
				}
			}
			return false;
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

		static bool SouldShowStartRadio (MediaItemBase item)
		{
			if (item is Playlist)
				return false;
			if (item is RadioStation)
				return false;
			if (item is Genre)
				return false;
			var song = item as OnlineSong;
			if (song != null) {
				var service = ApiManager.Shared.GetMusicProvider (song.TrackData.ServiceId);
				var hadRadio = service.Capabilities.Contains (MediaProviderCapabilities.Radio);
				return hadRadio;
			}
			return true;
		}
	}
}

