using System;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using System.Linq;

namespace gMusic.Views {
	public class GradientView : ContentView {
		public GradientView ()
		{
			SKCanvasView canvasView = new SKCanvasView ();
			canvasView.PaintSurface += OnCanvasViewPaintSurface;
			Content = canvasView;
			GradientColors = new [] { gMusicStyle.OrangeColor, gMusicStyle.AccentColor, };
		}

		Color [] colors;
		public Color [] GradientColors {
			get { return colors; }
			set {
				colors = value;
				skColors = colors.Select (c => c.ToSKColor()).ToArray();
			}
		}
		SKColor [] skColors;

		void OnCanvasViewPaintSurface (object sender, SKPaintSurfaceEventArgs args)
		{
			SKImageInfo info = args.Info;
			SKSurface surface = args.Surface;
			SKCanvas canvas = surface.Canvas;

			canvas.Clear ();

			using (SKPaint paint = new SKPaint ()) {
				// Create gradient for background
				paint.Shader = SKShader.CreateLinearGradient (
									new SKPoint (0, 0),
									new SKPoint (info.Width, info.Height),
									skColors,
									null,
									SKShaderTileMode.Clamp);

				canvas.DrawRect (info.Rect, paint);
			}
		}
	}
}

