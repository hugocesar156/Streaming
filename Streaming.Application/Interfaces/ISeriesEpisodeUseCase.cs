using Streaming.Application.Models.Requests.SeriesEpisode;

namespace Streaming.Application.Interfaces
{
    public interface ISeriesEpisodeUseCase
    {
        Task Insert(SeriesEpisodeInsertRequest request);
    }
}
