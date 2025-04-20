using Streaming.Application.Models.Requests.CatalogRegion;
using Streaming.Application.Validations;

namespace Streaming.Application.Models.Requests.Film
{
    public class FilmCatalogInsertRequest
    {
        [Required]
        public int IdFilm { get; init; }

        public required CatalogRegionRequest FilmRegion { get; init; }
    }
}
