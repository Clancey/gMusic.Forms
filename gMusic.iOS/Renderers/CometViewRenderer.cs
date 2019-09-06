using System;
using Comet.iOS;
using gMusic.iOS.Renderers;
using gMusic.Views.Controls;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using CView = Comet.View;
using GCometView = gMusic.Views.Controls.CometView;

[assembly: ExportRenderer(typeof(GCometView), typeof(CometViewRenderer))]
namespace gMusic.iOS.Renderers
{
    public class CometViewRenderer : ViewRenderer<GCometView, UIView>
    {
        Comet.iOS.CometView cometView;
        public CometViewRenderer()
        {
            Add(cometView = new Comet.iOS.CometView());
        }
        protected override void OnElementChanged(ElementChangedEventArgs<GCometView> e)
        {
            base.OnElementChanged(e);
            cometView.CurrentView = (e.NewElement as GCometView)?.View;
        }
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            cometView.Frame = Bounds;
        }
        protected override void Dispose(bool disposing)
        {
            cometView?.Dispose();
            base.Dispose(disposing);
        }

    }
}
