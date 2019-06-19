using System;
using System.Collections.Generic;
using System.Linq;
using gMusic.Data;
using gMusic.Managers;
using Xamarin.Forms;

namespace gMusic.Styles {
	public class Styles {

		static Styles currentStyle;
		public static Styles CurrentStyle {
			get { return currentStyle; }
			set {
				if (currentStyle == value)
					return;
				Settings.CurrentStyle = value.Id;
				currentStyle = value;
				NotificationManager.Shared.ProcStyleChanged ();
			}
		}
		public static int HeaderFontSize = 28;
		public static int MainTextFontSize = 15;
		public static int DetailFontSize = 12;
		public static int ButtonFontsize = 12;

		static Styles ()
		{
			AvailableStyles = new List<Styles>
			{
				new Styles(),
				new DarkStyle(),
			};

			CurrentStyle = AvailableStyles.FirstOrDefault (x => x.Id == Settings.CurrentStyle) ?? AvailableStyles [0];

			//UIApplication.SharedApplication.StatusBarStyle = currentStyle.StatusBarColor;
			
		}

		public void Apply(App app)
		{
			Apply (app.Resources);
		}

		public void Apply(Page page)
		{
			Apply (page.Resources);
		}

		public void Apply(ResourceDictionary resource)
		{
			resource.Apply (MainTextLableStyle);
			resource.Apply (SubTextLableStyle);
			resource.Apply (MenuHeaderLabelStyle);
			resource.Apply (MenuLabelStyle);
			resource [nameof (BackgroundColor)] = BackgroundColor;

		}


		public static Styles DefaultStyle => AvailableStyles [0];
		public string Id { get; set; } = "Default";

		public static List<Styles> AvailableStyles { get; private set; }


		public static bool IsDeviceDark { get; set; }
		public Color AccentSolidColor { get; set; } = Color.FromRgb (255, 43, 103);
		public Color AccentColor => AccentSolidColor;
		public Color DisabledColor => Color.LightGray;


		Font? headerTextFont;
		public Font HeaderTextFont {
			get => headerTextFont ?? (headerTextFont = Fonts.NormalFont (HeaderFontSize)).Value;
			set => headerTextFont = value;
		}

		Font? headerTextThinFont;
		public Font HeaderTextThinFont
			{
			get => headerTextThinFont ?? (headerTextThinFont = Fonts.ThinFont (HeaderFontSize)).Value;
			set => headerTextThinFont = value;
		}

		//public UIStatusBarStyle StatusBarColor { get; set; } = UIStatusBarStyle.Default;

		Color? headerTextColor;
		public Color HeaderTextColor {
			get { return headerTextColor ?? (headerTextColor = AccentColor).Value; }
			set { headerTextColor = value; }
		}

		LabelStyle mainTextLableStyle;
		public LabelStyle MainTextLableStyle {
			get => mainTextLableStyle ?? (mainTextLableStyle = new LabelStyle {
				Name = nameof(MainTextLableStyle),
				Font = MainTextFont,
				TextColor =  MainTextColor,
				FontSize = MainTextFontSize,
			});
			set => mainTextLableStyle = value;
		}

		LabelStyle subTextLableStyle;
		public LabelStyle SubTextLableStyle {
			get => subTextLableStyle ?? (subTextLableStyle = new LabelStyle {
				Name = nameof (SubTextLableStyle),
				Font = SubTextFont,
				TextColor = SubTextColor,
				FontSize = DetailFontSize,
			});
			set => subTextLableStyle = value;
		}


		LabelStyle menuHeaderLabelStyle;
		public LabelStyle MenuHeaderLabelStyle {
			get => menuHeaderLabelStyle ?? (menuHeaderLabelStyle = new LabelStyle {
				Name = nameof (MenuHeaderLabelStyle),
				Font = HeaderTextThinFont,
				TextColor = MenuTextColor,
				FontSize = HeaderFontSize,
			});
			set => menuHeaderLabelStyle = value;
		}

		LabelStyle menuLabelStyle;
		public LabelStyle MenuLabelStyle {
			get => menuLabelStyle ?? (menuLabelStyle = new LabelStyle {
				Name = nameof (MenuLabelStyle),
				Font = MenuTextFont,
				TextColor = MenuTextColor,
				FontSize = HeaderFontSize,
			});
			set => menuLabelStyle = value;
		}

