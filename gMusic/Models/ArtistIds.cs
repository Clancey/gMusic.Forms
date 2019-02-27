using System;
using System.Collections.Generic;
using System.Text;
using gMusic.Api;
using SQLite;

namespace gMusic.Models
{
	internal class TempArtistIds : ArtistIds
	{
	}

	public class ArtistIds : BaseModel
	{
		[PrimaryKey]
		public string Id { get; set; }

		[Indexed]
		public string ArtistId { get; set; }

		[Indexed]
		public ServiceType ServiceType { get; set; }
	}
}