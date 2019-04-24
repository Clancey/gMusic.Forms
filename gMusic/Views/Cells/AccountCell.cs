using System;
using gMusic.Api;
using gMusic.Managers;
using Localizations;
using Xamarin.Forms;

namespace gMusic.Views.Cells {
	public class AccountCell : ImageCell {
		protected override void OnBindingContextChanged ()
		{
			base.OnBindingContextChanged ();
			var provider = this.BindingContext as MusicProvider;
			if (provider == null)
				return;

			var svg = ApiManager.Shared.GetSvg (provider.ServiceType);
			this.ImageSource = new NGraphicsSVGImageSource { SvgName = svg };
			this.Text = string.IsNullOrWhiteSpace(provider.Email) ?
				string.Format (Strings.SignInToService, ApiManager.Shared.DisplayName (provider.ServiceType))
			: Strings.Logout;

			this.Detail = provider.Email;
		}


		protected override void OnTapped ()
		{
			base.OnTapped ();

			var provider = this.BindingContext as MusicProvider;
			if (provider == null)
				return;
		}

	}
}
