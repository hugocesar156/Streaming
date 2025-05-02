using Streaming.Application.Interfaces;
using Streaming.Domain.Interfaces;
using Streaming.Shared;
using System.Net;

namespace Streaming.Application.UseCases
{
    public class CastUseCase : ICastUseCase
    {
        private readonly ICastRepositories _castRepositories;

        public CastUseCase(ICastRepositories castRepositories)
        {
            _castRepositories = castRepositories;
        }

        public async Task Delete(int id)
        {
            try
            {
                await _castRepositories.Delete(id);
            }
            catch (StreamingException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new StreamingException(HttpStatusCode.InternalServerError, ex.Message, ex.InnerException?.Message);
            }
        }
    }
}
