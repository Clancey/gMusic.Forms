using System;
using System.Threading.Tasks;
namespace gMusic.Models {
	public interface IMultiImage {
		Task<Artwork []> GetAllArtwork ();
	}
}
