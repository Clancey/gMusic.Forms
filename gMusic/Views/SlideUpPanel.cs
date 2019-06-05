using System;
using gMusic.Views;
using Xamarin.Forms;
namespace gMusic {
	public class SlideUpPanel : MasterDetailPage {

		public SlideUpPanel ()
		{
			this.Title = "gMusic";
		}

		public float OverHang { get; set; } = 74;

		float percentVisible;
		public float PercentVisible {
			get => percentVisible;
			set {
				if (Math.Abs(percentVisible - value) < float.Epsilon)
					return;
				percentVisible = value;
				UpdatePercent ();
			}
		}

		NowPlayingPage _nowPlayingPage;
		NowPlayingPage NowPlayingPage => _nowPlayingPage ?? (_nowPlayingPage = Master as NowPlayingPage);

		void UpdatePercent ()
		{
			NowPlayingPage?.UpdateVisibile (percentVisible);
		}
	}
}
