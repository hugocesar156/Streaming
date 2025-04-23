using Streaming.DAL.Context;
using Streaming.DAL.Models;
using Streaming.Domain.Entities;
using Streaming.Domain.Interfaces;

namespace Streaming.DAL.Repositories
{
    public class SeriesRepositories : ISeriesRepositories
    {
        private readonly StreamingDataContext _dataContext;

        public SeriesRepositories(StreamingDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void AddCategories(List<CatalogCategory> request)
        {
            var entities = new List<CATALOG_CATEGORY>();

            foreach (var item in request)
            {
                entities.Add(new CATALOG_CATEGORY
                {
                    ID_SERIES = item.IdSeries,
                    ID_CATEGORY = item.IdCategory
                });
            }

            _dataContext.AddRange(entities);
            _dataContext.SaveChanges();
        }

        public int Insert(Series request)
        {
            var entity = new SERIES
            {
                NAME = request.Name,
                THUMBNAIL = request.Thumbnail,
                YEAR = request.Year,
                KIDS_CONTENT = request.KidsContent,
                ID_LANGUAGE = request.Language.IdLanguage
            };

            _dataContext.Add(entity);
            _dataContext.SaveChanges();

            return entity.ID_SERIES;
        }

        public void RemoveCategories(List<CatalogCategory> request)
        {
            var entities = _dataContext.CATALOG_CATEGORies
                .Where(x => x.ID_SERIES == request.First().IdSeries && request.Select(x => x.IdCategory).Contains(x.ID_CATEGORY)).ToList();

            _dataContext.RemoveRange(entities);
            _dataContext.SaveChanges();
        }
    }
}
