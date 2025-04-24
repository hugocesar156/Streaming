using Streaming.Application.Models.Requests.SeriesEpisode;

namespace Streaming.Application.Interfaces
{
    public interface ISeriesEpisodeUseCase
    {
        void Insert(SeriesEpisodeInsertRequest request);
    }
}
