using Streaming.Domain.Entities;

namespace Streaming.Domain.Interfaces
{
    public interface ISeriesRepositories
    {
        Task AddCategories(List<CatalogCategory> request);
        Task<CatalogRegion?> FindSeriesCatalog(int idSeries, int idLanguage);
        Task<Series> Get(int id);
        Task<int> Insert(Series request);
        Task RemoveCategories(List<CatalogCategory> request);
        Task Update(Series request);
    }
}
