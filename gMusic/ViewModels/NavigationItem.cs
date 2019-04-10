using System;
using Xamarin.Forms;
using FFImageLoading.Svg.Forms;
namespace gMusic.ViewModels
{
    public class NavigationItem
    {
        public ImageSource Image { get; set; }

        public string Title { get; set; }

        public Page Page { get; set; }

        public bool HasImage => Image != null;

		public Style LabelStyle => Page == null ? FormsStyleExtensions.MenuHeaderLabelStyle : FormsStyleExtensions.MenuLabelStyle;
    }
}
