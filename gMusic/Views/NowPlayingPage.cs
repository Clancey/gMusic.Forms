using System;

using Xamarin.Forms;

namespace gMusic.Views
{
    public class NowPlayingPage : ContentPage
    {
        public NowPlayingPage()
        {
            Content = new StackLayout
            {
                BackgroundColor = Color.Blue,
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

