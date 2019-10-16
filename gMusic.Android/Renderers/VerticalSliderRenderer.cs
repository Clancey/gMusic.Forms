using System;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Android.Content;
using gMusic.Droid.Renderers;
using gMusic.Views;
using Xamarin.Forms;
using Android.OS;
using Android.Views;

[assembly: Xamarin.Forms.ExportRenderer(typeof(VerticalSlider), typeof(VerticalSliderRenderer))]
namespace gMusic.Droid.Renderers
{
    public class VerticalSliderRenderer : SliderRenderer
    {
        public VerticalSliderRenderer(Context context) : base(context)
        {

        }

        protected override SeekBar CreateNativeControl()
        {
            var seekBar = base.CreateNativeControl();
            seekBar.Rotation = -90;
            return seekBar;
        }
        public override SizeRequest GetDesiredSize(int widthConstraint, int heightConstraint)
        {
            var size = base.GetDesiredSize(widthConstraint, heightConstraint);
            size.Request = new Size(size.Request.Height, size.Request.Width);
            size.Minimum = size.Request;
            return size;
        }
    }
}