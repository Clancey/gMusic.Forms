using System;
using gMusic.Models;
using gMusic.Data;
namespace gMusic.ViewModels
{
    class ArtistSongsViewModel : SongsViewModel
    {

        Artist artist;

        public Artist Artist
        {
            set
            {
                var group = Database.Main.GetGroupInfo<Song>().Clone();
                group.Filter = "ArtistId = @ArtistId";
                group.Params["@ArtistId"] = value.Id;
                group.From = "Song";
                Title = value.Name;
                Source.GroupInfo = group;
                artist = value;
            }
            get { return artist; }
        }
    }
}
