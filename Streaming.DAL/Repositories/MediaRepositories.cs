using Streaming.DAL.Context;
using Streaming.DAL.Models;
using Streaming.Domain.Entities;
using Streaming.Domain.Interfaces;

namespace Streaming.DAL.Repositories
{
    public class MediaRepositories : IMediaRepositories
    {
        private readonly StreamingDataContext _dataContext;

        public MediaRepositories(StreamingDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Insert(Media request)
        {
            var entity = new MEDIum
            {
                PATH = request.Path,
                ID_RESOLUTION = request.Resolution.IdResolution,
                ID_FILM = request.IdFilm,
                ID_SERIES_EPISODE = request.IdSeriesEpisode
            };

            _dataContext.Add(entity);
            _dataContext.SaveChanges();
        }
    }
}
