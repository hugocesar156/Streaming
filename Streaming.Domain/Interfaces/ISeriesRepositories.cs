using Streaming.Domain.Entities;

namespace Streaming.Domain.Interfaces
{
    public interface ISeriesRepositories
    {
        void AddCategories(List<CatalogCategory> request);
        int Insert(Series request);
        void RemoveCategories(List<CatalogCategory> request);
    }
}
