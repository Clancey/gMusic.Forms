using System;
using gMusic.ViewModels;
using Xamarin.Forms;

namespace gMusic.Views {
	public class MenuDataTemplateSelector : DataTemplateSelector {
		public DataTemplate MenuItem { get; set; }
		public DataTemplate MenuSection { get; set; }


		protected override DataTemplate OnSelectTemplate (object item, BindableObject container) =>
			((NavigationItem)item).Page == null ? MenuSection : MenuItem;
		
	}
}
