using Streaming.Domain.Entities;

namespace Streaming.Domain.Interfaces
{
    public interface ISeriesRepositories
    {
        void AddCategories(List<CatalogCategory> request);
        CatalogRegion? FindSeriesCatalog(int idSeries, int idLanguage);
        Series Get(int id);
        int Insert(Series request);
        void RemoveCategories(List<CatalogCategory> request);
        void Update(Series request);
    }
}
