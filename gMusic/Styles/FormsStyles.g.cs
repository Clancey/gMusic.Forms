using System;
using System.Collections.Generic;
using System.Linq;

namespace Xamarin.Forms {

	public class VisualElementStyle : StyleHelper {
		public VisualElementStyle () { Type = typeof (VisualElement); }
		public Xamarin.Forms.INavigation Navigation {
			get => GetValue<Xamarin.Forms.INavigation> (VisualElement.NavigationProperty);
			set => SetValue (VisualElement.NavigationProperty, value);
		}
		public Xamarin.Forms.Style Style {
			get => GetValue<Xamarin.Forms.Style> (VisualElement.StyleProperty);
			set => SetValue (VisualElement.StyleProperty, value);
		}
		public bool InputTransparent {
			get => GetValue<bool> (VisualElement.InputTransparentProperty);
			set => SetValue (VisualElement.InputTransparentProperty, value);
		}
		public bool IsEnabled {
			get => GetValue<bool> (VisualElement.IsEnabledProperty);
			set => SetValue (VisualElement.IsEnabledProperty, value);
		}
		public double X {
			get => GetValue<double> (VisualElement.XProperty);
			set => SetValue (VisualElement.XProperty, value);
		}
		public double Y {
			get => GetValue<double> (VisualElement.YProperty);
			set => SetValue (VisualElement.YProperty, value);
		}
		public double AnchorX {
			get => GetValue<double> (VisualElement.AnchorXProperty);
			set => SetValue (VisualElement.AnchorXProperty, value);
		}
		public double AnchorY {
			get => GetValue<double> (VisualElement.AnchorYProperty);
			set => SetValue (VisualElement.AnchorYProperty, value);
		}
		public double TranslationX {
			get => GetValue<double> (VisualElement.TranslationXProperty);
			set => SetValue (VisualElement.TranslationXProperty, value);
		}
		public double TranslationY {
			get => GetValue<double> (VisualElement.TranslationYProperty);
			set => SetValue (VisualElement.TranslationYProperty, value);
		}
		public double Width {
			get => GetValue<double> (VisualElement.WidthProperty);
			set => SetValue (VisualElement.WidthProperty, value);
		}
		public double Height {
			get => GetValue<double> (VisualElement.HeightProperty);
			set => SetValue (VisualElement.HeightProperty, value);
		}
		public double Rotation {
			get => GetValue<double> (VisualElement.RotationProperty);
			set => SetValue (VisualElement.RotationProperty, value);
		}
		public double RotationX {
			get => GetValue<double> (VisualElement.RotationXProperty);
			set => SetValue (VisualElement.RotationXProperty, value);
		}
		public double RotationY {
			get => GetValue<double> (VisualElement.RotationYProperty);
			set => SetValue (VisualElement.RotationYProperty, value);
		}
		public double Scale {
			get => GetValue<double> (VisualElement.ScaleProperty);
			set => SetValue (VisualElement.ScaleProperty, value);
		}
		public double ScaleX {
			get => GetValue<double> (VisualElement.ScaleXProperty);
			set => SetValue (VisualElement.ScaleXProperty, value);
		}
		public double ScaleY {
			get => GetValue<double> (VisualElement.ScaleYProperty);
			set => SetValue (VisualElement.ScaleYProperty, value);
		}
		public Xamarin.Forms.IVisual Visual {
			get => GetValue<Xamarin.Forms.IVisual> (VisualElement.VisualProperty);
			set => SetValue (VisualElement.VisualProperty, value);
		}
		public bool IsVisible {
			get => GetValue<bool> (VisualElement.IsVisibleProperty);
			set => SetValue (VisualElement.IsVisibleProperty, value);
		}
		public double Opacity {
			get => GetValue<double> (VisualElement.OpacityProperty);
			set => SetValue (VisualElement.OpacityProperty, value);
		}
		public Xamarin.Forms.Color BackgroundColor {
			get => GetValue<Xamarin.Forms.Color> (VisualElement.BackgroundColorProperty);
			set => SetValue (VisualElement.BackgroundColorProperty, value);
		}
		public double WidthRequest {
			get => GetValue<double> (VisualElement.WidthRequestProperty);
			set => SetValue (VisualElement.WidthRequestProperty, value);
		}
		public double HeightRequest {
			get => GetValue<double> (VisualElement.HeightRequestProperty);
			set => SetValue (VisualElement.HeightRequestProperty, value);
		}
		public double MinimumWidthRequest {
			get => GetValue<double> (VisualElement.MinimumWidthRequestProperty);
			set => SetValue (VisualElement.MinimumWidthRequestProperty, value);
		}
		public double MinimumHeightRequest {
			get => GetValue<double> (VisualElement.MinimumHeightRequestProperty);
			set => SetValue (VisualElement.MinimumHeightRequestProperty, value);
		}
		public bool IsFocused {
			get => GetValue<bool> (VisualElement.IsFocusedProperty);
			set => SetValue (VisualElement.IsFocusedProperty, value);
		}
		public Xamarin.Forms.FlowDirection FlowDirection {
			get => GetValue<Xamarin.Forms.FlowDirection> (VisualElement.FlowDirectionProperty);
			set => SetValue (VisualElement.FlowDirectionProperty, value);
		}
		public int TabIndex {
			get => GetValue<int> (VisualElement.TabIndexProperty);
			set => SetValue (VisualElement.TabIndexProperty, value);
		}
		public bool IsTabStop {
			get => GetValue<bool> (VisualElement.IsTabStopProperty);
			set => SetValue (VisualElement.IsTabStopProperty, value);
		}
	}
	public class ActivityIndicatorStyle : ViewStyle {
		public ActivityIndicatorStyle () { Type = typeof (ActivityIndicator); }
		public bool IsRunning {
			get => GetValue<bool> (ActivityIndicator.IsRunningProperty);
			set => SetValue (ActivityIndicator.IsRunningProperty, value);
		}
		public Xamarin.Forms.Color Color {
			get => GetValue<Xamarin.Forms.Color> (ActivityIndicator.ColorProperty);
			set => SetValue (ActivityIndicator.ColorProperty, value);
		}
	}
	public class BoxViewStyle : ViewStyle {
		public BoxViewStyle () { Type = typeof (BoxView); }
		public Xamarin.Forms.Color Color {
			get => GetValue<Xamarin.Forms.Color> (BoxView.ColorProperty);
			set => SetValue (BoxView.ColorProperty, value);
		}
		public Xamarin.Forms.CornerRadius CornerRadius {
			get => GetValue<Xamarin.Forms.CornerRadius> (BoxView.CornerRadiusProperty);
			set => SetValue (BoxView.CornerRadiusProperty, value);
		}
	}
	public class ButtonStyle : ViewStyle {
		public ButtonStyle () { Type = typeof (Button); }
		public System.Windows.Input.ICommand Command {
			get => GetValue<System.Windows.Input.ICommand> (Button.CommandProperty);
			set => SetValue (Button.CommandProperty, value);
		}
		public System.Object CommandParameter {
			get => GetValue<System.Object> (Button.CommandParameterProperty);
			set => SetValue (Button.CommandParameterProperty, value);
		}

