using System;
using gMusic.Managers;
using Xamarin.Forms;

namespace gMusic.Views {
	public class ProgressView : AbsoluteLayout {
		ProgressBar playbackProgress;
		ProgressBar downloadProgress;
		ScrubberView slider;
		public ProgressView ()
		{

			Children.Add (downloadProgress = new ProgressBar {
				ProgressColor = Color.DarkGray,
				Value = 0.8f,
			});

			//Children.Add (playbackProgress = new ProgressBar {
			//	ProgressColor = Color.Fuchsia,
			//});
			AbsoluteLayout.SetLayoutBounds (downloadProgress, new Rectangle (0, 0, 1, 2.5));
			AbsoluteLayout.SetLayoutFlags (downloadProgress, AbsoluteLayoutFlags.WidthProportional);
			Children.Add (slider = new ScrubberView {
				BackgroundColor = Color.Transparent,
				MinimumTrackColor = Styles.Styles.CurrentStyle.AccentColor,
				MaximumTrackColor = Color.Transparent,
				ThumbImageSource = Images.NowPlayingScreen.SliderThumb,
				Minimum = 0,
				Maximum = 1,
				Value = 0,
				EditingDidEnd = () => {
					PlaybackManager.Shared.Seek ((float)slider.Value);
				}
				
			});
			slider.ValueChanged += (s, e) => ValueChanged?.Invoke (this, e);
			
			
			AbsoluteLayout.SetLayoutBounds (slider, new Rectangle (0, -13, 1, 28));
			AbsoluteLayout.SetLayoutFlags (slider, AbsoluteLayoutFlags.WidthProportional);

		}

		public double DownloadProgress {
			get => downloadProgress.Value;
			set => downloadProgress.Value = value;
		}

		public double PlaybackProgress {
			get => slider.Value;
			set => slider.Value = value;
		}

		protected override void LayoutChildren (double x, double y, double width, double height)
		{
			base.LayoutChildren (x, y, width, height);
		}

		public event EventHandler<ValueChangedEventArgs> ValueChanged;

		public class ProgressBar : AbsoluteLayout {
			//BoxView backgroundView;
			BoxView progressView;
			public ProgressBar ()
			{
				AbsoluteLayout.SetLayoutBounds (this, new Rectangle (0, 0, 1, 2.5));
				AbsoluteLayout.SetLayoutFlags (this, AbsoluteLayoutFlags.WidthProportional);
				this.BackgroundColor = Color.Transparent;
				Children.Add (progressView = new BoxView {
					BackgroundColor = Color.Fuchsia,
				});
				AbsoluteLayout.SetLayoutFlags (progressView, AbsoluteLayoutFlags.SizeProportional);
				updateState ();
			}
			double value;
			public double Value {
				get => value;
				set {
					if (Math.Abs(value - this.value) < float.Epsilon)
						return;
					this.value = value;
					updateState ();
				}
			}
			void updateState ()
			{
				AbsoluteLayout.SetLayoutBounds (progressView, new Rectangle (0, 0, Value, 1));
			}

			public Color ProgressColor {
				get => progressView.Color;
				set => progressView.Color = value;
			}
		}

	}


}
