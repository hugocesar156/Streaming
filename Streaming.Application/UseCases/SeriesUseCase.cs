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
        private readonly ICategoryRepositories _categoryRepositories;
        private readonly ICastRepositories _castRepositories;
        private readonly ISeriesRepositories _seriesRepositories;

        public SeriesUseCase(ICategoryRepositories categoryRepositories, ICastRepositories castRepositories,
            ISeriesRepositories seriesRepositories)
        {
            _categoryRepositories = categoryRepositories;
            _castRepositories = castRepositories;
            _seriesRepositories = seriesRepositories;
        }

        public void Insert(SeriesInsertRequest request)
        {
            try
            {
                if (request.Categories.Any())
                {
                    var categories = _categoryRepositories.GetAll();

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

                int idSeries = _seriesRepositories.Insert(series);

                _seriesRepositories.AddCategories(request.Categories.Distinct().Select(x => new CatalogCategory(x, null, idSeries)).ToList());

                _castRepositories.InsertRange(request.Casting.Select(x => new Cast(x.Name, x.Character, null, idSeries, 1)).ToList());
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
