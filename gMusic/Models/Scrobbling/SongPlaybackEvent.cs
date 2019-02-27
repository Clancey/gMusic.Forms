using System;
using System.Collections.Generic;
using System.Text;
using gMusic.Data;
using SQLite;

namespace gMusic.Models.Scrobbling
{
	public class SongPlaybackEvent
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }

		public string SongId { get; set; }

		public string TrackId { get; set; }

		public string Title { get; set; }

		public string Artist { get; set; }

		public string Album { get; set; }

		public DateTime Time { get; set; } = DateTime.Now;

		[Ignore]
		public PlaybackContext Context { get; set; }

		public int ContextId { get; set; }
	}
}