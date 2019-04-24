using System;
using System.Collections.Generic;
using System.IO;
using FFImageLoading.Forms;
using FFImageLoading.Work;

namespace Xamarin.Forms {
	public class NGraphicsSVGImageSource : ImageSource {
		public NGraphicsSVGImageSource ()
		{
		}
		string colorName => TintColor == null ? "" : $"-{TintColor}";
		public string TintReplaceHexColor { get; set; } = "#000000";
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
		public Stream ApplyTint(Stream svgStream)
		{
			//TODO: Figure out why color swap is causing an exception
			//if (!TintColor.HasValue)
				return svgStream;

			var textReader = new StreamReader (svgStream);
			{
				var contents = textReader.ReadToEnd ();
				var replacementColor = TintColor.Value.ToHexString ();
				var newContent = contents.Replace (TintReplaceHexColor, replacementColor);
				var s = new MemoryStream ();
				var sw = new StreamWriter (s);
				sw.Write (newContent);
				s.Position = 0;
				return s;
			}
		}

	}

}
