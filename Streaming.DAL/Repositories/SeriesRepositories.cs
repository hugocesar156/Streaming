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

        public async Task AddCategories(List<CatalogCategory> request)
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
            await _dataContext.SaveChangesAsync();
        }

        public async Task<CatalogRegion?> FindSeriesCatalog(int idSeries, int idLanguage)
        {
            var entity = await _dataContext.CATALOG_REGIONs.Include(x => x.ID_LANGUAGENavigation)
                .FirstOrDefaultAsync(x => x.ID_SERIES == idSeries && x.ID_LANGUAGE == idLanguage);

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

        public async Task<Series> Get(int id)
        {
            var entity = await _dataContext.SERIES
                .Include(x => x.ID_LANGUAGENavigation)
                .FirstOrDefaultAsync(x => x.ID_SERIES == id);

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

        public async Task<int> Insert(Series request)
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
            await _dataContext.SaveChangesAsync();

            return entity.ID_SERIES;
        }

        public async Task RemoveCategories(List<CatalogCategory> request)
        {
            var entities = await _dataContext.CATALOG_CATEGORies
                .Where(x => x.ID_SERIES == request.First().IdSeries && request.Select(x => x.IdCategory).Contains(x.ID_CATEGORY)).ToListAsync();

            _dataContext.RemoveRange(entities);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Update(Series request)
        {
            var entity = await _dataContext.SERIES.FirstOrDefaultAsync(x => x.ID_SERIES == request.IdSeries);

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
            await _dataContext.SaveChangesAsync();
        }
    }
}
