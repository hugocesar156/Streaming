using Streaming.Application.Models.Services;

namespace Streaming.Application.Interfaces
{
    public interface ILogUseCase
    {
        void Delete(DateTime cutOffDate);
        List<Log> GetByInterval(DateTime dateStart, DateTime dateEnd);
    }
}
