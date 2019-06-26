using System;
using System.Threading.Tasks;
using gMusic.Managers;
using gMusic.Models;
using gMusic.ViewModels;
using Localizations;
using Xamarin.Forms;

namespace gMusic.Views {
	public class RadioStationsPage : SimpleDatabaseListView {
		public RadioStationsPage ()
		{
			this.ViewModel = new SimpleDatabaseViewModel<RadioStation> {
				Title = Strings.RadioStations
			};
			this.ToolbarItems.Add (new ToolbarItem {
				Command = new Command(()=>PlayIFL()),
				IconImageSource = Images.DiceIcon,
			});
		}

		Task iflTask;
		Task PlayIFL ()
		{

			if (iflTask?.IsCompleted ?? true)
				iflTask = PlaybackManager.Shared.Play (new RadioStation ("I'm Feeling Lucky") {
					Id = "IFL",
				});
			return iflTask;
		}
	}
}