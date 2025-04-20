using Streaming.Application.Interfaces;
using Streaming.Application.Models.Requests.Content;
using Streaming.Application.Models.Responses.Contents;
using Streaming.Domain.Entities;
using Streaming.Domain.Interfaces;
using Streaming.Shared;
using System.Net;

namespace Streaming.Application.UseCases
{
    public class ContentUseCase : IContentUseCase
    {
        private readonly IContentRepositories _contentRepositories;

        public ContentUseCase(IContentRepositories contentRepositories)
        {
            _contentRepositories = contentRepositories;
        }

        public void Delete(int id)
        {
            try
            {
                _contentRepositories.Delete(id);
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

        public ContentResponse Get(int id)
        {
            try
            {
                var content = _contentRepositories.Get(id);
                return new ContentResponse(content.IdContent, content.Description);
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

        public List<ContentResponse> GetAll()
        {
            try
            {
                var contents = _contentRepositories.GetAll();
                return contents.Select(x => new ContentResponse(x.IdContent, x.Description)).ToList();
            }
            catch (Exception ex)
            {
                throw new StreamingException(HttpStatusCode.InternalServerError, ex.Message, ex.InnerException?.Message);
            }
        }

        public void Insert(ContentInsertRequest request)
        {
            try
            {
                var content = new Content(request.Description);
                _contentRepositories.Insert(content);
            }
            catch (Exception ex) 
            {
                throw new StreamingException(HttpStatusCode.InternalServerError, ex.Message, ex.InnerException?.Message);
            }
        }

        public void Update(ContentUpdateRequest request)
        {
            try
            {
                var content = new Content(request.IdContent, request.Description);
                _contentRepositories.Update(content);
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
