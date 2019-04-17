using System;
using Xamarin.Forms;
using FormsStyle = Xamarin.Forms.Style;
namespace gMusic {
	public static class FormsStyleExtensions {
		public static void AddGmusicStyles (this ResourceDictionary dictionary)
		{
			Styles.Styles.CurrentStyle.Apply (dictionary);
		}

		public static void Apply(this ResourceDictionary dictionary, StyleHelper style)
		{
			if (string.IsNullOrWhiteSpace (style.Name))
				throw new NotImplementedException ($"Styles require a name to be applied {style}");
			dictionary [style.Name] = (FormsStyle)style;
		}
	}
}