		public static void ResetAllFonts()
		{
			AvailableStyles.ForEach (x => x.ResetFonts ());
			NotificationManager.Shared.ProcStyleChanged ();
		}
		public virtual void ResetFonts()
		{
			mainTextFont = null;
			buttonTextFont = null;
			subTextFont = null;
			headerTextFont = null;

			//Labels
			menuLabelStyle = null;
			menuHeaderLabelStyle = null;
			mainTextLableStyle = null;
			subTextLableStyle = null;
		}

		Font? mainTextFont;
		public Font MainTextFont {
			get => mainTextFont ?? (mainTextFont = Fonts.NormalFont (MainTextFontSize)).Value;
			set => mainTextFont = value;
		}

		public Color MainTextColor { get; set; } = Color.Black;

		//TODO: Fix button font sizes
		Font? buttonTextFont;
		public Font ButtonTextFont {
			get => buttonTextFont ?? (buttonTextFont = Fonts.NormalFont (ButtonFontsize)).Value;
			set => buttonTextFont = value;
		}

		Font? subTextFont;
		public Font SubTextFont {
			get => subTextFont ?? (subTextFont = Fonts.NormalFont (DetailFontSize)).Value;
			set => subTextFont = value;
		}
		public Color SubTextColor { get; set; } = Color.DarkGray;

		Font? menuTextFont;
		public Font MenuTextFont {
			get => menuTextFont ?? (menuTextFont = Fonts.NormalFont (MainTextFontSize)).Value;
			set => menuTextFont = value;
		}

		public Color MenuTextColor { get; set; } = Color.White;
		public Color MenuAccentColor { get; set; } = Color.White;

		public Color BackgroundColor { get; set; } = Color.White;
		public Color SectionBackgroundColor { get; set; } = Color.White;
		//public UIBarStyle BarStyle { get; set; } = UIBarStyle.Default;
		//public UIBlurEffectStyle BlurStyle { get; set; } = UIBlurEffectStyle.ExtraLight;
		public Color PlaybackControlTint { get; set; } = Color.Black;
	}

	public class DarkStyle : Styles {
		public DarkStyle ()
		{
			Id = "Dark Theme";
			this.BackgroundColor = Color.FromRgb (39, 40, 34);
			this.SectionBackgroundColor = Color.FromRgba (84, 84, 84, 100);
			this.SubTextColor = Color.LightGray;
			this.MainTextColor = Color.White;
			//this.BarStyle = UIBarStyle.BlackTranslucent;
			//this.BlurStyle = UIBlurEffectStyle.Dark;
			this.PlaybackControlTint = Color.White;
			//StatusBarColor = UIStatusBarStyle.LightContent;
		}
	}

	public static class StyleExtensions {
		public static Styles GetStyle (this View view)
		{
			return Styles.CurrentStyle;
		}
		//public static Style GetStyle (this App window)
		//{
		//	Style style;
		//	Style.Styles.TryGetValue (window?.Tag ?? 0, out style);
		//	return style ?? Style.DefaultStyle;
		//}
		public static T StyleAsMainText<T> (this T label) where T : Label
		{
			var style = label.GetStyle ();
			label.StyleAsMainText (style);
			return label;
		}

		public static T StyleAsMainText<T> (this T label, Styles style) where T : Label
		{
			label.FontFamily = style.MainTextFont.FontFamily;
			label.FontSize = style.MainTextFont.FontSize;
			//label.Font = style.MainTextFont;
			//Console.WriteLine($"{style.Id} {label.Font.PointSize}");
			label.TextColor = style.MainTextColor;
			return label;
		}


		public static T StyleAsSubText<T> (this T label) where T : Label
		{
			var style = label.GetStyle ();
			label.StyleAsSubText (style);
			return label;
		}

		public static T StyleAsSubText<T> (this T label, Styles style) where T : Label
		{
			label.FontFamily = style.MainTextFont.FontFamily;
			label.FontSize = style.MainTextFont.FontSize;
			label.TextColor = style.SubTextColor;
			return label;
		}

