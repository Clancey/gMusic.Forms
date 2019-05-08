using System;
using gMusic.Models;

namespace gMusic.Playback {
	public class FadePlayer {
		Player currentPlayer { get; set; }// = new BassPlayer ();
		public FadePlayer ()
		{
		}

		public void PlaySong(Song song)
		{
			currentPlayer.PrepareData (new PlaybackData { SongPlaybackData = new SongPlaybackData () }, true);
			//currentPlayer.Play ();
		}

		public void Play()
		{
			currentPlayer.PrepareData (new PlaybackData { SongPlaybackData = new SongPlaybackData () }, true);
		}
	}
}
