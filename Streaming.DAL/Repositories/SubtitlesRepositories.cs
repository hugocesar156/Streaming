using Streaming.DAL.Context;
using Streaming.DAL.Models;
using Streaming.Domain.Entities;
using Streaming.Domain.Interfaces;

namespace Streaming.DAL.Repositories
{
    public class SubtitlesRepositories : ISubtitlesRepositories
    {
        private readonly StreamingDataContext _dataContext;

        public SubtitlesRepositories(StreamingDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Insert(Subtitles request)
        {
            var entity = new SUBTITLE
            {
                PATH = request.Path,
                ID_LANGUAGE = request.Language.IdLanguage,
                ID_FILM = request.IdFilm,
                ID_SERIES_EPISODE = request.IdSeriesEpisode
            };

            _dataContext.Add(entity);
            _dataContext.SaveChanges();
        }
    }
}
