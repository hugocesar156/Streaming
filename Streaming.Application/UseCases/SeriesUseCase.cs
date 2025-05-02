using Streaming.Application.Interfaces;
using Streaming.Application.Models.Requests.Series;
using Streaming.Domain.Entities;
using Streaming.Domain.Interfaces;
using Streaming.Shared;
using System.Net;

namespace Streaming.Application.UseCases
{
    public class SeriesUseCase : ISeriesUseCase
    {
        private readonly ICatalogRegionRepositories _catalogRegionRepositories;
        private readonly ICategoryRepositories _categoryRepositories;
        private readonly ICastRepositories _castRepositories;
        private readonly ISeriesRepositories _seriesRepositories;

        public SeriesUseCase(ICatalogRegionRepositories catalogRegionRepositories, ICategoryRepositories categoryRepositories, 
            ICastRepositories castRepositories, ISeriesRepositories seriesRepositories)
        {
            _catalogRegionRepositories = catalogRegionRepositories;
            _categoryRepositories = categoryRepositories;
            _castRepositories = castRepositories;
            _seriesRepositories = seriesRepositories;
        }

        public async Task AddInCatalog(SeriesCatalogInsertRequest request)
        {
            try
            {
                await _seriesRepositories.Get(request.IdSeries);

                if (await _seriesRepositories.FindSeriesCatalog(request.IdSeries, request.SeriesRegion.IdLanguage) is not null)
                {
                    throw new StreamingException(HttpStatusCode.MethodNotAllowed, ErrorMessages.ActionNotAllowed, ErrorMessages.Series.RegionCatalog);
                }

                var seriesCatalog = new CatalogRegion(request.SeriesRegion.Name, request.SeriesRegion.Classification, request.SeriesRegion.Synospsis,
                    new Language(request.SeriesRegion.IdLanguage), null, request.IdSeries);

                await _catalogRegionRepositories.Insert(seriesCatalog);
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

        public async Task Insert(SeriesInsertRequest request)
        {
            try
            {
                if (request.Categories.Any())
                {
                    var categories = await _categoryRepositories.GetAll();

                    foreach (var item in request.Categories)
                    {
                        if (!categories.Select(x => x.IdCategory).Contains(item))
                        {
                            throw new StreamingException(HttpStatusCode.UnprocessableEntity, ErrorMessages.RegisterNotFound, string.Format(ErrorMessages.Category.NotFound, item));
                        }
                    }
                }

                var series = new Series(request.Name, request.Thumbnail, request.Year,
                    request.KidsContent, new Language(request.IdLanguage));

                int idSeries = await _seriesRepositories.Insert(series);

                await _seriesRepositories.AddCategories(request.Categories.Distinct().Select(x => new CatalogCategory(x, null, idSeries)).ToList());

                await _castRepositories.InsertRange(request.Casting.Select(x => new Cast(x.Name, x.Character, null, idSeries, 1)).ToList());
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

        public async Task Update(SeriesUpdateRequest request)
        {
            try
            {
                var series = new Series(request.IdSeries, request.Name, request.Thumbnail, request.Year, 
                    request.KidsContent, new Language(request.IdLanguage));

                await _seriesRepositories.Update(series);
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
