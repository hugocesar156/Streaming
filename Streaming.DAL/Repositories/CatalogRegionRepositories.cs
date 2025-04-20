using Streaming.DAL.Context;
using Streaming.DAL.Models;
using Streaming.Domain.Entities;
using Streaming.Domain.Interfaces;

namespace Streaming.DAL.Repositories
{
    public class CatalogRegionRepositories : ICatalogRegionRepositories
    {
        private readonly StreamingDataContext _dataContext;

        public CatalogRegionRepositories(StreamingDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Insert(CatalogRegion request)
        {
            var entity = new CATALOG_REGION
            {
                NAME = request.Name,
                CLASSIFICATION = request.Classification,
                SYNOPSIS = request.Synopsis,
                ID_LANGUAGE = request.Language.IdLanguage,
                ID_FILM = request.IdFilm,
                ID_SERIES_EPISODE = request.IdSeriesEpisode
            };

            _dataContext.Add(entity);
            _dataContext.SaveChanges();
        }
    }
}
