using Microsoft.EntityFrameworkCore;
using Streaming.DAL.Context;
using Streaming.DAL.Models;
using Streaming.Domain.Entities;
using Streaming.Domain.Interfaces;
using Streaming.Shared;
using System.Net;

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

        public CatalogRegion? FindSeriesCatalog(int idSeries, int idLanguage)
        {
            var entity = _dataContext.CATALOG_REGIONs.Include(x => x.ID_LANGUAGENavigation)
                .FirstOrDefault(x => x.ID_SERIES == idSeries && x.ID_LANGUAGE == idLanguage);

            if (entity is not null)
            {
                return new CatalogRegion(
                    entity.ID_CATALOG_REGION,
                    entity.NAME,
                    entity.CLASSIFICATION,
                    entity.SYNOPSIS,
                    new Language(
                        entity.ID_LANGUAGENavigation.ID_LANGUAGE,
                        entity.ID_LANGUAGENavigation.DESCRIPTION,
                        entity.ID_LANGUAGENavigation.CODE,
                        entity.ID_LANGUAGENavigation.COUNTRY_CODE),
                    entity.ID_FILM,
                    entity.ID_SERIES);
            }

            return null;
        }

        public Series Get(int id)
        {
            var entity = _dataContext.SERIES
                .Include(x => x.ID_LANGUAGENavigation)
                .FirstOrDefault(x => x.ID_SERIES == id);

            if (entity is not null)
            {
                return new Series(
                    entity.ID_SERIES, 
                    entity.NAME, 
                    entity.THUMBNAIL, 
                    entity.YEAR, 
                    entity.KIDS_CONTENT,
                    
                    new Language(
                        entity.ID_LANGUAGENavigation.ID_LANGUAGE,
                        entity.ID_LANGUAGENavigation.DESCRIPTION,
                        entity.ID_LANGUAGENavigation.CODE,
                        entity.ID_LANGUAGENavigation.COUNTRY_CODE));
            }

            throw new StreamingException(HttpStatusCode.UnprocessableEntity, ErrorMessages.RegisterNotFound, string.Format(ErrorMessages.Series.NotFound, id));
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

        public void Update(Series request)
        {
            var entity = _dataContext.SERIES.FirstOrDefault(x => x.ID_SERIES == request.IdSeries);

            if (entity is null)
            {
                throw new StreamingException(HttpStatusCode.UnprocessableEntity, ErrorMessages.RegisterNotFound, string.Format(ErrorMessages.Series.NotFound, request.IdSeries));
            }

            entity.NAME = request.Name;
            entity.THUMBNAIL = request.Thumbnail;
            entity.YEAR = request.Year;
            entity.KIDS_CONTENT = request.KidsContent;
            entity.ID_LANGUAGE = request.Language.IdLanguage;

            _dataContext.Update(entity);
            _dataContext.SaveChanges();
        }
    }
}
