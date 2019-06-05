using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using gMusic.Data;
using gMusic.Managers;
using gMusic.Models;
using gMusic.ViewModels;
using Xamarin.Forms;

namespace gMusic.Views {

	public partial class NowPlayingPage : ContentPage {

		ImageColorToggleButton thumbsUpButton;
		ImageColorToggleButton thumbsDownButton;
		ImageToggleButton playPauseButton;
		ImageToggleButton miniPlayPauseButton;

		const int toggleDelay = 100;

		NowPlayingViewModel ViewModel => (NowPlayingViewModel)BindingContext;
		public NowPlayingPage ()
		{
			this.BindingContext = new NowPlayingViewModel ();
			ViewModel.SongChanged = () => {
				SetState ();
			};

			InitializeComponent ();
			ControlsStack.Children.Clear ();

			ControlsStack.Children.Add (thumbsDownButton = CreateButton (Images.NowPlayingScreen.ThumbsDown, async (b) => {
				SetState ();
				await ViewModel.ThumbsDown ();
				SetState ();
			}));

			ControlsStack.Children.Add (CreateButton (Images.NowPlayingScreen.Previous, async (b) => {
				PlaybackManager.Shared.Previous ();
				await Task.Delay (toggleDelay);
				b.Toggled = false;
			}));
			ControlsStack.Children.Add (playPauseButton = CreateButton (Images.NowPlayingScreen.Pause, Images.NowPlayingScreen.Play, (b) => {
				if(b.Toggled)
					PlaybackManager.Shared.Play ();
				else
					PlaybackManager.Shared.Pause ();
			}));
			ControlsStack.Children.Add (CreateButton (Images.NowPlayingScreen.Next, async (b) => {
				await PlaybackManager.Shared.NextTrack ();
				await Task.Delay (toggleDelay);
				b.Toggled = false;
			}));
			ControlsStack.Children.Add (thumbsUpButton = CreateButton (Images.NowPlayingScreen.ThumbsUp, async (b) => {
				SetState ();
				await ViewModel.ThumbsUp ();
				SetState ();
			}));
			
			MiniPlayer.Children.Add (miniPlayPauseButton = CreateButton (Images.NowPlayingScreen.PauseBordered, Images.NowPlayingScreen.PlayBordered, (b) => {
				if (b.Toggled)
					PlaybackManager.Shared.Play ();
				else
					PlaybackManager.Shared.Pause ();
			}), 2, 0);

			BottomBar.Children.Add (CreateButton (Images.NowPlayingScreen.BottomBar.ShareButton, async (b) => {
				await Task.Delay (toggleDelay);
				b.Toggled = false;
			}));
			BottomBar.Children.Add (CreateButton (Images.NowPlayingScreen.BottomBar.ShuffleButton, (b) => {
				Settings.ShuffleSongs = b.Toggled;
				if (Settings.ShuffleSongs) {
					PlaybackManager.Shared.ShuffleCurrentPlaylist ();
				}
			},Settings.ShuffleSongs));

			BottomBar.Children.Add (CreateButton (Images.NowPlayingScreen.BottomBar.RepeatButton, (b) => {

			}));

			BottomBar.Children.Add (CreateButton (Images.NowPlayingScreen.BottomBar.MoreButton, async (b) => {
				//TODO: Show popup
				await Task.Delay (toggleDelay);
				b.Toggled = false;
			}));

			SetState ();
			NotificationManager.Shared.PlaybackStateChanged += Shared_PlaybackStateChanged;
			UpdateVisibile (0f);
		}

		async void SetState()
		{
			var song = ViewModel.CurrentSong;
			thumbsDownButton.Toggled = song?.Rating == 1;
			thumbsUpButton.Toggled = song?.Rating == 5;
			await UpdateArtwork (song);
		}

		async Task UpdateArtwork(Song song)
		{
			if (song == null)
				return;
			var urlTask = song.GetArtworkUrl ();
			if (!urlTask.IsCompleted)
				SetImageSource (Images.DefaultAlbumArt);
			var url = await urlTask;
			if (song != ViewModel.CurrentSong)
				return;
			if (string.IsNullOrWhiteSpace (url))
				return;
			SetImageSource (new UriImageSource { Uri = new Uri (url) });
		}
		void SetImageSource(ImageSource source)
		{
			BackgroundImage.Source = Image.Source = source;
			AlbumArtView.Source = source;
		}

		private void Slider_ValueChanged (object sender, ValueChangedEventArgs e)
		{
		}

		void Shared_PlaybackStateChanged (object sender, EventArgs<Models.PlaybackState> e)
		{
			miniPlayPauseButton.Toggled = playPauseButton.Toggled = (e.Data == Models.PlaybackState.Buffering || e.Data ==  Models.PlaybackState.Playing);
		}

		static ImageColorToggleButton CreateButton (FontImageSource source, Action<ToggleButton> action, bool state = false)
		{
			return new ImageColorToggleButton {
				Source = source,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Center,
				Toggled = state,
				Tapped = action,
			};
		}
		static ImageToggleButton CreateButton (FontImageSource onImage, FontImageSource offImage, Action<ToggleButton> action)
		{
			return new ImageToggleButton {
				OnImageSource = onImage,
				OffImageSource = offImage,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				Tapped = action,
			};
		}


		public void UpdateVisibile(float percent)
		{
			Console.WriteLine (percent);
			float visible = 0;
			const float min = .5f;
			const float max = .9f;
			const float maxRange = max - min;
			if(percent >= min) {
				var p = percent - min;
				p = p / maxRange;
				visible = Math.Min (1f, p);
			}
			NavBar.Opacity = visible;
			MiniPlayer.Opacity = 1f - visible;

		}
		//protected override void LayoutChildren (double x, double y, double width, double height)
		//{
		//	base.LayoutChildren (x, y, width, height);
		//	var h = BottomControls.Height;
		//	PaddingRow.Height = h - 56;
		//}

	}
}
