using Streaming.Application.Models.Responses.CatalogRegion;

namespace Streaming.Application.Interfaces
{
    public interface ICatalogRegionUseCase
    {
        CatalogRegionPageResponse Get(int pageNumber, int pageSize, string search, string ipAddress);
    }
}
