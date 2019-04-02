using System;
using Xamarin.Forms;
namespace gMusic
{
	public class SlideUpPanel : MasterDetailPage
	{
		public SlideUpPanel()
		{
            this.Title = "gMusic";
		}

		public float OverHang { get; set; } = 74;
	}
}
