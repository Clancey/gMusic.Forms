using System;
using Localizations;
using Xamarin.Forms;
using System.Linq;
using gMusic.Managers;
using FFImageLoading.Svg.Forms;
using gMusic.Views.Cells;

namespace gMusic.Views {
	public class SettingsPage : ContentPage {

		TableSection accountsSection;
		TextCell themeCell;
		Cell loginCell;
		public SettingsPage ()
		{
			this.Title = Strings.Settings;
			loginCell = new TextCell {
				Text = Strings.AddStreamingService,
			};
			loginCell.Tapped += async (sender,e) => {
				try {
					//TODO: Add service picker later
					var s = await ApiManager.Shared.CreateAndLogin (Api.ServiceType.Google);
				} catch (Exception ex) {
					Console.WriteLine (ex);
				}
			};
			Content = new TableView {
				HasUnevenRows = true,
				Root = new TableRoot () {
					(accountsSection = new TableSection (Strings.Accounts) {
						loginCell,
					}),
					new TableSection (Strings.Settings) {
						(themeCell = new TextCell {
							Text = Strings.Theme,
							Detail = Styles.Styles.CurrentStyle.Id,
							Command = new Command(async () => {
								var firstOption = Styles.Styles.AvailableStyles[0].Id;
								var remaining = Styles.Styles.AvailableStyles.Skip(1).Select(x=> x.Id).ToArray();
								var selection = await DisplayActionSheet(Strings.Theme,Strings.Cancel,firstOption,remaining);
                                if(selection ==  Strings.Cancel)
                                    return;
								Console.WriteLine(selection);
								var newStyle = Styles.Styles.AvailableStyles.First(x=> x.Id == selection);
								if(Styles.Styles.CurrentStyle ==  newStyle)
									return;
								Styles.Styles.CurrentStyle = newStyle;
								themeCell.Detail = selection;
							}),
						}),
					}
				}
			};
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			ResfreshAccountsSettings ();
		}

		void ResfreshAccountsSettings()
		{
			accountsSection.Clear ();
			ApiManager.Shared.CurrentProviders.ForEach (x => {
				accountsSection.Add (new AccountCell { BindingContext = x });
			});
			accountsSection.Add (loginCell);
		}
	}
}

