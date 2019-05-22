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

		ViewModel NowPlayingViewModel => (ViewModel)BindingContext;
		public NowPlayingPage ()
		{
			this.BindingContext = new ViewModel ();
			InitializeComponent ();
			ControlsStack.Children.Clear ();

			ControlsStack.Children.Add (thumbsDownButton = CreateButton (Images.NowPlayingScreen.ThumbsDown, async (b) => {
				await NowPlayingViewModel.ThumbsDown ();
			}));
			thumbsDownButton.SetBinding (ToggleButton.ToggledProperty, $"{nameof (NowPlayingViewModel.CurrentSong)}.{nameof (Song.Rating)}", converter: new ThumbsDownDataConverter ());

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
				await NowPlayingViewModel.ThumbsUp ();
			}));
			thumbsUpButton.SetBinding (ToggleButton.ToggledProperty, $"{nameof(NowPlayingViewModel.CurrentSong)}.{nameof(Song.Rating)}", converter: new ThumbsUpDataConverter ());

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

			NotificationManager.Shared.PlaybackStateChanged += Shared_PlaybackStateChanged;

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

	}
}
