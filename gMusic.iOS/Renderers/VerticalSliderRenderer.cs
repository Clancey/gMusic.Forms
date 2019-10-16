using System;
using System.ComponentModel;
using CoreGraphics;
using gMusic.iOS.Renderers;
using gMusic.Views;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
[assembly: Xamarin.Forms.ExportRenderer(typeof(VerticalSlider), typeof(VerticalSliderRenderer))]
namespace gMusic.iOS.Renderers
{
    public class VerticalSliderRenderer : SliderRenderer
    {
        public VerticalSliderRenderer()
        {
            

        }

        protected override UISlider CreateNativeControl()
        {
            var slider = base.CreateNativeControl();
            slider.Transform = CGAffineTransform.MakeRotation((float)Math.PI * -.5f);
            return slider;
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (Control == null)
                return;
            Control.Transform = CGAffineTransform.MakeRotation((float)Math.PI * -.5f);
        }

    }
}
