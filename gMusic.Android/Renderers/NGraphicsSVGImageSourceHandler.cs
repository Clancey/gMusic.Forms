using System;
using System.Threading;
using System.Threading.Tasks;
using Android;
using Android.Content;
using Android.Graphics;
using gMusic.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportImageSourceHandler (typeof (NGraphicsSVGImageSource), typeof (NGraphicsSVGImageSourceHandler))]
namespace gMusic.Droid.Renderers {
	public class NGraphicsSVGImageSourceHandler : IImageSourceHandler {

		public Task<Bitmap> LoadImageAsync (ImageSource imagesource, Context context, CancellationToken cancelationToken = default)
		{
			var source = imagesource as NGraphicsSVGImageSource;
			if (source == null)
				throw new NotImplementedException ();
			var image = source.SvgName.LoadImageFromSvg (new NGraphics.Size (source.Size.Width, source.Size.Height));
			return Task.FromResult (image);
		}
	}
}
