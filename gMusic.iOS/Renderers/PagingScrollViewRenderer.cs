using System;
using gMusic.iOS.Renderers;
using gMusic.Views.Controls;
using Xamarin.Forms.Platform.iOS;
[assembly: Xamarin.Forms.ExportRenderer(typeof(PagingScrollView), typeof(PagingScrollViewRenderer ))]
namespace gMusic.iOS.Renderers
{
    public class PagingScrollViewRenderer : ScrollViewRenderer
    {
        public PagingScrollViewRenderer()
        {
            this.PagingEnabled = true;
        }
    }
}
