using Streaming.Application.Models.Requests.CatalogRegion;
using Streaming.Application.Validations;

namespace Streaming.Application.Models.Requests.Series
{
    public class SeriesCatalogInsertRequest
    {
        [Required]
        public int IdSeries { get; init; }

        public required CatalogRegionRequest SeriesRegion { get; init; }
    }
}
