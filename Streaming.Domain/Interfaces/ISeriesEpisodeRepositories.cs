using Streaming.Domain.Entities;

namespace Streaming.Domain.Interfaces
{
    public interface ISeriesEpisodeRepositories
    {
        SeriesEpisode? FindSeriesEpisode(int idSeries, short season, short episode);
        void Insert(SeriesEpisode request);
    }
}
