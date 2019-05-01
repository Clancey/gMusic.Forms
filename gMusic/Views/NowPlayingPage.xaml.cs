using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace gMusic.Views {
	public partial class NowPlayingPage : ContentPage {
		public NowPlayingPage ()
		{
			InitializeComponent ();
			ControlsStack.Children.Clear ();
			ControlsStack.Children.Add (CreateButton (Images.NowPlayingScreen.ThumbsDown, (b) => {

			}));
			ControlsStack.Children.Add (CreateButton (Images.NowPlayingScreen.Previous, (b) => {

			}));
			ControlsStack.Children.Add (CreateButton (Images.NowPlayingScreen.Pause, Images.NowPlayingScreen.Play, (b) => {

			}));
			ControlsStack.Children.Add (CreateButton (Images.NowPlayingScreen.Next, (b) => {

			}));
			ControlsStack.Children.Add (CreateButton (Images.NowPlayingScreen.ThumbsUp, (b) => {

			}));

			MiniPlayer.Children.Add (CreateButton (Images.NowPlayingScreen.PauseBordered, Images.NowPlayingScreen.PlayBordered, (b) => {

			}),2,0);

		}

		static ToggleButton CreateButton (ImageSource source, Action<ToggleButton> action)
		{
			return new ImageColorToggleButton {
				Source = source,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Center,
				Tapped = action,
			};
		}
		static ToggleButton CreateButton (ImageSource onImage, ImageSource offImage, Action<ToggleButton> action)
		{
			return new ImageToggleButton {
				OnImageSource = onImage,
				OffImageSource = offImage,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Center,
				Tapped = action,
			};
		}

	}
}
