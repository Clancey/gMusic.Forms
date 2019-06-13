using System;
using System.ComponentModel;
using UIKit;
using SizeF = CoreGraphics.CGSize;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Specifics = Xamarin.Forms.PlatformConfiguration.iOSSpecific.Slider;
using gMusic.Views;
using gMusic.iOS.Renderers;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;
using System.Threading;

[assembly: Xamarin.Forms.ExportRenderer (typeof (ScrubberView), typeof (ScrubberViewRenderer))]
namespace gMusic.iOS.Renderers {
	public class ScrubberViewRenderer : ViewRenderer<ScrubberView, UIView> {
		OBSlider slider = new OBSlider ();

		UIColor defaultmintrackcolor, defaultmaxtrackcolor, defaultthumbcolor;
		public ScrubberViewRenderer()
		{ 

			defaultmintrackcolor = slider.MinimumTrackTintColor;
			defaultmaxtrackcolor = slider.MaximumTrackTintColor;
			defaultthumbcolor = slider.ThumbTintColor;
			Add (slider);
			slider.ValueChanged += OnControlValueChanged;
			slider.EditingDidBegin += Slider_EditingDidBegin;
			slider.EditingDidEnd += Slider_EditingDidEnd;
		}

		private void Slider_EditingDidEnd (object sender, EventArgs e)
		{
			Element?.EditingDidEnd?.Invoke ();
		}

		private void Slider_EditingDidBegin (object sender, EventArgs e)
		{
			Element?.EditingDidBegin?.Invoke ();
		}

		public override SizeF SizeThatFits (SizeF size)
		{
			return slider.SizeThatFits (size);
		}

		protected override void Dispose (bool disposing)
		{
			slider.ValueChanged -= OnControlValueChanged;
			
			base.Dispose (disposing);
		}

		protected override void OnElementChanged (ElementChangedEventArgs<ScrubberView> e)
		{
			if (e.NewElement != null) {
				UpdateMaximum ();
				UpdateMinimum ();
				UpdateValue ();
				UpdateSliderColors ();
			}

			base.OnElementChanged (e);
		}
		
		private void UpdateSliderColors ()
		{
			UpdateMinimumTrackColor ();
			UpdateMaximumTrackColor ();
			if (Element.ThumbImageSource != null) {
				UpdateThumbImage ();
			} else {
				UpdateThumbColor ();
			}
		}

		private void UpdateMinimumTrackColor ()
		{
			if (Element != null) {
				if (Element.MinimumTrackColor == Xamarin.Forms.Color.Default)
					slider.MinimumTrackTintColor = defaultmintrackcolor;
				else
					slider.MinimumTrackTintColor = Element.MinimumTrackColor.ToUIColor ();
			}
		}

		private void UpdateMaximumTrackColor ()
		{
			if (Element != null) {
				if (Element.MaximumTrackColor == Color.Default)
					slider.MaximumTrackTintColor = defaultmaxtrackcolor;
				else
					slider.MaximumTrackTintColor = Element.MaximumTrackColor.ToUIColor ();
			}
		}
		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();
			//The iOS slider has some horrible padding. This removes it.
			var frame = Bounds;
			frame.X -= 18;
			frame.Width += 36;
			slider.Frame = frame;
		}
		private void UpdateThumbColor ()
		{
			if (Element != null) {
				if (Element.ThumbColor == Color.Default)
					slider.ThumbTintColor = defaultthumbcolor;
				else
					slider.ThumbTintColor = Element.ThumbColor.ToUIColor ();
			}
		}

		async void UpdateThumbImage ()
		{
			var uiimage = await GetNativeImageAsync (Element.ThumbImageSource);
			slider.SetThumbImage (uiimage, UIControlState.Normal);

			((IVisualElementController)Element).NativeSizeChanged ();
		}

		protected override void OnElementPropertyChanged (object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);

			if (e.PropertyName == ScrubberView.MaximumProperty.PropertyName)
				UpdateMaximum ();
			else if (e.PropertyName == ScrubberView.MinimumProperty.PropertyName)
				UpdateMinimum ();
			else if (e.PropertyName == ScrubberView.ValueProperty.PropertyName)
				UpdateValue ();
			else if (e.PropertyName == ScrubberView.MinimumTrackColorProperty.PropertyName)
				UpdateMinimumTrackColor ();
			else if (e.PropertyName == ScrubberView.MaximumTrackColorProperty.PropertyName)
				UpdateMaximumTrackColor ();
			else if (e.PropertyName == ScrubberView.ThumbImageProperty.PropertyName)
				UpdateThumbImage ();
			else if (e.PropertyName == ScrubberView.ThumbColorProperty.PropertyName)
				UpdateThumbColor ();
		}

		void OnControlValueChanged (object sender, EventArgs eventArgs)
		{
			((IElementController)Element).SetValueFromRenderer (ScrubberView.ValueProperty, slider.Value);
		}

		void OnTouchDownControlEvent (object sender, EventArgs e)
		{
			((ISliderController)Element)?.SendDragStarted ();
		}

		void OnTouchUpControlEvent (object sender, EventArgs e)
		{
			((ISliderController)Element)?.SendDragCompleted ();
		}

		void UpdateMaximum ()
		{
			slider.MaxValue = (float)Element.Maximum;
		}

		void UpdateMinimum ()
		{
			slider.MinValue = (float)Element.Minimum;
		}

		void UpdateValue ()
		{
			if (Math.Abs((float)Element.Value - slider.Position) > float.Epsilon)
				slider.Position = (float)Element.Value;
		}
		internal static async Task<UIImage> GetNativeImageAsync (ImageSource source, CancellationToken cancellationToken = default (CancellationToken))
		{
			if (source == null || source.IsEmpty)
				return null;


			var handler = Xamarin.Forms.Internals.Registrar.Registered.GetHandlerForObject<IImageSourceHandler> (source);
			if (handler == null)
				return null;

			try {

				float scale = (float)UIScreen.MainScreen.Scale;

				return await handler.LoadImageAsync (source, scale: scale, cancelationToken: cancellationToken);
			} catch (OperationCanceledException) {
				Log.Warning ("Image loading", "Image load cancelled");
			} catch (Exception ex) {
				Log.Warning ("Image loading", $"Image load failed: {ex}");
			}

			return null;
		}
	}

}