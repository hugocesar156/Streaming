using Streaming.Application.Models.Responses.CatalogRegion;

namespace Streaming.Application.Interfaces
{
    public interface ICatalogRegionUseCase
    {
        Task<CatalogRegionPageResponse> Get(int idProfile, int pageNumber, int pageSize, int idCategory, string search, string ipAddress);
    }
}
