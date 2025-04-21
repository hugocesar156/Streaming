using Streaming.Application.Interfaces;
using Streaming.Application.Models.Responses.CatalogRegion;
using Streaming.Application.Models.Responses.Category;
using Streaming.Application.Services;
using Streaming.Domain.Interfaces;
using Streaming.Shared;
using System.Net;

namespace Streaming.Application.UseCases
{
    public class CatalogRegionUseCase : ICatalogRegionUseCase
    {
        private readonly ICatalogRegionRepositories _catalogRegionRepositories;
        private readonly ILanguageRepositories _languageRepositories;

        public CatalogRegionUseCase(ICatalogRegionRepositories catalogRegionRepositories, ILanguageRepositories languageRepositories)
        {
            _catalogRegionRepositories = catalogRegionRepositories;
            _languageRepositories = languageRepositories;
        }

        public CatalogRegionPageResponse? Get(int pageNumber, int pageSize, string ipAddress)
        {
            try
            {
                var addressByIP = IPServices.GetAddressByIPAsync(ipAddress).Result;
                var language = _languageRepositories.GetByCountryCode(addressByIP.CountryCode);

                var catalog = _catalogRegionRepositories.Get(pageNumber, pageSize, language.IdLanguage);

                if (catalog is not null)
                {
                    var catalogPage = catalog.Response.Select(x => new CatalogRegionPage(
                    x.Name,
                    x.Synopsis,
                    x.IdFim,
                    x.IdSeries,
                    x.Thumbnail,
                    x.Categories.Select(x => new CategoryResponse(
                        x.IdCategory,
                        x.Name)).ToList())).ToList();

                    return new CatalogRegionPageResponse(catalogPage, catalog.CurrentPage, catalog.PageSize, catalog.LastPage, catalog.Total);
                }

                return null;
            }
            catch (StreamingException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new StreamingException(HttpStatusCode.InternalServerError, ex.Message, ex.InnerException?.Message);
            }
        }
    }
}
