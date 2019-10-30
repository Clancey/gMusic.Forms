using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gMusic.Managers;
using gMusic.Models;
using Localizations;
using Xamarin.Forms;

namespace gMusic.Views
{
    public partial class MediaCollectionView : ContentView
    {
        ImageColorToggleButton moreDetailsButton;
        public MediaCollectionView()
        {
            InitializeComponent();
            Image.LoadingPlaceholder = Image.ErrorPlaceholder = Images.DefaultAlbumArt;
            moreDetailsButton = new ImageColorToggleButton
            {
                Source = Images.MoreDetails,
                OnColor = Styles.Styles.CurrentStyle.DisabledColor,
                OffColor = Styles.Styles.CurrentStyle.AccentColor,
                Padding = new Thickness(6),
                Tapped = async (b) => {
                    //TODO Show popup!
                    var item = BindingContext as MediaItemBase;
                    var popupItems = PopupManager.Shared.CreatePopoptions(item);
                    var task = App.Current.MainPage.DisplayActionSheet(item.Name, Strings.Cancel, null, popupItems.Select(x => x.Title).ToArray());
                    await Task.Delay(100);
                    b.Toggled = false;
                    var result = await task;
                    var selectedItem = popupItems.FirstOrDefault(x => x.Title == result);
                    if (selectedItem.Action != null)
                    {
                        var success = await selectedItem.Action();
                    }
                },
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.End
            };


            RootStack.Children.Add(moreDetailsButton);
        }

        protected override void OnBindingContextChanged()
        {
            SubscribeIfNeeded();
            base.OnBindingContextChanged();
            Image.UpdateArtwork(BindingContext as MediaItemBase);

            UpdateLevel();
        }
        bool isSubscribed;
        void SubscribeIfNeeded()
        {
            //TODO: We need to find a way to unsubscribe this puppy.
            if (isSubscribed)
                return;
            isSubscribed = true;
            NotificationManager.Shared.CurrentSongChanged += Shared_CurrentSongChanged;
        }
        

        private void Shared_CurrentSongChanged(object sender, EventArgs<Song> e)
        {
            UpdateLevel();
        }

        void UpdateLevel()
        {
            var song = BindingContext as Song;
            var isVisible = song?.Equals(PlaybackManager.Shared.Player.CurrentSong) ?? false;
            Image.UpdateLevelMeter(isVisible);

        }

        //protected override void OnDisappearing()
        //{
        //    base.OnDisappearing();
        //    NotificationManager.Shared.CurrentSongChanged -= Shared_CurrentSongChanged;
        //}
    }
}
