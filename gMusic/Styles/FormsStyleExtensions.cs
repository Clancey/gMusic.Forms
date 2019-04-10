using System;
using Xamarin.Forms;
using FormsStyle = Xamarin.Forms.Style;
namespace gMusic {
	public static class FormsStyleExtensions {
		public static void AddGmusicStyles(this ResourceDictionary dictionary)
		{
			dictionary [nameof (MainTextLableStyle)] = MainTextLableStyle;
			dictionary [nameof (MenuHeaderLabelStyle)] = MainTextLableStyle;
			dictionary [nameof (MenuLabelStyle)] = MenuLabelStyle;
		}

		static Styles.Style CurrentStyle => Styles.Style.CurrentStyle;
		static FormsStyle MainTextLableStyle => CreateLabelStyle (CurrentStyle.MainTextFont, CurrentStyle.MainTextColor);
		public static FormsStyle CreateLabelStyle(Font font, Color color) => new FormsStyle(typeof(Label)) {
			Setters = {
				new Setter{ Property = Label.FontProperty, Value = font },
				new Setter{ Property = Label.TextColorProperty, Value = color},
			}
		};

		public static FormsStyle MenuHeaderLabelStyle => CreateLabelStyle (CurrentStyle.HeaderTextThinFont, CurrentStyle.MenuTextColor);
		public static FormsStyle MenuLabelStyle => CreateLabelStyle (CurrentStyle.MenuTextFont, CurrentStyle.MenuTextColor);

	}
}
