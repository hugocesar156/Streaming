using Streaming.DAL.Context;
using Streaming.DAL.Models;
using Streaming.Domain.Entities;
using Streaming.Domain.Interfaces;
using Streaming.Shared;
using System.Net;

namespace Streaming.DAL.Repositories
{
    public class ContentRepositories : IContentRepositories
    {
        private readonly StreamingDataContext _dataContext;

        public ContentRepositories(StreamingDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Delete(int id)
        {
            var entity = _dataContext.CONTENTs.FirstOrDefault(x => x.ID_CONTENT == id);

            if (entity is null)
            {
                throw new StreamingException(HttpStatusCode.UnprocessableEntity, ErrorMessages.RegisterNotFound, string.Format(ErrorMessages.Content.NotFound, id));
            }

            _dataContext.Remove(entity);
            _dataContext.SaveChanges();
        }

        public Content Get(int id)
        {
            var entity = _dataContext.CONTENTs.FirstOrDefault(x => x.ID_CONTENT == id);

            if (entity is not null)
            {
                return new Content(entity.ID_CONTENT, entity.DESCRIPTION);
            }

            throw new StreamingException(HttpStatusCode.UnprocessableEntity, ErrorMessages.RegisterNotFound, string.Format(ErrorMessages.Content.NotFound, id));
        }

        public List<Content> GetAll()
        {
            var entities = _dataContext.CONTENTs.ToList();

            return entities.Select(x => new Content(x.ID_CONTENT, x.DESCRIPTION)).ToList();
        }

        public void Insert(Content request)
        {
            var entity = new CONTENT
            {
                DESCRIPTION = request.Description
            };

            _dataContext.Add(entity);
            _dataContext.SaveChanges();
        }

        public void Update(Content request)
        {
            var entity = _dataContext.CONTENTs.FirstOrDefault(x => x.ID_CONTENT == request.IdContent);

            if (entity is null)
            {
                throw new StreamingException(HttpStatusCode.UnprocessableEntity, ErrorMessages.RegisterNotFound, string.Format(ErrorMessages.Content.NotFound, request.IdContent));
            }

            entity.DESCRIPTION = request.Description;

            _dataContext.Update(entity);
            _dataContext.SaveChanges();
        }
    }
}
