using System;
using System.Threading;
using System.Threading.Tasks;
using gMusic.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportImageSourceHandler (typeof (NGraphicsSVGImageSource), typeof (NGraphicsSVGImageSourceHandler))]
namespace gMusic.iOS.Renderers {
	public class NGraphicsSVGImageSourceHandler : IImageSourceHandler {
		public Task<UIImage> LoadImageAsync (ImageSource imagesource, CancellationToken cancelationToken = default (CancellationToken), float scale = 1)
		{

			var source = imagesource as NGraphicsSVGImageSource;
			if(source == null)
				throw new NotImplementedException ();
			var image = source.SvgName.LoadImageFromSvg(new NGraphics.Size(source.Size.Width,source.Size.Height));
			return Task.FromResult (image);
			//var svgSource = imagesource as SvgImageSource;
			//return Task.FromResult (svgSource.SvgName.LoadImageFromSvg (new NGraphics.Size (svgSource.Size.Width, svgSource.Size.Height)));

		}
	}
}
