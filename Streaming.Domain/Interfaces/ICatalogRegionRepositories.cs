using Streaming.Domain.Entities;

namespace Streaming.Domain.Interfaces
{
    public interface ICatalogRegionRepositories
    {
        public void Insert(CatalogRegion request);
    }
}
