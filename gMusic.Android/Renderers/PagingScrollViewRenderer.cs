using System;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using System.Reflection;
using gMusic.Views.Controls;
using gMusic.Droid.Renderers;
using Android.Content;

[assembly: Xamarin.Forms.ExportRenderer(typeof(PagingScrollView), typeof(PagingScrollViewRenderer))]
namespace gMusic.Droid.Renderers
{
    public class PagingScrollViewRenderer : ScrollViewRenderer
    {
        public PagingScrollViewRenderer(Context context) : base(context)
        {

        }
        HorizontalScrollView _scrollView;
        HorizontalScrollView scrollView => _scrollView ?? (_scrollView = getScrollView());

        HorizontalScrollView getScrollView()
        {
            var field = typeof(ScrollViewRenderer).GetField("_hScrollView", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            var value = field.GetValue(this);
            return value as HorizontalScrollView;
        }


        public override bool OnTouchEvent(MotionEvent ev)
        {
            if (ev.Action == MotionEventActions.Up)
            {
                //var scroll = (PagingScrollView)this.Element;
                //var totalWidth = scroll.ContentSize.Width;
                //var pageWidth = scroll.Width;
                //var current = scroll.ScrollX;
                //var page = (current + (pageWidth/2)) / pageWidth;
                //var pageInt = (int)page;
                //Console.WriteLine($"Scroll: total:{totalWidth} current:{current} page:{page} pageint:{pageInt}");
                //scroll.ScrollToAsync(pageInt * pageWidth, 0,true);
                var width = scrollView.Width;
                var current = scrollView.ScrollX;
                var page = (current + (width / 2)) / width;
                var pageInt = (int)page;
                scrollView.SmoothScrollTo(pageInt * width, 0);
                return true;
            }
            return base.OnTouchEvent(ev);
        }
    }
}
