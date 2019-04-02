using System;
using System.Threading.Tasks;
using gMusic.Api.GoogleMusic;
using gMusic.Data;
using gMusic.Managers;

namespace gMusic.ViewModels {
	public class SimpleDatabaseViewModel<T> : BaseViewModel  where T: new (){
		public SimpleDatabaseSource<T> Source { get; set; } = new SimpleDatabaseSource<T> (Database.Main);
		public override async Task ReloadData ()
		{
			try {
				await ApiManager.Shared.StartSync ();
				Source.ResfreshData ();
			}
			catch(Exception ex) {
				LogManager.Shared.Report (ex);
			}
		}
	}
}
