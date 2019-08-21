using System;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace gMusic.Views
{
    public class OverflowLabel : ContentView
    {
        public static readonly BindableProperty LabelProperty = BindableProperty.Create(nameof(Label), typeof(Label), typeof(OverflowLabel), new Label(), propertyChanged: (b, o, n) =>
        {
            (b as OverflowLabel)?.OnContentSet(n as Label);
        });
        public Label Label
        {
            get => (Label)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        public OverflowLabel()
        {

            Label = new Label();
            this.HorizontalOptions = LayoutOptions.FillAndExpand;
        }
        void OnContentSet(Label label)
        {
            Content = label;
        }

        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
            if (Label != null)
                return Device.PlatformServices.GetNativeSize(Label, widthConstraint, heightConstraint);
            return base.OnMeasure(widthConstraint, heightConstraint);
        }
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if(!string.IsNullOrWhiteSpace(Label?.Text))
            {
                Console.WriteLine("Hello");
            }
        }

    }
}
