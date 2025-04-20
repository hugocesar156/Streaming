using Streaming.DAL.Context;
using Streaming.Domain.Entities;
using Streaming.Domain.Interfaces;

namespace Streaming.DAL.Repositories
{
    public class CastRepositories : ICastRepositories
    {
        private readonly StreamingDataContext _dataContext;

        public CastRepositories(StreamingDataContext dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
