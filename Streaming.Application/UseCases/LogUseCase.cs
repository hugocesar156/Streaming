using Streaming.Application.Interfaces;
using Streaming.Application.Models.Services;
using Streaming.Application.Services;
using Streaming.Shared;
using System.Net;

namespace Streaming.Application.UseCases
{
    public class LogUseCase : ILogUseCase
    {
        public LogUseCase()
        {
        }

        public void Delete(DateTime cutOffDate)
        {
            try
            {
                LogServices.Delete(cutOffDate);
            }
            catch (Exception ex)
            {
                throw new StreamingException(HttpStatusCode.InternalServerError, ex.Message, ex.InnerException?.Message);
            }
        }

        public List<Log> GetByInterval(DateTime dateStart, DateTime dateEnd)
        {
            try
            {
               return LogServices.GetByInterval(dateStart, dateEnd);
            }
            catch (Exception ex)
            {
                throw new StreamingException(HttpStatusCode.InternalServerError, ex.Message, ex.InnerException?.Message);
            }
        }
    }
}
