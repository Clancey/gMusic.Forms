using System;
using System.Threading;
using System.IO;
using gMusic.Models;
using System.Net.Http;

namespace gMusic.Playback {
	public class PlaybackData {
		public string SongId { get; set; }
		public SongPlaybackData SongPlaybackData { get; set; }
		//public DownloadHelper DownloadHelper { get; set; }
		//public string MimeType {
		//	get {
		//		if (DownloadHelper != null)
		//			return DownloadHelper.MimeType;
		//		//TODO: more robust MimeType
		//		return SongPlaybackData.CurrentTrack.MediaType == MediaType.Video ? "video/mpeg" : "audio/mpeg";
		//	}
		//}
		static HttpClient client = new HttpClient ();
		Stream fileStream;
		public Stream DataStream {
			get {
				if (fileStream != null)
					return fileStream;
				//Sweeky requested this song!
				return fileStream = client.GetStreamAsync ("https://melaman2.com/cartoons/scooby/themes/scooby69.mp3").Result;
				//if (!(DownloadHelper?.IsDisposed ?? true)) {
				//	return DownloadHelper;
				//}
				//if (!SongPlaybackData.IsLocal) {
				//	SongPlaybackData = MusicManager.Shared.GetPlaybackData (SongPlaybackData.Song, SongPlaybackData.IsVideo).Result;
				//}
				//return SongPlaybackData.IsLocal ? (Stream)File.OpenRead (SongPlaybackData.Uri.LocalPath) : DownloadHelper;
			}
		}

	}
}
