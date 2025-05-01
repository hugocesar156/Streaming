using Streaming.Domain.Entities;
using Streaming.Domain.StoredProcedures;

namespace Streaming.Domain.Interfaces
{
    public interface ICatalogRegionRepositories
    {
        public CatalogByRegionProcedure? Get(int pageNumber, int pageSize, int idLanguage, int idCategory, bool kidsContent, string search);
        public void Insert(CatalogRegion request);
    }
}
