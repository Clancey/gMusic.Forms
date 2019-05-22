using System;
using System.Globalization;
using Xamarin.Forms;

namespace gMusic.Views {
	public class IntDataConvererConverter : IValueConverter {
		public int Value { get; set; }
		public object Convert (object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (int)value == Value;
		}

		public object ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (bool)value ? Value : 0;
		}
	}
	public class ThumbsDownDataConverter : IntDataConvererConverter {
		public ThumbsDownDataConverter()
		{
			Value = 1;
		}
	}
	public class ThumbsUpDataConverter : IntDataConvererConverter {
		public ThumbsUpDataConverter ()
		{
			Value = 5;
		}
}
}
