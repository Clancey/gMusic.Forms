using System;
namespace Xamarin.Forms {
	public class SvgImageFileSource  : ImageSource {
		public SvgImageFileSource ()
		{
		}
		public string SvgName { get; set; }
		public double MaxSize {
			get { return Math.Max (Size.Height, Size.Width); }
			set { Size = new Size (value, value); }
		}
		public Size Size { get; set; }
		//public static implicit operator FileImageSource (SvgImageSource source)
		//{
		//	//TODO: remove this when Xamarin.Forms properly uses the FileImageSourceHandler
		//	//Save to file
		//	return new FileImageSource { File = Images.GetFileCachedImage (source.SvgName, source.MaxSize) };
		//}
	}

}
