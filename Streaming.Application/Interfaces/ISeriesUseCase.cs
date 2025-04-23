using Streaming.Application.Models.Requests.Series;

namespace Streaming.Application.Interfaces
{
    public interface ISeriesUseCase
    {
        void AddInCatalog(SeriesCatalogInsertRequest request);
        void Insert(SeriesInsertRequest request);
        void Update(SeriesUpdateRequest request);
    }
}
