using System;
using System.Collections.Generic;
using System.Text;
using gMusic.Data;
using SQLite;
using System.Threading.Tasks;
using Localizations;
using System.Linq;

namespace gMusic.Models
{
	internal class TempGenre : Genre
	{
	}

	public class Genre : MediaItemBase, IMultiImage {
		public Genre()
		{
		}

		public Genre(string name) : base(name)
		{
			Id = name;
		}

		public int SongCount { get; set; }
		public int AlbumCount { get; set; }

		public override string ToString()
		{
			return Name;
		}

		string AlbumString => AlbumCount > 1 ? Strings.Albums : Strings.Album;
		string SongString => SongCount == 1 ? Strings.Song : Strings.Songs;

		public override string DetailText => $"{AlbumCount} {AlbumString} • {SongCount} {SongString}";


		public override bool ShouldBeLocal()
		{
			return Database.Main.GetObject<GenreOfflineClass>(Id)?.ShouldBeLocal == true;
		}
		AlbumArtwork[] allArtwork;

		[Ignore]
		public AlbumArtwork[] AllArtwork
		{
			set { allArtwork = value; }
		}

		public async Task<Artwork []> GetAllArtwork()
		{
			if (allArtwork != null)
				return allArtwork;

			var art = await Database.Main.QueryAsync<AlbumArtwork>("select distinct ar.* from AlbumArtwork ar inner join Song s on s.AlbumId = ar.AlbumId and s.Genre = ? limit 4", Id) ??
				new List<AlbumArtwork>();
			var tempArtwork = await
				Database.Main.QueryAsync<TempAlbumArtwork>(
					"select distinct ar.* from TempAlbumArtwork ar inner join TempSong s on s.AlbumId = ar.AlbumId and s.Genre = ? limit 4",
					Id);

			if (tempArtwork != null)
				art.AddRange(tempArtwork);
			return allArtwork = art.Distinct().Take(4).ToArray();
		}
	}
}