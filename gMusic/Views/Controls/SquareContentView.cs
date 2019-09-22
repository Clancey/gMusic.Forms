using System;
using System.Linq;
using System.Threading.Tasks;
using gMusic.Managers;
using gMusic.Models;
using Localizations;
using Xamarin.Forms;

namespace gMusic.Views.Controls
{
    public class SquareContentView : AbsoluteLayout
    {
        AlbumArtView artView;
        BlurView blurView;
        Grid grid;
        public SquareContentView(Album album)
        {
            artView = new AlbumArtView
            {
                BindingContext = album
            };
            artView.UpdateArtwork(album);
            Children.Add(artView);

            blurView = new BlurView();
            Children.Add(blurView);

            grid = new Grid
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition(),
                    new ColumnDefinition{Width = 30 },
                },
                Children =
                {
                    new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal, 
                        Children = {
                            new Image{Source = Images.Menu.SongsIcon},
                            new Label{Text = $"{album.TrackCount} {Strings.Songs}"}
                        },
                    },
                    new ImageColorToggleButton {
                        Source = Images.MoreDetails,
                        OnColor = Styles.Styles.CurrentStyle.DisabledColor,
                        OffColor = Styles.Styles.CurrentStyle.AccentColor,
                        Padding = new Thickness(6),
                        Tapped = async (b) => {
					        var item = album;
                            var popupItems = PopupManager.Shared.CreatePopoptions (item);
                            var task = App.Current.MainPage.DisplayActionSheet (item.Name, Strings.Cancel, null, popupItems.Select (x => x.Title).ToArray ());
                            await Task.Delay (100);
                            b.Toggled = false;
                            var result = await task;
                            var selectedItem = popupItems.FirstOrDefault (x => x.Title == result);
                            if (selectedItem.Action != null) {
                                var success = await selectedItem.Action();
                            }
                        }
                    }.SetColumn(1),
                },
            };
            Children.Add(grid);

        }
        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
            return new SizeRequest(new Size(widthConstraint, widthConstraint), new Size(widthConstraint, widthConstraint));
            //return base.OnMeasure(widthConstraint, heightConstraint);
        }
        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            artView.Layout(new Rectangle(x, y, width, height));
            var blurHeight = 30;
            var rect = new Rectangle(x, height - blurHeight - y, width, blurHeight);
            blurView.Layout(rect);
            grid.Layout(rect);
        }
    }
}

