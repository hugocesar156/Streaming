using Microsoft.EntityFrameworkCore;
using Streaming.DAL.Context;
using Streaming.DAL.Models;
using Streaming.Domain.Entities;
using Streaming.Domain.Interfaces;

namespace Streaming.DAL.Repositories
{
    public class SeriesEpisodeRepositories : ISeriesEpisodeRepositories
    {
        private readonly StreamingDataContext _dataContext;

        public SeriesEpisodeRepositories(StreamingDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<SeriesEpisode?> FindSeriesEpisode(int idSeries, short season, short episode)
        {
            var entity = await _dataContext.SERIES_EPISODEs
                .FirstOrDefaultAsync(x => x.ID_SERIES == idSeries && x.SEASON == season && x.EPISODE == episode);

            if (entity is not null)
            {
                return new SeriesEpisode(
                    entity.ID_SERIES_EPISODE, 
                    entity.NAME,
                    entity.THUMBNAIL,
                    entity.SYNOPSIS,
                    entity.SEASON,
                    entity.EPISODE,
                    entity.DURATION,
                    entity.YEAR,
                    entity.OPENING_START,
                    entity.CREDITS_START,
                    entity.ID_SERIES);
            }

            return null;
        }

        public async Task Insert(SeriesEpisode request)
        {
            var entity = new SERIES_EPISODE
            {
                NAME = request.Name,
                SYNOPSIS = request.Synopsis,
                THUMBNAIL = request.Thumbnail,
                SEASON = request.Season,
                EPISODE = request.Episode,
                YEAR = request.Year,
                DURATION = request.Duration,
                OPENING_START = request.OpeningStart,
                CREDITS_START = request.CreditsStart,
                ID_SERIES = request.IdSeries
            };

            _dataContext.Add(entity);
            await _dataContext.SaveChangesAsync();
        }
    }
}
