using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using gMusic.Models;
using System.Threading.Tasks;

namespace gMusic.ViewModels
{
    public class BaseViewModel : BaseModel
    {
		public BaseViewModel()
		{
			RefreshCommand = new Command (async () => await ExecuteRefresh());
		}
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { ProcPropertyChanged(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { ProcPropertyChanged (ref title, value); }
        }


		public Command RefreshCommand { get; set; }

		public virtual Task ReloadData () => Task.FromResult (true);

		Task refreshTask;
		public Task ExecuteRefresh()
		{
			if(refreshTask?.IsCompleted ?? true) {
				refreshTask = refresh ();
			}
			return refreshTask;
		}

		async Task refresh()
		{
			IsBusy = true;
			try {
				await ReloadData ();
			} finally {
				IsBusy = false;
			}
		}

        

    }
}
