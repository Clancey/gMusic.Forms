using System;
using Localizations;
using Xamarin.Forms;
using System.Linq;

namespace gMusic.Views {
	public class SettingsPage : ContentPage {

		TableSection accountsSection;
		TextCell themeCell;
		public SettingsPage ()
		{
			this.Title = Strings.Settings;
			Content = new TableView {
				HasUnevenRows = true,
				Root = new TableRoot () {
					(accountsSection = new TableSection (Strings.Accounts) {

					}),
					new TableSection (Strings.Settings) {
						(themeCell = new TextCell {
							Text = Strings.Theme,
							Detail = Styles.Styles.CurrentStyle.Id,
							Command = new Command(async () => {
								var firstOption = Styles.Styles.AvailableStyles[0].Id;
								var remaining = Styles.Styles.AvailableStyles.Skip(1).Select(x=> x.Id).ToArray();
								var selection = await DisplayActionSheet(Strings.Theme,Strings.Cancel,firstOption,remaining);
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
	}
}

