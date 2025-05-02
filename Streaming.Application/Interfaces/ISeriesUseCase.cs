using Streaming.Application.Models.Requests.Series;

namespace Streaming.Application.Interfaces
{
    public interface ISeriesUseCase
    {
        Task AddInCatalog(SeriesCatalogInsertRequest request);
        Task Insert(SeriesInsertRequest request);
        Task Update(SeriesUpdateRequest request);
    }
}
