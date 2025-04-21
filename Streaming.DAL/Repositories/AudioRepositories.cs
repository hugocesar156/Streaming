using Streaming.DAL.Context;
using Streaming.DAL.Models;
using Streaming.Domain.Entities;
using Streaming.Domain.Interfaces;

namespace Streaming.DAL.Repositories
{
    public class AudioRepositories : IAudioRepositories
    {
        private readonly StreamingDataContext _dataContext;

        public AudioRepositories(StreamingDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Insert(Audio request)
        {
            var entity = new AUDIO 
            {
                PATH = request.Path,
                ID_LANGUAGE = request.Language.IdLanguage
            };

            _dataContext.Add(entity);
            _dataContext.SaveChanges();
        }
    }
}
