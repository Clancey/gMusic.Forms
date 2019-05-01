using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace gMusic.Views {
	public partial class NowPlayingPage : ContentPage {

		ImageColorToggleButton thumbsUpButton;
		ImageColorToggleButton thumbsDownButton;

		const int toggleDelay = 100;
		public NowPlayingPage ()
		{
			InitializeComponent ();
			ControlsStack.Children.Clear ();

			ControlsStack.Children.Add (thumbsDownButton = CreateButton (Images.NowPlayingScreen.ThumbsDown, (b) => {

			}));
			ControlsStack.Children.Add (CreateButton (Images.NowPlayingScreen.Previous, async (b) => {

				await Task.Delay (toggleDelay);
				b.Toggled = false;
			}));
			ControlsStack.Children.Add (CreateButton (Images.NowPlayingScreen.Pause, Images.NowPlayingScreen.Play, (b) => {

			}));
			ControlsStack.Children.Add (CreateButton (Images.NowPlayingScreen.Next, async (b) => {
				await Task.Delay (toggleDelay);
				b.Toggled = false;
			}));
			ControlsStack.Children.Add (thumbsUpButton = CreateButton (Images.NowPlayingScreen.ThumbsUp, (b) => {

			}));

			MiniPlayer.Children.Add (CreateButton (Images.NowPlayingScreen.PauseBordered, Images.NowPlayingScreen.PlayBordered, (b) => {

			}), 2, 0);

			BottomBar.Children.Add (CreateButton (Images.NowPlayingScreen.BottomBar.ShareButton, async (b) => {

				await Task.Delay (toggleDelay);
				b.Toggled = false;
			}));
			BottomBar.Children.Add (CreateButton (Images.NowPlayingScreen.BottomBar.ShuffleButton, (b) => {

			}));
			BottomBar.Children.Add (CreateButton (Images.NowPlayingScreen.BottomBar.RepeatButton, (b) => {

			}));

			BottomBar.Children.Add (CreateButton (Images.NowPlayingScreen.BottomBar.MoreButton, async (b) => {
				//TODO: Show popup
				await Task.Delay (toggleDelay);
				b.Toggled = false;
			}));

		}

		static ImageColorToggleButton CreateButton (FontImageSource source, Action<ToggleButton> action)
		{
			return new ImageColorToggleButton {
				Source = source,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Center,
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
