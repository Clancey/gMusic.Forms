using System;
using System.Linq;
using System.Threading.Tasks;
using gMusic.Managers;
using gMusic.Models;
using gMusic.ViewModels;
using Localizations;
using Xamarin.Forms;

namespace gMusic.Views {
	public class PlaylistsPage : SimpleDatabaseListViewPage {

		public bool IsPicker { get; set; }
		public object MusicManger { get; private set; }

		public PlaylistsPage ()
		{
			this.ViewModel = new SimpleDatabaseViewModel<Playlist> {
				Title = Strings.Playlists
			};

		}
		public MediaItemBase FilterBy { get; set; }
		ToolbarItem addButton;
		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			if (IsPicker && addButton == null) {
				addButton = new ToolbarItem ("+", null, async () => {
					try {
						var newPlaylistName = await App.GetInputText (Strings.PlaylistName, Strings.Ok, Strings.Cancel);
						if(string.IsNullOrWhiteSpace(newPlaylistName)) {
							//TODO alert?
							return;
						}
						var services = MusicManager.Shared.GetServiceTypes (FilterBy).FirstOrDefault ();
						tcs.TrySetResult (new Playlist { Name = newPlaylistName, ServiceId = services });
						this.Navigation.PopModalAsync ();
					} catch (TaskCanceledException) {

					}
				});
				this.ToolbarItems.Add (new ToolbarItem (Strings.Cancel, null, () => {
					tcs.TrySetCanceled ();
					this.Navigation.PopModalAsync ();
				}));
				
				this.ToolbarItems.Add (addButton);
			}
		}

		TaskCompletionSource<Playlist> tcs = new TaskCompletionSource<Playlist> ();
		public Task<Playlist> WaitForSelection () => tcs.Task;

		protected override void OnItemSelected (object sender, SelectedItemChangedEventArgs args)
		{
			base.OnItemSelected (sender, args);
			var playlist = args.SelectedItem as Playlist;
			if(playlist == null) {
				return;
			}
			if (IsPicker) {
				tcs.TrySetResult (playlist);
				this.Navigation.PopModalAsync ();
			} else {
				this.Navigation.PushAsync (new PlaylistSongPage { Playlist = playlist});
			}
		}
	}
}
