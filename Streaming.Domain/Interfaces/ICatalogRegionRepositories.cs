using Streaming.Domain.Entities;
using Streaming.Domain.StoredProcedures;

namespace Streaming.Domain.Interfaces
{
    public interface ICatalogRegionRepositories
    {
        Task<CatalogByRegionProcedure?> Get(int pageNumber, int pageSize, int idLanguage, int idCategory, bool kidsContent, string search);
        Task Insert(CatalogRegion request);
    }
}
