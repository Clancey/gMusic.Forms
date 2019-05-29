using System;
using System.Threading.Tasks;
using gMusic.Data;
using gMusic.Managers;
using gMusic.Models;

namespace gMusic.ViewModels {
	public class NowPlayingViewModel : BaseViewModel {

		Song currentSong;
		public Song CurrentSong {
			get => currentSong;
			set {
				if (this.SetProperty (ref currentSong, value))
					SongChanged?.Invoke ();
			}
		}

		public Action SongChanged;

		TrackPosition trackPosition;
		public TrackPosition TrackPosition {
			get => trackPosition;
			set => SetProperty (ref trackPosition, value);
		}

		public NowPlayingViewModel ()
		{
			NotificationManager.Shared.CurrentSongChanged += Shared_CurrentSongChanged;
			if(!string.IsNullOrWhiteSpace(Settings.CurrentSong))
				CurrentSong = Database.Main.GetObject<Song> (Settings.CurrentSong);

			NotificationManager.Shared.CurrentTrackPositionChanged += Shared_CurrentTrackPositionChanged;
		}

		private void Shared_CurrentTrackPositionChanged (object sender, EventArgs<TrackPosition> e)
		{
			TrackPosition = e.Data;
		}

		private void Shared_CurrentSongChanged (object sender, EventArgs<Song> e)
		{
			CurrentSong = e.Data;
		}

		public async Task<bool> ThumbsUp()
		{
			if (currentSong == null)
				return false;
			if(currentSong.Rating != 5)
				return await MusicManager.Shared.ThumbsUp (CurrentSong);

			return await MusicManager.Shared.Unrate (currentSong);
		}

		public async Task<bool> ThumbsDown ()
		{
			if (currentSong == null)
				return false;
			if (currentSong.Rating != 1) {
				return await MusicManager.Shared.ThumbsDown (CurrentSong);
			}

			return await MusicManager.Shared.Unrate (currentSong);
		}
	}
}