		public System.String Text {
			get => GetValue<System.String> (Button.TextProperty);
			set => SetValue (Button.TextProperty, value);
		}
		public Xamarin.Forms.Color TextColor {
			get => GetValue<Xamarin.Forms.Color> (Button.TextColorProperty);
			set => SetValue (Button.TextColorProperty, value);
		}
		public Xamarin.Forms.Font Font {
			get => GetValue<Xamarin.Forms.Font> (Button.FontProperty);
			set => SetValue (Button.FontProperty, value);
		}
		public System.String FontFamily {
			get => GetValue<System.String> (Button.FontFamilyProperty);
			set => SetValue (Button.FontFamilyProperty, value);
		}
		public double FontSize {
			get => GetValue<double> (Button.FontSizeProperty);
			set => SetValue (Button.FontSizeProperty, value);
		}
		public Xamarin.Forms.FontAttributes FontAttributes {
			get => GetValue<Xamarin.Forms.FontAttributes> (Button.FontAttributesProperty);
			set => SetValue (Button.FontAttributesProperty, value);
		}
		public double BorderWidth {
			get => GetValue<double> (Button.BorderWidthProperty);
			set => SetValue (Button.BorderWidthProperty, value);
		}
		public Xamarin.Forms.Color BorderColor {
			get => GetValue<Xamarin.Forms.Color> (Button.BorderColorProperty);
			set => SetValue (Button.BorderColorProperty, value);
		}
		public int BorderRadius {
			get => GetValue<int> (Button.BorderRadiusProperty);
			set => SetValue (Button.BorderRadiusProperty, value);
		}
		public int CornerRadius {
			get => GetValue<int> (Button.CornerRadiusProperty);
			set => SetValue (Button.CornerRadiusProperty, value);
		}
		public Xamarin.Forms.FileImageSource Image {
			get => GetValue<Xamarin.Forms.FileImageSource> (Button.ImageProperty);
			set => SetValue (Button.ImageProperty, value);
		}
		public Xamarin.Forms.Thickness Padding {
			get => GetValue<Xamarin.Forms.Thickness> (Button.PaddingProperty);
			set => SetValue (Button.PaddingProperty, value);
		}
		public bool IsPressed {
			get => GetValue<bool> (Button.IsPressedProperty);
			set => SetValue (Button.IsPressedProperty, value);
		}
	}
	public class ContentPageStyle : TemplatedPageStyle {
		public ContentPageStyle () { Type = typeof (ContentPage); }
		public Xamarin.Forms.View Content {
			get => GetValue<Xamarin.Forms.View> (ContentPage.ContentProperty);
			set => SetValue (ContentPage.ContentProperty, value);
		}
	}
	public class ContentPresenterStyle : LayoutStyle {
		public ContentPresenterStyle () { Type = typeof (ContentPresenter); }
		public Xamarin.Forms.View Content {
			get => GetValue<Xamarin.Forms.View> (ContentPresenter.ContentProperty);
			set => SetValue (ContentPresenter.ContentProperty, value);
		}
	}
	public class ContentViewStyle : TemplatedViewStyle {
		public ContentViewStyle () { Type = typeof (ContentView); }
		public Xamarin.Forms.View Content {
			get => GetValue<Xamarin.Forms.View> (ContentView.ContentProperty);
			set => SetValue (ContentView.ContentProperty, value);
		}
	}
	public class DatePickerStyle : ViewStyle {
		public DatePickerStyle () { Type = typeof (DatePicker); }
		public System.String Format {
			get => GetValue<System.String> (DatePicker.FormatProperty);
			set => SetValue (DatePicker.FormatProperty, value);
		}
		public System.DateTime Date {
			get => GetValue<System.DateTime> (DatePicker.DateProperty);
			set => SetValue (DatePicker.DateProperty, value);
		}
		public System.DateTime MinimumDate {
			get => GetValue<System.DateTime> (DatePicker.MinimumDateProperty);
			set => SetValue (DatePicker.MinimumDateProperty, value);
		}
		public System.DateTime MaximumDate {
			get => GetValue<System.DateTime> (DatePicker.MaximumDateProperty);
			set => SetValue (DatePicker.MaximumDateProperty, value);
		}
		public Xamarin.Forms.Color TextColor {
			get => GetValue<Xamarin.Forms.Color> (DatePicker.TextColorProperty);
			set => SetValue (DatePicker.TextColorProperty, value);
		}
		public System.String FontFamily {
			get => GetValue<System.String> (DatePicker.FontFamilyProperty);
			set => SetValue (DatePicker.FontFamilyProperty, value);
		}
		public double FontSize {
			get => GetValue<double> (DatePicker.FontSizeProperty);
			set => SetValue (DatePicker.FontSizeProperty, value);
		}
		public Xamarin.Forms.FontAttributes FontAttributes {
			get => GetValue<Xamarin.Forms.FontAttributes> (DatePicker.FontAttributesProperty);
			set => SetValue (DatePicker.FontAttributesProperty, value);
		}
	}
	public class EditorStyle : InputViewStyle {
		public EditorStyle () { Type = typeof (Editor); }
		public System.String Text {
			get => GetValue<System.String> (Editor.TextProperty);
			set => SetValue (Editor.TextProperty, value);
		}
		public System.String FontFamily {
			get => GetValue<System.String> (Editor.FontFamilyProperty);
			set => SetValue (Editor.FontFamilyProperty, value);
		}
		public double FontSize {
			get => GetValue<double> (Editor.FontSizeProperty);
			set => SetValue (Editor.FontSizeProperty, value);
		}
		public Xamarin.Forms.FontAttributes FontAttributes {
			get => GetValue<Xamarin.Forms.FontAttributes> (Editor.FontAttributesProperty);
			set => SetValue (Editor.FontAttributesProperty, value);
		}
		public Xamarin.Forms.Color TextColor {
			get => GetValue<Xamarin.Forms.Color> (Editor.TextColorProperty);
			set => SetValue (Editor.TextColorProperty, value);
		}
		public System.String Placeholder {
			get => GetValue<System.String> (Editor.PlaceholderProperty);
			set => SetValue (Editor.PlaceholderProperty, value);
		}
		public Xamarin.Forms.Color PlaceholderColor {
			get => GetValue<Xamarin.Forms.Color> (Editor.PlaceholderColorProperty);
			set => SetValue (Editor.PlaceholderColorProperty, value);
		}
		public bool IsTextPredictionEnabled {
			get => GetValue<bool> (Editor.IsTextPredictionEnabledProperty);
			set => SetValue (Editor.IsTextPredictionEnabledProperty, value);
		}
		public Xamarin.Forms.EditorAutoSizeOption AutoSize {
			get => GetValue<Xamarin.Forms.EditorAutoSizeOption> (Editor.AutoSizeProperty);
			set => SetValue (Editor.AutoSizeProperty, value);
		}
	}
	public class EntryStyle : InputViewStyle {
		public EntryStyle () { Type = typeof (Entry); }
		public Xamarin.Forms.ReturnType ReturnType {
			get => GetValue<Xamarin.Forms.ReturnType> (Entry.ReturnTypeProperty);
			set => SetValue (Entry.ReturnTypeProperty, value);
		}
		public System.Windows.Input.ICommand ReturnCommand {
			get => GetValue<System.Windows.Input.ICommand> (Entry.ReturnCommandProperty);
			set => SetValue (Entry.ReturnCommandProperty, value);
		}
		public System.Object ReturnCommandParameter {
			get => GetValue<System.Object> (Entry.ReturnCommandParameterProperty);
			set => SetValue (Entry.ReturnCommandParameterProperty, value);
		}
		public System.String Placeholder {
			get => GetValue<System.String> (Entry.PlaceholderProperty);
			set => SetValue (Entry.PlaceholderProperty, value);
		}
		public Xamarin.Forms.Color PlaceholderColor {
			get => GetValue<Xamarin.Forms.Color> (Entry.PlaceholderColorProperty);
			set => SetValue (Entry.PlaceholderColorProperty, value);
		}
		public bool IsPassword {
			get => GetValue<bool> (Entry.IsPasswordProperty);
			set => SetValue (Entry.IsPasswordProperty, value);
		}
		public System.String Text {
			get => GetValue<System.String> (Entry.TextProperty);
			set => SetValue (Entry.TextProperty, value);
		}
		public Xamarin.Forms.Color TextColor {
			get => GetValue<Xamarin.Forms.Color> (Entry.TextColorProperty);
			set => SetValue (Entry.TextColorProperty, value);
		}
		public Xamarin.Forms.TextAlignment HorizontalTextAlignment {
			get => GetValue<Xamarin.Forms.TextAlignment> (Entry.HorizontalTextAlignmentProperty);
			set => SetValue (Entry.HorizontalTextAlignmentProperty, value);
		}
		public System.String FontFamily {
			get => GetValue<System.String> (Entry.FontFamilyProperty);
			set => SetValue (Entry.FontFamilyProperty, value);
		}
		public double FontSize {
			get => GetValue<double> (Entry.FontSizeProperty);
			set => SetValue (Entry.FontSizeProperty, value);
		}
		public Xamarin.Forms.FontAttributes FontAttributes {
			get => GetValue<Xamarin.Forms.FontAttributes> (Entry.FontAttributesProperty);
			set => SetValue (Entry.FontAttributesProperty, value);
		}
		public bool IsTextPredictionEnabled {
			get => GetValue<bool> (Entry.IsTextPredictionEnabledProperty);
			set => SetValue (Entry.IsTextPredictionEnabledProperty, value);
		}
		public int CursorPosition {
			get => GetValue<int> (Entry.CursorPositionProperty);
			set => SetValue (Entry.CursorPositionProperty, value);
		}
		public int SelectionLength {
			get => GetValue<int> (Entry.SelectionLengthProperty);
			set => SetValue (Entry.SelectionLengthProperty, value);
		}
	}
	public class FlexLayoutStyle : LayoutStyle {
		public FlexLayoutStyle () { Type = typeof (FlexLayout); }
		public Xamarin.Forms.FlexDirection Direction {
			get => GetValue<Xamarin.Forms.FlexDirection> (FlexLayout.DirectionProperty);
			set => SetValue (FlexLayout.DirectionProperty, value);
		}
		public Xamarin.Forms.FlexJustify JustifyContent {
			get => GetValue<Xamarin.Forms.FlexJustify> (FlexLayout.JustifyContentProperty);
			set => SetValue (FlexLayout.JustifyContentProperty, value);
		}
		public Xamarin.Forms.FlexAlignContent AlignContent {
			get => GetValue<Xamarin.Forms.FlexAlignContent> (FlexLayout.AlignContentProperty);
			set => SetValue (FlexLayout.AlignContentProperty, value);
		}
		public Xamarin.Forms.FlexAlignItems AlignItems {
			get => GetValue<Xamarin.Forms.FlexAlignItems> (FlexLayout.AlignItemsProperty);
			set => SetValue (FlexLayout.AlignItemsProperty, value);
		}
		public Xamarin.Forms.FlexPosition Position {
			get => GetValue<Xamarin.Forms.FlexPosition> (FlexLayout.PositionProperty);
			set => SetValue (FlexLayout.PositionProperty, value);
		}
		public Xamarin.Forms.FlexWrap Wrap {
			get => GetValue<Xamarin.Forms.FlexWrap> (FlexLayout.WrapProperty);
			set => SetValue (FlexLayout.WrapProperty, value);
		}
	}
	public class FrameStyle : ContentViewStyle {
		public FrameStyle () { Type = typeof (Frame); }
		public Xamarin.Forms.Color OutlineColor {
			get => GetValue<Xamarin.Forms.Color> (Frame.OutlineColorProperty);
			set => SetValue (Frame.OutlineColorProperty, value);
		}
		public Xamarin.Forms.Color BorderColor {
			get => GetValue<Xamarin.Forms.Color> (Frame.BorderColorProperty);
			set => SetValue (Frame.BorderColorProperty, value);
		}
		public bool HasShadow {
			get => GetValue<bool> (Frame.HasShadowProperty);
			set => SetValue (Frame.HasShadowProperty, value);
		}
		public System.Single CornerRadius {
			get => GetValue<System.Single> (Frame.CornerRadiusProperty);
			set => SetValue (Frame.CornerRadiusProperty, value);
		}
	}
	public class GridStyle : LayoutStyle {
		public GridStyle () { Type = typeof (Grid); }
		public double RowSpacing {
			get => GetValue<double> (Grid.RowSpacingProperty);
			set => SetValue (Grid.RowSpacingProperty, value);
		}
		public double ColumnSpacing {
			get => GetValue<double> (Grid.ColumnSpacingProperty);
			set => SetValue (Grid.ColumnSpacingProperty, value);
		}
		public Xamarin.Forms.ColumnDefinitionCollection ColumnDefinitions {
			get => GetValue<Xamarin.Forms.ColumnDefinitionCollection> (Grid.ColumnDefinitionsProperty);
			set => SetValue (Grid.ColumnDefinitionsProperty, value);
		}
		public Xamarin.Forms.RowDefinitionCollection RowDefinitions {
			get => GetValue<Xamarin.Forms.RowDefinitionCollection> (Grid.RowDefinitionsProperty);
			set => SetValue (Grid.RowDefinitionsProperty, value);
		}
	}
	public class ImageStyle : ViewStyle {
		public ImageStyle () { Type = typeof (Image); }
		public Xamarin.Forms.ImageSource Source {
			get => GetValue<Xamarin.Forms.ImageSource> (Image.SourceProperty);
			set => SetValue (Image.SourceProperty, value);
		}
		public Xamarin.Forms.Aspect Aspect {
			get => GetValue<Xamarin.Forms.Aspect> (Image.AspectProperty);
			set => SetValue (Image.AspectProperty, value);
		}
		public bool IsOpaque {
			get => GetValue<bool> (Image.IsOpaqueProperty);
			set => SetValue (Image.IsOpaqueProperty, value);
		}
		public bool IsLoading {
			get => GetValue<bool> (Image.IsLoadingProperty);
			set => SetValue (Image.IsLoadingProperty, value);
		}
	}
	public class ImageButtonStyle : ViewStyle {
		public ImageButtonStyle () { Type = typeof (ImageButton); }
		public System.Windows.Input.ICommand Command {
			get => GetValue<System.Windows.Input.ICommand> (ImageButton.CommandProperty);
			set => SetValue (ImageButton.CommandProperty, value);
		}
		public System.Object CommandParameter {
			get => GetValue<System.Object> (ImageButton.CommandParameterProperty);
			set => SetValue (ImageButton.CommandParameterProperty, value);
		}
		public int CornerRadius {
			get => GetValue<int> (ImageButton.CornerRadiusProperty);
			set => SetValue (ImageButton.CornerRadiusProperty, value);
		}
		public double BorderWidth {
			get => GetValue<double> (ImageButton.BorderWidthProperty);
			set => SetValue (ImageButton.BorderWidthProperty, value);
		}
		public Xamarin.Forms.Color BorderColor {
			get => GetValue<Xamarin.Forms.Color> (ImageButton.BorderColorProperty);
			set => SetValue (ImageButton.BorderColorProperty, value);
		}
		public Xamarin.Forms.ImageSource Source {
			get => GetValue<Xamarin.Forms.ImageSource> (ImageButton.SourceProperty);
			set => SetValue (ImageButton.SourceProperty, value);
		}
		public Xamarin.Forms.Aspect Aspect {
			get => GetValue<Xamarin.Forms.Aspect> (ImageButton.AspectProperty);
			set => SetValue (ImageButton.AspectProperty, value);
		}
		public bool IsOpaque {
			get => GetValue<bool> (ImageButton.IsOpaqueProperty);
			set => SetValue (ImageButton.IsOpaqueProperty, value);
		}
		public bool IsLoading {
			get => GetValue<bool> (ImageButton.IsLoadingProperty);
			set => SetValue (ImageButton.IsLoadingProperty, value);
		}
		public bool IsPressed {
			get => GetValue<bool> (ImageButton.IsPressedProperty);
			set => SetValue (ImageButton.IsPressedProperty, value);
		}
		public Xamarin.Forms.Thickness Padding {
			get => GetValue<Xamarin.Forms.Thickness> (ImageButton.PaddingProperty);
			set => SetValue (ImageButton.PaddingProperty, value);
		}
	}
	public class InputViewStyle : ViewStyle {
		public InputViewStyle () { Type = typeof (InputView); }
		public Xamarin.Forms.Keyboard Keyboard {
			get => GetValue<Xamarin.Forms.Keyboard> (InputView.KeyboardProperty);
			set => SetValue (InputView.KeyboardProperty, value);
		}
		public bool IsSpellCheckEnabled {
			get => GetValue<bool> (InputView.IsSpellCheckEnabledProperty);
			set => SetValue (InputView.IsSpellCheckEnabledProperty, value);
		}
		public int MaxLength {
			get => GetValue<int> (InputView.MaxLengthProperty);
			set => SetValue (InputView.MaxLengthProperty, value);
		}
		public bool IsReadOnly {
			get => GetValue<bool> (InputView.IsReadOnlyProperty);
			set => SetValue (InputView.IsReadOnlyProperty, value);
		}
	}
	public class ItemsViewStyle : ViewStyle {
		public ItemsViewStyle () { Type = typeof (ItemsView); }
		public System.Object EmptyView {
			get => GetValue<System.Object> (ItemsView.EmptyViewProperty);
			set => SetValue (ItemsView.EmptyViewProperty, value);
		}
		public Xamarin.Forms.DataTemplate EmptyViewTemplate {
			get => GetValue<Xamarin.Forms.DataTemplate> (ItemsView.EmptyViewTemplateProperty);
			set => SetValue (ItemsView.EmptyViewTemplateProperty, value);
		}
		public System.Collections.IEnumerable ItemsSource {
			get => GetValue<System.Collections.IEnumerable> (ItemsView.ItemsSourceProperty);
			set => SetValue (ItemsView.ItemsSourceProperty, value);
		}
		public Xamarin.Forms.IItemsLayout ItemsLayout {
			get => GetValue<Xamarin.Forms.IItemsLayout> (ItemsView.ItemsLayoutProperty);
			set => SetValue (ItemsView.ItemsLayoutProperty, value);
		}
		public Xamarin.Forms.DataTemplate ItemTemplate {
			get => GetValue<Xamarin.Forms.DataTemplate> (ItemsView.ItemTemplateProperty);
			set => SetValue (ItemsView.ItemTemplateProperty, value);
		}
		public Xamarin.Forms.ItemSizingStrategy ItemSizingStrategy {
			get => GetValue<Xamarin.Forms.ItemSizingStrategy> (ItemsView.ItemSizingStrategyProperty);
			set => SetValue (ItemsView.ItemSizingStrategyProperty, value);
		}
	}
	public class SelectableItemsViewStyle : ItemsViewStyle {
		public SelectableItemsViewStyle () { Type = typeof (SelectableItemsView); }
		public Xamarin.Forms.SelectionMode SelectionMode {
			get => GetValue<Xamarin.Forms.SelectionMode> (SelectableItemsView.SelectionModeProperty);
			set => SetValue (SelectableItemsView.SelectionModeProperty, value);
		}
		public System.Object SelectedItem {
			get => GetValue<System.Object> (SelectableItemsView.SelectedItemProperty);
			set => SetValue (SelectableItemsView.SelectedItemProperty, value);
		}
		public System.Windows.Input.ICommand SelectionChangedCommand {
			get => GetValue<System.Windows.Input.ICommand> (SelectableItemsView.SelectionChangedCommandProperty);
			set => SetValue (SelectableItemsView.SelectionChangedCommandProperty, value);
		}
		public System.Object SelectionChangedCommandParameter {
			get => GetValue<System.Object> (SelectableItemsView.SelectionChangedCommandParameterProperty);
			set => SetValue (SelectableItemsView.SelectionChangedCommandParameterProperty, value);
		}
	}
	public class LabelStyle : ViewStyle {
		public LabelStyle () { Type = typeof (Label); }
		public Xamarin.Forms.TextAlignment HorizontalTextAlignment {
			get => GetValue<Xamarin.Forms.TextAlignment> (Label.HorizontalTextAlignmentProperty);
			set => SetValue (Label.HorizontalTextAlignmentProperty, value);
		}
		public Xamarin.Forms.TextAlignment XAlign {
			get => GetValue<Xamarin.Forms.TextAlignment> (Label.XAlignProperty);
			set => SetValue (Label.XAlignProperty, value);
		}
		public Xamarin.Forms.TextAlignment VerticalTextAlignment {
			get => GetValue<Xamarin.Forms.TextAlignment> (Label.VerticalTextAlignmentProperty);
			set => SetValue (Label.VerticalTextAlignmentProperty, value);
		}
		public Xamarin.Forms.TextAlignment YAlign {
			get => GetValue<Xamarin.Forms.TextAlignment> (Label.YAlignProperty);
			set => SetValue (Label.YAlignProperty, value);
		}
		public Xamarin.Forms.Color TextColor {
			get => GetValue<Xamarin.Forms.Color> (Label.TextColorProperty);
			set => SetValue (Label.TextColorProperty, value);
		}
		public Xamarin.Forms.Font Font {
			get => GetValue<Xamarin.Forms.Font> (Label.FontProperty);
			set => SetValue (Label.FontProperty, value);
		}
		public System.String Text {
			get => GetValue<System.String> (Label.TextProperty);
			set => SetValue (Label.TextProperty, value);
		}
		public System.String FontFamily {
			get => GetValue<System.String> (Label.FontFamilyProperty);
			set => SetValue (Label.FontFamilyProperty, value);
		}
		public double FontSize {
			get => GetValue<double> (Label.FontSizeProperty);
			set => SetValue (Label.FontSizeProperty, value);
		}
		public Xamarin.Forms.FontAttributes FontAttributes {
			get => GetValue<Xamarin.Forms.FontAttributes> (Label.FontAttributesProperty);
			set => SetValue (Label.FontAttributesProperty, value);
		}
		public Xamarin.Forms.TextDecorations TextDecorations {
			get => GetValue<Xamarin.Forms.TextDecorations> (Label.TextDecorationsProperty);
			set => SetValue (Label.TextDecorationsProperty, value);
		}
		public Xamarin.Forms.FormattedString FormattedText {
			get => GetValue<Xamarin.Forms.FormattedString> (Label.FormattedTextProperty);
			set => SetValue (Label.FormattedTextProperty, value);
		}
		public Xamarin.Forms.LineBreakMode LineBreakMode {
			get => GetValue<Xamarin.Forms.LineBreakMode> (Label.LineBreakModeProperty);
			set => SetValue (Label.LineBreakModeProperty, value);
		}
		public double LineHeight {
			get => GetValue<double> (Label.LineHeightProperty);
			set => SetValue (Label.LineHeightProperty, value);
		}
		public int MaxLines {
			get => GetValue<int> (Label.MaxLinesProperty);
			set => SetValue (Label.MaxLinesProperty, value);
		}
	}
	public class LayoutStyle : ViewStyle {
		public LayoutStyle () { Type = typeof (Layout); }
		public bool IsClippedToBounds {
			get => GetValue<bool> (Layout.IsClippedToBoundsProperty);
			set => SetValue (Layout.IsClippedToBoundsProperty, value);
		}
		public bool CascadeInputTransparent {
			get => GetValue<bool> (Layout.CascadeInputTransparentProperty);
			set => SetValue (Layout.CascadeInputTransparentProperty, value);
		}
		public Xamarin.Forms.Thickness Padding {
			get => GetValue<Xamarin.Forms.Thickness> (Layout.PaddingProperty);
			set => SetValue (Layout.PaddingProperty, value);
		}
	}
	public class ListViewStyle : ItemsViewStyle {
		public ListViewStyle () { Type = typeof (ListView); }
		public bool IsPullToRefreshEnabled {
			get => GetValue<bool> (ListView.IsPullToRefreshEnabledProperty);
			set => SetValue (ListView.IsPullToRefreshEnabledProperty, value);
		}
		public bool IsRefreshing {
			get => GetValue<bool> (ListView.IsRefreshingProperty);
			set => SetValue (ListView.IsRefreshingProperty, value);
		}
		public System.Windows.Input.ICommand RefreshCommand {
			get => GetValue<System.Windows.Input.ICommand> (ListView.RefreshCommandProperty);
			set => SetValue (ListView.RefreshCommandProperty, value);
		}
		public System.Object Header {
			get => GetValue<System.Object> (ListView.HeaderProperty);
			set => SetValue (ListView.HeaderProperty, value);
		}
		public Xamarin.Forms.DataTemplate HeaderTemplate {
			get => GetValue<Xamarin.Forms.DataTemplate> (ListView.HeaderTemplateProperty);
			set => SetValue (ListView.HeaderTemplateProperty, value);
		}
		public System.Object Footer {
			get => GetValue<System.Object> (ListView.FooterProperty);
			set => SetValue (ListView.FooterProperty, value);
		}
		public Xamarin.Forms.DataTemplate FooterTemplate {
			get => GetValue<Xamarin.Forms.DataTemplate> (ListView.FooterTemplateProperty);
			set => SetValue (ListView.FooterTemplateProperty, value);
		}
		public System.Object SelectedItem {
			get => GetValue<System.Object> (ListView.SelectedItemProperty);
			set => SetValue (ListView.SelectedItemProperty, value);
		}
		public Xamarin.Forms.ListViewSelectionMode SelectionMode {
			get => GetValue<Xamarin.Forms.ListViewSelectionMode> (ListView.SelectionModeProperty);
			set => SetValue (ListView.SelectionModeProperty, value);
		}
		public bool HasUnevenRows {
			get => GetValue<bool> (ListView.HasUnevenRowsProperty);
			set => SetValue (ListView.HasUnevenRowsProperty, value);
		}
		public int RowHeight {
			get => GetValue<int> (ListView.RowHeightProperty);
			set => SetValue (ListView.RowHeightProperty, value);
		}
		public Xamarin.Forms.DataTemplate GroupHeaderTemplate {
			get => GetValue<Xamarin.Forms.DataTemplate> (ListView.GroupHeaderTemplateProperty);
			set => SetValue (ListView.GroupHeaderTemplateProperty, value);
		}
		public bool IsGroupingEnabled {
			get => GetValue<bool> (ListView.IsGroupingEnabledProperty);
			set => SetValue (ListView.IsGroupingEnabledProperty, value);
		}
		public Xamarin.Forms.SeparatorVisibility SeparatorVisibility {
			get => GetValue<Xamarin.Forms.SeparatorVisibility> (ListView.SeparatorVisibilityProperty);
			set => SetValue (ListView.SeparatorVisibilityProperty, value);
		}
		public Xamarin.Forms.Color SeparatorColor {
			get => GetValue<Xamarin.Forms.Color> (ListView.SeparatorColorProperty);
			set => SetValue (ListView.SeparatorColorProperty, value);
		}
		public Xamarin.Forms.Color RefreshControlColor {
			get => GetValue<Xamarin.Forms.Color> (ListView.RefreshControlColorProperty);
			set => SetValue (ListView.RefreshControlColorProperty, value);
		}
		public Xamarin.Forms.ScrollBarVisibility HorizontalScrollBarVisibility {
			get => GetValue<Xamarin.Forms.ScrollBarVisibility> (ListView.HorizontalScrollBarVisibilityProperty);
			set => SetValue (ListView.HorizontalScrollBarVisibilityProperty, value);
		}
		public Xamarin.Forms.ScrollBarVisibility VerticalScrollBarVisibility {
			get => GetValue<Xamarin.Forms.ScrollBarVisibility> (ListView.VerticalScrollBarVisibilityProperty);
			set => SetValue (ListView.VerticalScrollBarVisibilityProperty, value);
		}
	}
	public class MasterDetailPageStyle : PageStyle {
		public MasterDetailPageStyle () { Type = typeof (MasterDetailPage); }
		public bool IsGestureEnabled {
			get => GetValue<bool> (MasterDetailPage.IsGestureEnabledProperty);
			set => SetValue (MasterDetailPage.IsGestureEnabledProperty, value);
		}
		public bool IsPresented {
			get => GetValue<bool> (MasterDetailPage.IsPresentedProperty);
			set => SetValue (MasterDetailPage.IsPresentedProperty, value);
		}
		public Xamarin.Forms.MasterBehavior MasterBehavior {
			get => GetValue<Xamarin.Forms.MasterBehavior> (MasterDetailPage.MasterBehaviorProperty);
			set => SetValue (MasterDetailPage.MasterBehaviorProperty, value);
		}
	}
	public class NavigationPageStyle : PageStyle {
		public NavigationPageStyle () { Type = typeof (NavigationPage); }
		public Xamarin.Forms.Color Tint {
			get => GetValue<Xamarin.Forms.Color> (NavigationPage.TintProperty);
			set => SetValue (NavigationPage.TintProperty, value);
		}
		public Xamarin.Forms.Color BarBackgroundColor {
			get => GetValue<Xamarin.Forms.Color> (NavigationPage.BarBackgroundColorProperty);
			set => SetValue (NavigationPage.BarBackgroundColorProperty, value);
		}
		public Xamarin.Forms.Color BarTextColor {
			get => GetValue<Xamarin.Forms.Color> (NavigationPage.BarTextColorProperty);
			set => SetValue (NavigationPage.BarTextColorProperty, value);
		}
		public Xamarin.Forms.Page CurrentPage {
			get => GetValue<Xamarin.Forms.Page> (NavigationPage.CurrentPageProperty);
			set => SetValue (NavigationPage.CurrentPageProperty, value);
		}
		public Xamarin.Forms.Page RootPage {
			get => GetValue<Xamarin.Forms.Page> (NavigationPage.RootPageProperty);
			set => SetValue (NavigationPage.RootPageProperty, value);
		}
	}
	public class OpenGLViewStyle : ViewStyle {
		public OpenGLViewStyle () { Type = typeof (OpenGLView); }
		public bool HasRenderLoop {
			get => GetValue<bool> (OpenGLView.HasRenderLoopProperty);
			set => SetValue (OpenGLView.HasRenderLoopProperty, value);
		}
	}
	public class PageStyle : VisualElementStyle {
		public PageStyle () { Type = typeof (Page); }
		public System.String BackgroundImage {
			get => GetValue<System.String> (Page.BackgroundImageProperty);
			set => SetValue (Page.BackgroundImageProperty, value);
		}
		public bool IsBusy {
			get => GetValue<bool> (Page.IsBusyProperty);
			set => SetValue (Page.IsBusyProperty, value);
		}
		public Xamarin.Forms.Thickness Padding {
			get => GetValue<Xamarin.Forms.Thickness> (Page.PaddingProperty);
			set => SetValue (Page.PaddingProperty, value);
		}
		public System.String Title {
			get => GetValue<System.String> (Page.TitleProperty);
			set => SetValue (Page.TitleProperty, value);
		}
		public Xamarin.Forms.FileImageSource Icon {
			get => GetValue<Xamarin.Forms.FileImageSource> (Page.IconProperty);
			set => SetValue (Page.IconProperty, value);
		}
	}
	public class PickerStyle : ViewStyle {
		public PickerStyle () { Type = typeof (Picker); }
		public Xamarin.Forms.Color TextColor {
			get => GetValue<Xamarin.Forms.Color> (Picker.TextColorProperty);
			set => SetValue (Picker.TextColorProperty, value);
		}
		public System.String Title {
			get => GetValue<System.String> (Picker.TitleProperty);
			set => SetValue (Picker.TitleProperty, value);
		}
		public Xamarin.Forms.Color TitleColor {
			get => GetValue<Xamarin.Forms.Color> (Picker.TitleColorProperty);
			set => SetValue (Picker.TitleColorProperty, value);
		}
		public int SelectedIndex {
			get => GetValue<int> (Picker.SelectedIndexProperty);
			set => SetValue (Picker.SelectedIndexProperty, value);
		}
		public System.Collections.IList ItemsSource {
			get => GetValue<System.Collections.IList> (Picker.ItemsSourceProperty);
			set => SetValue (Picker.ItemsSourceProperty, value);
		}
		public System.Object SelectedItem {
			get => GetValue<System.Object> (Picker.SelectedItemProperty);
			set => SetValue (Picker.SelectedItemProperty, value);
		}
		public System.String FontFamily {
			get => GetValue<System.String> (Picker.FontFamilyProperty);
			set => SetValue (Picker.FontFamilyProperty, value);
		}
		public double FontSize {
			get => GetValue<double> (Picker.FontSizeProperty);
			set => SetValue (Picker.FontSizeProperty, value);
		}
		public Xamarin.Forms.FontAttributes FontAttributes {
			get => GetValue<Xamarin.Forms.FontAttributes> (Picker.FontAttributesProperty);
			set => SetValue (Picker.FontAttributesProperty, value);
		}
	}
	public class ProgressBarStyle : ViewStyle {
		public ProgressBarStyle () { Type = typeof (ProgressBar); }
		public Xamarin.Forms.Color ProgressColor {
			get => GetValue<Xamarin.Forms.Color> (ProgressBar.ProgressColorProperty);
			set => SetValue (ProgressBar.ProgressColorProperty, value);
		}
		public double Progress {
			get => GetValue<double> (ProgressBar.ProgressProperty);
			set => SetValue (ProgressBar.ProgressProperty, value);
		}
	}
	public class ScrollViewStyle : LayoutStyle {
		public ScrollViewStyle () { Type = typeof (ScrollView); }
		public Xamarin.Forms.ScrollOrientation Orientation {
			get => GetValue<Xamarin.Forms.ScrollOrientation> (ScrollView.OrientationProperty);
			set => SetValue (ScrollView.OrientationProperty, value);
		}
		public double ScrollX {
			get => GetValue<double> (ScrollView.ScrollXProperty);
			set => SetValue (ScrollView.ScrollXProperty, value);
		}
		public double ScrollY {
			get => GetValue<double> (ScrollView.ScrollYProperty);
			set => SetValue (ScrollView.ScrollYProperty, value);
		}
		public Xamarin.Forms.Size ContentSize {
			get => GetValue<Xamarin.Forms.Size> (ScrollView.ContentSizeProperty);
			set => SetValue (ScrollView.ContentSizeProperty, value);
		}
		public Xamarin.Forms.ScrollBarVisibility HorizontalScrollBarVisibility {
			get => GetValue<Xamarin.Forms.ScrollBarVisibility> (ScrollView.HorizontalScrollBarVisibilityProperty);
			set => SetValue (ScrollView.HorizontalScrollBarVisibilityProperty, value);
		}
		public Xamarin.Forms.ScrollBarVisibility VerticalScrollBarVisibility {
			get => GetValue<Xamarin.Forms.ScrollBarVisibility> (ScrollView.VerticalScrollBarVisibilityProperty);
			set => SetValue (ScrollView.VerticalScrollBarVisibilityProperty, value);
		}
	}
	public class SearchBarStyle : InputViewStyle {
		public SearchBarStyle () { Type = typeof (SearchBar); }
		public System.Windows.Input.ICommand SearchCommand {
			get => GetValue<System.Windows.Input.ICommand> (SearchBar.SearchCommandProperty);
			set => SetValue (SearchBar.SearchCommandProperty, value);
		}
		public System.Object SearchCommandParameter {
			get => GetValue<System.Object> (SearchBar.SearchCommandParameterProperty);
			set => SetValue (SearchBar.SearchCommandParameterProperty, value);
		}
		public System.String Text {
			get => GetValue<System.String> (SearchBar.TextProperty);
			set => SetValue (SearchBar.TextProperty, value);
		}
		public Xamarin.Forms.Color CancelButtonColor {
			get => GetValue<Xamarin.Forms.Color> (SearchBar.CancelButtonColorProperty);
			set => SetValue (SearchBar.CancelButtonColorProperty, value);
		}
		public System.String Placeholder {
			get => GetValue<System.String> (SearchBar.PlaceholderProperty);
			set => SetValue (SearchBar.PlaceholderProperty, value);
		}
		public Xamarin.Forms.Color PlaceholderColor {
			get => GetValue<Xamarin.Forms.Color> (SearchBar.PlaceholderColorProperty);
			set => SetValue (SearchBar.PlaceholderColorProperty, value);
		}
		public System.String FontFamily {
			get => GetValue<System.String> (SearchBar.FontFamilyProperty);
			set => SetValue (SearchBar.FontFamilyProperty, value);
		}
		public double FontSize {
			get => GetValue<double> (SearchBar.FontSizeProperty);
			set => SetValue (SearchBar.FontSizeProperty, value);
		}
		public Xamarin.Forms.FontAttributes FontAttributes {
			get => GetValue<Xamarin.Forms.FontAttributes> (SearchBar.FontAttributesProperty);
			set => SetValue (SearchBar.FontAttributesProperty, value);
		}
		public Xamarin.Forms.TextAlignment HorizontalTextAlignment {
			get => GetValue<Xamarin.Forms.TextAlignment> (SearchBar.HorizontalTextAlignmentProperty);
			set => SetValue (SearchBar.HorizontalTextAlignmentProperty, value);
		}
		public Xamarin.Forms.Color TextColor {
			get => GetValue<Xamarin.Forms.Color> (SearchBar.TextColorProperty);
			set => SetValue (SearchBar.TextColorProperty, value);
		}
	}
	public class ShellStyle : PageStyle {
		public ShellStyle () { Type = typeof (Shell); }
		public Xamarin.Forms.FlyoutBehavior FlyoutBehavior {
			get => GetValue<Xamarin.Forms.FlyoutBehavior> (Shell.FlyoutBehaviorProperty);
			set => SetValue (Shell.FlyoutBehaviorProperty, value);
		}
		public Xamarin.Forms.ShellItem CurrentItem {
			get => GetValue<Xamarin.Forms.ShellItem> (Shell.CurrentItemProperty);
			set => SetValue (Shell.CurrentItemProperty, value);
		}
		public Xamarin.Forms.ShellNavigationState CurrentState {
			get => GetValue<Xamarin.Forms.ShellNavigationState> (Shell.CurrentStateProperty);
			set => SetValue (Shell.CurrentStateProperty, value);
		}
		public Xamarin.Forms.Color FlyoutBackgroundColor {
			get => GetValue<Xamarin.Forms.Color> (Shell.FlyoutBackgroundColorProperty);
			set => SetValue (Shell.FlyoutBackgroundColorProperty, value);
		}
		public Xamarin.Forms.FlyoutHeaderBehavior FlyoutHeaderBehavior {
			get => GetValue<Xamarin.Forms.FlyoutHeaderBehavior> (Shell.FlyoutHeaderBehaviorProperty);
			set => SetValue (Shell.FlyoutHeaderBehaviorProperty, value);
		}
		public System.Object FlyoutHeader {
			get => GetValue<System.Object> (Shell.FlyoutHeaderProperty);
			set => SetValue (Shell.FlyoutHeaderProperty, value);
		}
		public Xamarin.Forms.DataTemplate FlyoutHeaderTemplate {
			get => GetValue<Xamarin.Forms.DataTemplate> (Shell.FlyoutHeaderTemplateProperty);
			set => SetValue (Shell.FlyoutHeaderTemplateProperty, value);
		}
		public bool FlyoutIsPresented {
			get => GetValue<bool> (Shell.FlyoutIsPresentedProperty);
			set => SetValue (Shell.FlyoutIsPresentedProperty, value);
		}
		//public Xamarin.Forms.DataTemplate GroupHeaderTemplate {
		//	get => GetValue<Xamarin.Forms.DataTemplate> (Shell.GroupHeaderTemplateProperty);
		//	set => SetValue (Shell.GroupHeaderTemplateProperty, value);
		//}
		//public Xamarin.Forms.ShellItemCollection Items {
		//	get => GetValue<Xamarin.Forms.ShellItemCollection> (Shell.ItemsProperty);
		//	set => SetValue (Shell.ItemsProperty, value);
		//}
		public Xamarin.Forms.DataTemplate ItemTemplate {
			get => GetValue<Xamarin.Forms.DataTemplate> (Shell.ItemTemplateProperty);
			set => SetValue (Shell.ItemTemplateProperty, value);
		}
		//public Xamarin.Forms.MenuItemCollection MenuItems {
		//	get => GetValue<Xamarin.Forms.MenuItemCollection> (Shell.MenuItemsProperty);
		//	set => SetValue (Shell.MenuItemsProperty, value);
		//}
		public Xamarin.Forms.DataTemplate MenuItemTemplate {
			get => GetValue<Xamarin.Forms.DataTemplate> (Shell.MenuItemTemplateProperty);
			set => SetValue (Shell.MenuItemTemplateProperty, value);
		}
	}
	public class SliderStyle : ViewStyle {
		public SliderStyle () { Type = typeof (Slider); }
		public double Minimum {
			get => GetValue<double> (Slider.MinimumProperty);
			set => SetValue (Slider.MinimumProperty, value);
		}
		public double Maximum {
			get => GetValue<double> (Slider.MaximumProperty);
			set => SetValue (Slider.MaximumProperty, value);
		}
		public double Value {
			get => GetValue<double> (Slider.ValueProperty);
			set => SetValue (Slider.ValueProperty, value);
		}
		public Xamarin.Forms.Color MinimumTrackColor {
			get => GetValue<Xamarin.Forms.Color> (Slider.MinimumTrackColorProperty);
			set => SetValue (Slider.MinimumTrackColorProperty, value);
		}
		public Xamarin.Forms.Color MaximumTrackColor {
			get => GetValue<Xamarin.Forms.Color> (Slider.MaximumTrackColorProperty);
			set => SetValue (Slider.MaximumTrackColorProperty, value);
		}
		public Xamarin.Forms.Color ThumbColor {
			get => GetValue<Xamarin.Forms.Color> (Slider.ThumbColorProperty);
			set => SetValue (Slider.ThumbColorProperty, value);
		}
		public Xamarin.Forms.FileImageSource ThumbImage {
			get => GetValue<Xamarin.Forms.FileImageSource> (Slider.ThumbImageProperty);
			set => SetValue (Slider.ThumbImageProperty, value);
		}
		public System.Windows.Input.ICommand DragStartedCommand {
			get => GetValue<System.Windows.Input.ICommand> (Slider.DragStartedCommandProperty);
			set => SetValue (Slider.DragStartedCommandProperty, value);
		}
		public System.Windows.Input.ICommand DragCompletedCommand {
			get => GetValue<System.Windows.Input.ICommand> (Slider.DragCompletedCommandProperty);
			set => SetValue (Slider.DragCompletedCommandProperty, value);
		}
	}
	public class StackLayoutStyle : LayoutStyle {
		public StackLayoutStyle () { Type = typeof (StackLayout); }
		public Xamarin.Forms.StackOrientation Orientation {
			get => GetValue<Xamarin.Forms.StackOrientation> (StackLayout.OrientationProperty);
			set => SetValue (StackLayout.OrientationProperty, value);
		}
		public double Spacing {
			get => GetValue<double> (StackLayout.SpacingProperty);
			set => SetValue (StackLayout.SpacingProperty, value);
		}
	}
	public class StepperStyle : ViewStyle {
		public StepperStyle () { Type = typeof (Stepper); }
		public double Maximum {
			get => GetValue<double> (Stepper.MaximumProperty);
			set => SetValue (Stepper.MaximumProperty, value);
		}
		public double Minimum {
			get => GetValue<double> (Stepper.MinimumProperty);
			set => SetValue (Stepper.MinimumProperty, value);
		}
		public double Value {
			get => GetValue<double> (Stepper.ValueProperty);
			set => SetValue (Stepper.ValueProperty, value);
		}
		public double Increment {
			get => GetValue<double> (Stepper.IncrementProperty);
			set => SetValue (Stepper.IncrementProperty, value);
		}
	}
	public class SwitchStyle : ViewStyle {
		public SwitchStyle () { Type = typeof (Switch); }
		public bool IsToggled {
			get => GetValue<bool> (Switch.IsToggledProperty);
			set => SetValue (Switch.IsToggledProperty, value);
		}
		public Xamarin.Forms.Color OnColor {
			get => GetValue<Xamarin.Forms.Color> (Switch.OnColorProperty);
			set => SetValue (Switch.OnColorProperty, value);
		}
	}
	public class TabbedPageStyle : PageStyle {
		public TabbedPageStyle () { Type = typeof (TabbedPage); }
		public Xamarin.Forms.Color BarBackgroundColor {
			get => GetValue<Xamarin.Forms.Color> (TabbedPage.BarBackgroundColorProperty);
			set => SetValue (TabbedPage.BarBackgroundColorProperty, value);
		}
		public Xamarin.Forms.Color BarTextColor {
			get => GetValue<Xamarin.Forms.Color> (TabbedPage.BarTextColorProperty);
			set => SetValue (TabbedPage.BarTextColorProperty, value);
		}
	}
	public class TableViewStyle : ViewStyle {
		public TableViewStyle () { Type = typeof (TableView); }
		public int RowHeight {
			get => GetValue<int> (TableView.RowHeightProperty);
			set => SetValue (TableView.RowHeightProperty, value);
		}
		public bool HasUnevenRows {
			get => GetValue<bool> (TableView.HasUnevenRowsProperty);
			set => SetValue (TableView.HasUnevenRowsProperty, value);
		}
	}
	public class TemplatedPageStyle : PageStyle {
		public TemplatedPageStyle () { Type = typeof (TemplatedPage); }
		public Xamarin.Forms.ControlTemplate ControlTemplate {
			get => GetValue<Xamarin.Forms.ControlTemplate> (TemplatedPage.ControlTemplateProperty);
			set => SetValue (TemplatedPage.ControlTemplateProperty, value);
		}
	}
	public class TemplatedViewStyle : LayoutStyle {
		public TemplatedViewStyle () { Type = typeof (TemplatedView); }
		public Xamarin.Forms.ControlTemplate ControlTemplate {
			get => GetValue<Xamarin.Forms.ControlTemplate> (TemplatedView.ControlTemplateProperty);
			set => SetValue (TemplatedView.ControlTemplateProperty, value);
		}
	}
	public class TimePickerStyle : ViewStyle {
		public TimePickerStyle () { Type = typeof (TimePicker); }
		public System.String Format {
			get => GetValue<System.String> (TimePicker.FormatProperty);
			set => SetValue (TimePicker.FormatProperty, value);
		}
		public Xamarin.Forms.Color TextColor {
			get => GetValue<Xamarin.Forms.Color> (TimePicker.TextColorProperty);
			set => SetValue (TimePicker.TextColorProperty, value);
		}
		public System.TimeSpan Time {
			get => GetValue<System.TimeSpan> (TimePicker.TimeProperty);
			set => SetValue (TimePicker.TimeProperty, value);
		}
		public System.String FontFamily {
			get => GetValue<System.String> (TimePicker.FontFamilyProperty);
			set => SetValue (TimePicker.FontFamilyProperty, value);
		}
		public double FontSize {
			get => GetValue<double> (TimePicker.FontSizeProperty);
			set => SetValue (TimePicker.FontSizeProperty, value);
		}
		public Xamarin.Forms.FontAttributes FontAttributes {
			get => GetValue<Xamarin.Forms.FontAttributes> (TimePicker.FontAttributesProperty);
			set => SetValue (TimePicker.FontAttributesProperty, value);
		}
	}
	public class ViewStyle : VisualElementStyle {
		public ViewStyle () { Type = typeof (View); }
		public Xamarin.Forms.LayoutOptions VerticalOptions {
			get => GetValue<Xamarin.Forms.LayoutOptions> (View.VerticalOptionsProperty);
			set => SetValue (View.VerticalOptionsProperty, value);
		}
		public Xamarin.Forms.LayoutOptions HorizontalOptions {
			get => GetValue<Xamarin.Forms.LayoutOptions> (View.HorizontalOptionsProperty);
			set => SetValue (View.HorizontalOptionsProperty, value);
		}
		public Xamarin.Forms.Thickness Margin {
			get => GetValue<Xamarin.Forms.Thickness> (View.MarginProperty);
			set => SetValue (View.MarginProperty, value);
		}
	}
	public class WebViewStyle : ViewStyle {
		public WebViewStyle () { Type = typeof (WebView); }
		public Xamarin.Forms.WebViewSource Source {
			get => GetValue<Xamarin.Forms.WebViewSource> (WebView.SourceProperty);
			set => SetValue (WebView.SourceProperty, value);
		}
		public bool CanGoBack {
			get => GetValue<bool> (WebView.CanGoBackProperty);
			set => SetValue (WebView.CanGoBackProperty, value);
		}
		public bool CanGoForward {
			get => GetValue<bool> (WebView.CanGoForwardProperty);
			set => SetValue (WebView.CanGoForwardProperty, value);
		}
	}
	public class StyleHelper {
		public string Name { get; set; }
		protected Type Type;
		public readonly Dictionary<BindableProperty, object> Properties = new Dictionary<BindableProperty, object> ();
		public Style ToStyle ()
		{
			if (Type == null)
				throw new Exception ("Please set the Type first");
			return Apply (new Style (Type));
		}
		public Style Apply (Style style)
		{
			Properties.ForEach (x => style.Setters.Add (new Setter { Property = x.Key, Value = x.Value }));
			return style;
		}

		public static implicit operator Style (StyleHelper s) => s.ToStyle ();

		protected T GetValue<T> (BindableProperty property) => Properties.TryGetValue (property, out var val) ? (T)val : default (T);
		protected void SetValue (BindableProperty prop, object value) => Properties [prop] = value;
	}
}
