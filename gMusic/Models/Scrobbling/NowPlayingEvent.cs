using System;
using System.Collections.Generic;
using System.Text;

namespace gMusic.Models.Scrobbling
{
	internal class NowPlayingEvent : SongPlaybackEvent
	{
		public double Duration { get; set; }
	}
}