using System;
using gMusic.Data;
using gMusic.Models;
namespace gMusic.ViewModels
{
    public class ArtistAlbumViewModel : SimpleDatabaseViewModel<Album>
    {
        Artist artist;

        public Artist Artist
        {
            set
            {
                var group = Database.Main.GetGroupInfo<Album>().Clone();
                group.Filter = "ArtistId = @ArtistId";
                group.Params["@ArtistId"] = value.Id;
                Title = value.Name;
                Source.GroupInfo = group;
                artist = value;
            }
            get { return artist; }
        }
    }
}
