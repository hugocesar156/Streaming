using Streaming.Application.Models.Requests.Series;

namespace Streaming.Application.Interfaces
{
    public interface ISeriesUseCase
    {
        void Insert(SeriesInsertRequest request);
    }
}
