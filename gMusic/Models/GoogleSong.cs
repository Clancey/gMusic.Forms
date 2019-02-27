using System;
using SQLite;
namespace gMusic.Models
{
    public class GoogleSong
    {
        public string Id { get; set; }

        public string CharacterId { get; set; }

        public string Title { get; set; }

        public string Artist { get; set; }

        public DateTime TimeStamp { get; set; }

    }
}
