using Streaming.Domain.Entities;

namespace Streaming.Domain.Interfaces
{
    public interface ISeriesEpisodeRepositories
    {
        Task<SeriesEpisode?> FindSeriesEpisode(int idSeries, short season, short episode);
        Task Insert(SeriesEpisode request);
    }
}
