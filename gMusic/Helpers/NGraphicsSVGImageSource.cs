using System;
using System.Collections.Generic;
using FFImageLoading.Forms;
using FFImageLoading.Work;

namespace Xamarin.Forms {
	public class NGraphicsSVGImageSource : ImageSource {
		public NGraphicsSVGImageSource ()
		{

		}
		string colorName => TintColor == null ? "" : $"-{TintColor}";
		public string CacheName => $"{SvgName}-{Size.Width}_{Size.Height}{colorName}";
		public string SvgName { get; set; }
		public double MaxSize {
			get { return Math.Max (Size.Height, Size.Width); }
			set { Size = new Size (value, value); }
		}
		public Size Size { get; set; } = new Size (20, 20);
		public Color? TintColor { get; set; }
		//public static implicit operator FileImageSource (SvgImageSource source)
		//{
		//	//TODO: remove this when Xamarin.Forms properly uses the FileImageSourceHandler
		//	//Save to file
		//	return new FileImageSource { File = Images.GetFileCachedImage (source.SvgName, source.MaxSize) };
		//}
	}

}
