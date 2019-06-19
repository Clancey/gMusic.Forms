using System;
using System.Collections.Generic;
using Xamarin.Forms;
using gMusic.Models;
using gMusic.Styles;
using System.Threading.Tasks;
using gMusic.Managers;
using Localizations;
using System.Linq;

namespace gMusic.Views
{
    public partial class MediaItemCell : ViewCell
    {
		ImageColorToggleButton moreDetailsButton;
        public MediaItemCell()
        {
            InitializeComponent();
			//Text.StyleAsMainText ();
			//Detail.StyleAsSubText ();
            Image.LoadingPlaceholder = Image.ErrorPlaceholder = Images.DefaultAlbumArt;
			moreDetailsButton = new ImageColorToggleButton {
				Source = Images.MoreDetails,
				OnColor = Styles.Styles.CurrentStyle.DisabledColor,
				OffColor = Styles.Styles.CurrentStyle.AccentColor,
				Padding = new Thickness(6),
				Tapped = async (b) => {
					//TODO Show popup!
					var item = BindingContext as MediaItemBase;
					var popupItems = PopupManager.Shared.CreatePopoptions (item);
					var task = App.Current.MainPage.DisplayActionSheet (item.Name, Strings.Cancel, null, popupItems.Select (x => x.Title).ToArray ());
					await Task.Delay (100);
					b.Toggled = false;
					var result = await task;
					var selectedItem = popupItems.FirstOrDefault (x => x.Title == result);
					if (selectedItem.Action != null) {
						var success = await selectedItem.Action();
					}
				},
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.End
			};


			RootStack.Children.Add (moreDetailsButton);
        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            UpdateArtwork(BindingContext as MediaItemBase);
        }

        async void UpdateArtwork(MediaItemBase item)
        {
            if (item == null)
                return;
            var urlTask = item.GetArtworkUrl();
            if (!urlTask.IsCompleted)
                Image.Source = Images.DefaultAlbumArt;
            var url = await urlTask;
            if (item != BindingContext)
                return;
			if (string.IsNullOrWhiteSpace (url))
				return;
            Image.Source = new UriImageSource { Uri = new Uri(url) };
        }
    }
}
