﻿using Streaming.Application.Interfaces;
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
        private readonly IProfileRepositories _profileRepositories;

        public CatalogRegionUseCase(ICatalogRegionRepositories catalogRegionRepositories, ILanguageRepositories languageRepositories, IProfileRepositories profileRepositories)
        {
            _catalogRegionRepositories = catalogRegionRepositories;
            _languageRepositories = languageRepositories;
            _profileRepositories = profileRepositories;
        }

        public async Task<CatalogRegionPageResponse> Get(int idProfile, int pageNumber, int pageSize, int idCategory, string search, string ipAddress)
        {
            try
            {
                var addressByIP = await IPServices.GetAddressByIPAsync(ipAddress);
                var language = await _languageRepositories.GetByCountryCode(addressByIP.CountryCode);
                var profile = await _profileRepositories.Get(idProfile);

                var catalog = await _catalogRegionRepositories.Get(pageNumber, pageSize, language.IdLanguage, idCategory, profile.KidsContent, search);

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

                return new CatalogRegionPageResponse();
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
