using Streaming.DAL.Context;
using Streaming.Domain.Entities;
using Streaming.Domain.Interfaces;
using Streaming.Shared;
using System.Net;

namespace Streaming.DAL.Repositories
{
    public class CastRepositories : ICastRepositories
    {
        private readonly StreamingDataContext _dataContext;

        public CastRepositories(StreamingDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Delete(int id)
        {
            var entity = _dataContext.CASTs.FirstOrDefault(x => x.ID_CAST == id);

            if (entity is null)
            {
                throw new StreamingException(HttpStatusCode.UnprocessableEntity, ErrorMessages.RegisterNotFound, string.Format(ErrorMessages.Cast.NotFound, id));
            }

            _dataContext.Remove(entity);
            _dataContext.SaveChanges();
        }

        public void Update(Cast request)
        {
            var entity = _dataContext.CASTs.FirstOrDefault(x => x.ID_CAST == request.IdCast);

            if (entity is null)
            {
                throw new StreamingException(HttpStatusCode.UnprocessableEntity, ErrorMessages.RegisterNotFound, string.Format(ErrorMessages.Cast.NotFound, request.IdCast));
            }

            entity.NAME = request.Name;
            entity.CHARACTER = request.Character;
            entity.SEASON = request.Season;

            _dataContext.Update(entity);
            _dataContext.SaveChanges();
        }
    }
}