		//public static T StylePlaybackControl<T> (this T button) where T : Button
		//{
		//	var style = button.GetStyle ();
		//	//button.TintColor = style.AccentColor;
		//	button.textc
		//	button.Layer.ShadowColor = style.AccentColor.CGColor;
		//	button.Layer.ShadowRadius = 10f;
		//	button.Layer.ShadowOpacity = .75f;
		//	return button;
		//}


		//public static T StyleNowPlayingButtons<T> (this T button) where T : Button
		//{
		//	var style = button.GetStyle ();
		//	button.TintColor = style.PlaybackControlTint;
		//	return button;
		//}


		//public static T StyleActivatedButton<T> (this T button, bool activated) where T : Button
		//{
		//	var style = button.GetStyle ();
		//	button.TintColor = activated ? style.AccentColor : style.PlaybackControlTint;
		//	return button;
		//}

		//public static T StyleAsMenuElement<T> (this T cell) where T : TextCell
		//{
		//	var style = cell.GetStyle ();
		//	cell.TextLabel.Font = style.MenuTextFont;
		//	cell.TextLabel.TextColor = style.MenuTextColor;
		//	cell.TintColor = style.MenuAccentColor;
		//	if (cell.DetailTextLabel != null) {
		//		cell.DetailTextLabel.TextColor = style.MenuTextColor;
		//		cell.DetailTextLabel.Font = style.SubTextFont;
		//	}
		//	cell.BackgroundColor = Color.Clear;
		//	return cell;
		//}
		//public static T StyleAsMenuHeaderElement<T> (this T cell) where T : TextCell
		//{
		//	var style = cell.GetStyle ();
		//	cell.TextLabel.Font = style.HeaderTextThinFont;
		//	cell.TextLabel.TextColor = style.MenuTextColor;
		//	cell.TintColor = style.MenuAccentColor;
		//	cell.BackgroundColor = Color.Clear;
		//	return cell;
		//}

		//public static T StyleSwitch<T> (this T sw) where T : Switch
		//{
		//	var style = sw.GetStyle ();
		//	var color = style.AccentColor; // Color.FromPatternImage(image);
		//								   //sw.TintColor = color;
		//	sw.OnTintColor = color;
		//	//			sw.ThumbTintColor = style.Equalizer.SwitchOnThumbColor.Value;
		//	sw.BackgroundColor = Color.DarkGray;
		//	sw.Layer.CornerRadius = 16;
		//	return sw;
		//}

		//public static T StyleAsBorderedButton<T> (this T button) where T : Button
		//{
		//	//var style = button.GetStyle();
		//	var color = Color.White;
		//	button.SetTitleColor (color, UIControlState.Normal);
		//	button.Layer.BorderColor = color.CGColor;
		//	button.Layer.CornerRadius = 5;
		//	button.Layer.BorderWidth = .5f;


		//	return button;
		//}

		//public static T StyleAsTextButton<T> (this T button) where T : Button
		//{
		//	//var style = button.GetStyle();
		//	var color = Color.White;
		//	button.SetTitleColor (color, UIControlState.Normal);

		//	return button;
		//}


		//public static T StyleSectionHeader<T> (this T header) where T : UITableViewHeaderFooterView
		//{
		//	var style = header.GetStyle ();
		//	header.TextLabel.TextColor = style.MainTextColor;
		//	header.BackgroundView.BackgroundColor = style.SectionBackgroundColor;
		//	return header;
		//}

		//public static T StyleViewController<T> (this T vc) where T : UIViewController
		//{
		//	var style = vc.View.GetStyle ();
		//	if (vc.NavigationController != null)
		//		vc.NavigationController.NavigationBar.BarStyle = style.BarStyle;
		//	vc.View.BackgroundColor = style.BackgroundColor;
		//	return vc;
		//}

		//internal static T StyleBlurView<T> (this T blurView) where T : BluredView
		//{
		//	var style = blurView.GetStyle ();
		//	blurView.UpdateStyle (style.BlurStyle);
		//	return blurView;
		//}

		//internal static T StyleBlurredImageView<T> (this T blurView) where T : BlurredImageView
		//{
		//	var style = blurView.GetStyle ();
		//	blurView.UpdateStyle (style.BlurStyle);
		//	return blurView;
		//}

	}
}
