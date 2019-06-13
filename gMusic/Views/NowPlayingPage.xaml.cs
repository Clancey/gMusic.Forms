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
		const double bottomViewHeight = 300;

		NowPlayingViewModel ViewModel => (NowPlayingViewModel)BindingContext;
		public NowPlayingPage ()
		{
			this.BindingContext = new NowPlayingViewModel ();

			NotificationManager.Shared.InsetAreaChanged += Shared_InsetAreaChanged;

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


			MiniPlayer.GestureRecognizers.Add (new TapGestureRecognizer {
				Command = new Command ((obj) => {
					NotificationManager.Shared.ProcToggleNowPlaying ();
				})
			});

			navCloseButton.ImageSource = Images.NowPlayingScreen.NavBar.CloseButton;
			navCloseButton.Clicked += (sender, e) => {
				NotificationManager.Shared.ProcCloseNowPlaying ();
			};


			navCurrentPlayist.ImageSource = Images.NowPlayingScreen.NavBar.CurrentPlayistButton;
			navCurrentPlayist.Clicked += (sender, e) => {
				this.Navigation.PushModalAsync (new NavigationPage (new CurrentPlaylistPage ()));
			};



			SetState ();
			NotificationManager.Shared.PlaybackStateChanged += Shared_PlaybackStateChanged;
			NotificationManager.Shared.SongDownloadPulsed += Shared_SongDownloadPulsed;
			this.ViewModel.SubscribeToProperty (nameof (NowPlayingViewModel.TrackPosition),
				() => {
					ProgressBar.PlaybackProgress = ViewModel.TrackPosition.Percent;
				});

			UpdateVisibile (0f);
		}

		private void Shared_SongDownloadPulsed (object sender, NotificationManager.SongDowloadEventArgs e)
		{
			if (e.SongId != Settings.CurrentSong)
				return;
			ProgressBar.DownloadProgress = e.Percent;
		}

		double navLeftPadding;
		double navTopPadding;
		double navBottomPadding;
		private void Shared_InsetAreaChanged (object sender, EventArgs<Thickness> e)
		{
			var thickness = e.Data;
			navLeftPadding = thickness.Left;
			navTopPadding = thickness.Top;
			navBottomPadding = thickness.Bottom;
			UpdateNavLayout ();
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
			const float min = .7f;
			const float max = .9f;
			const float maxRange = max - min;
			if(percent >= min) {
				var p = percent - min;
				p = p / maxRange;
				visible = Math.Min (1f, p);
			}
			NavBar.Opacity = navVisiblePercent = visible;
			MiniPlayer.Opacity = 1f - visible;
			UpdateNavLayout ();
		}

		float navVisiblePercent;
		void UpdateNavLayout()
		{
			var topPadding = navTopPadding;
			const float navBarHeight = 64f;
			const float miniBarHeight = 56f;

			var range = topPadding + navBarHeight;
			var travelled = navVisiblePercent * range;
			var y = (-navBarHeight) + travelled;

			AbsoluteLayout.SetLayoutBounds (NavBar, new Rectangle (navLeftPadding, y, 1, navBarHeight));

			var miniPlayerY = -miniBarHeight;
			miniPlayerY += miniBarHeight * (1f - navVisiblePercent);
			AbsoluteLayout.SetLayoutBounds (MiniPlayer, new Rectangle (0, miniPlayerY, 1, miniBarHeight));

			var margin = BottomBar.Margin;
			margin.Bottom = navBottomPadding;
			BottomBar.Margin = margin;
			AbsoluteLayout.SetLayoutBounds (BottomControls, new Rectangle (0, 1, 1, bottomViewHeight + navBottomPadding));

		}
		//protected override void LayoutChildren (double x, double y, double width, double height)
		//{
		//	base.LayoutChildren (x, y, width, height);
		//	var h = BottomControls.Height;
		//	PaddingRow.Height = h - 56;
		//}

	}
}
