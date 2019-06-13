using System;
using Xamarin.Forms;

namespace gMusic.Views {
	public class ScrubberView : Slider {

		public Action EditingDidBegin;
		public Action EditingDidEnd;
		public ScrubberView ()
		{
		}
	}
}
