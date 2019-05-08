using System;
using gMusic.Managers;
using gMusic.Models;

namespace gMusic.Playback {
	public class FadePlayer {
		public static Func<PlaybackData, Player> CreatePlayer { get; set; }
		Player currentPlayer { get; set; }// = new BassPlayer ();
		public FadePlayer ()
		{
		}

		public void PlaySong(Song song)
		{
			//var pd = new PlaybackData {
			//	SongPlaybackData = new SongPlaybackData ()
			//};

			//MusicManager.Shared.GetTrack()

			//currentPlayer = CreatePlayer (pd);


			//currentPlayer.PrepareData (pd, true);
			//currentPlayer.Play ();
		}

		public void Play()
		{
			var pd = new PlaybackData {
				SongPlaybackData = new SongPlaybackData ()
			};
			currentPlayer = CreatePlayer (pd);

			currentPlayer.Play ();
		}
	}
}
