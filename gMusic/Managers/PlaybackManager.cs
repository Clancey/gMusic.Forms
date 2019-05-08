using System;
using System.Threading.Tasks;
using gMusic.Playback;

namespace gMusic.Managers {
	public class PlaybackManager : ManagerBase<PlaybackManager> {
		public FadePlayer Player { get; } = new FadePlayer ();
		public async void Play ()
		{
			
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
	}
}
