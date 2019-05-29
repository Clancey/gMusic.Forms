using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using gMusic.Models;
using gMusic.Views;
//using gMusic.Apis;
using SimpleAuth;
using System.Linq;
using gMusic.Data;
using gMusic.Api.GoogleMusic;
using Localizations;
using gMusic.Managers;

namespace gMusic.ViewModels
{
    public class SongsViewModel : SimpleDatabaseViewModel<Song>
    {
        public SongsViewModel()
        {
            Title = Strings.Songs;
        }

		public virtual async void OnTap (Song song)
		{
			await PlaybackManager.Shared.Play (song, Source.GroupInfo);
		}
	}
}