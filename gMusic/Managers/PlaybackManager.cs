using System;
using System.Threading.Tasks;
using gMusic.Models;
using gMusic.Playback;

namespace gMusic.Managers {
	public class PlaybackManager : ManagerBase<PlaybackManager> {
		public FadePlayer Player { get; } = new FadePlayer ();
		public async void Play ()
		{
			Player.Play ();
		}

		public async void Pause ()
		{

		}

		public void Next()
		{

		}

		public void Previous()
		{

		}

		public void Play (Song song)
		{
			Player.PlaySong (song,false,true);
		}

		public void NextTrackWithoutPause()
		{

		}
	}
}
