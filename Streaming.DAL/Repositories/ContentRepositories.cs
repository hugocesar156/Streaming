using Microsoft.EntityFrameworkCore;
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

        public async Task Delete(int id)
        {
            var entity = await _dataContext.CONTENTs.FirstOrDefaultAsync(x => x.ID_CONTENT == id);

            if (entity is null)
            {
                throw new StreamingException(HttpStatusCode.UnprocessableEntity, ErrorMessages.RegisterNotFound, string.Format(ErrorMessages.Content.NotFound, id));
            }

            _dataContext.Remove(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Content> Get(int id)
        {
            var entity = await _dataContext.CONTENTs.FirstOrDefaultAsync(x => x.ID_CONTENT == id);

            if (entity is not null)
            {
                return new Content(entity.ID_CONTENT, entity.DESCRIPTION);
            }

            throw new StreamingException(HttpStatusCode.UnprocessableEntity, ErrorMessages.RegisterNotFound, string.Format(ErrorMessages.Content.NotFound, id));
        }

        public async Task<List<Content>> GetAll()
        {
            var entities = await _dataContext.CONTENTs.ToListAsync();

            return entities.Select(x => new Content(x.ID_CONTENT, x.DESCRIPTION)).ToList();
        }

        public async Task Insert(Content request)
        {
            var entity = new CONTENT
            {
                DESCRIPTION = request.Description
            };

            _dataContext.Add(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Update(Content request)
        {
            var entity = await _dataContext.CONTENTs.FirstOrDefaultAsync(x => x.ID_CONTENT == request.IdContent);

            if (entity is null)
            {
                throw new StreamingException(HttpStatusCode.UnprocessableEntity, ErrorMessages.RegisterNotFound, string.Format(ErrorMessages.Content.NotFound, request.IdContent));
            }

            entity.DESCRIPTION = request.Description;

            _dataContext.Update(entity);
            await _dataContext.SaveChangesAsync();
        }
    }
}
