using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using gMusic.Models;
using System.Threading.Tasks;

namespace gMusic.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
		public BaseViewModel()
		{
			RefreshCommand = new Command (async () => await ExecuteRefresh());
		}
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
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

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
