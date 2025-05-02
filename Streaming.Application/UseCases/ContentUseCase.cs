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

        public async Task Delete(int id)
        {
            try
            {
                await _contentRepositories.Delete(id);
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

        public async Task<ContentResponse> Get(int id)
        {
            try
            {
                var content = await _contentRepositories.Get(id);
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

        public async Task<List<ContentResponse>> GetAll()
        {
            try
            {
                var contents = await _contentRepositories.GetAll();
                return contents.Select(x => new ContentResponse(x.IdContent, x.Description)).ToList();
            }
            catch (Exception ex)
            {
                throw new StreamingException(HttpStatusCode.InternalServerError, ex.Message, ex.InnerException?.Message);
            }
        }

        public async Task Insert(ContentInsertRequest request)
        {
            try
            {
                var content = new Content(request.Description);
                await _contentRepositories.Insert(content);
            }
            catch (Exception ex) 
            {
                throw new StreamingException(HttpStatusCode.InternalServerError, ex.Message, ex.InnerException?.Message);
            }
        }

        public async Task Update(ContentUpdateRequest request)
        {
            try
            {
                var content = new Content(request.IdContent, request.Description);
                await _contentRepositories.Update(content);
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
