using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace gMusic.Views {
	public partial class NowPlayingPage : ContentPage {
		public NowPlayingPage ()
		{
			InitializeComponent ();
			ControlsStack.Children.Clear ();
			ControlsStack.Children.Add (CreateButton(Images.NowPlayingScreen.ThumbsDown, (b)=> {

			}));
			ControlsStack.Children.Add (CreateButton (Images.NowPlayingScreen.Previous, (b) => {

			}));
			ControlsStack.Children.Add (CreateButton (Images.NowPlayingScreen.Play, (b) => {

			}));
			ControlsStack.Children.Add (CreateButton (Images.NowPlayingScreen.Next, (b) => {

			}));
			ControlsStack.Children.Add (CreateButton (Images.NowPlayingScreen.ThumbsUp, (b) => {

			}));

		}

		static SvgImageButton CreateButton (ImageSource source, Action<SvgImageButton> action)
		{
			return new SvgImageButton {
				Image = {
					Source = source,
				},
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Center,
				Tapped = action,
			};
		}
	
	}
}
