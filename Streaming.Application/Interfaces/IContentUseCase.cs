using Streaming.Application.Models.Requests.Content;
using Streaming.Application.Models.Responses.Contents;

namespace Streaming.Application.Interfaces
{
    public interface IContentUseCase
    {
        Task Delete(int id);
        Task<ContentResponse> Get(int id);
        Task<List<ContentResponse>> GetAll();
        Task Insert(ContentInsertRequest request);
        Task Update(ContentUpdateRequest request);
    }
}
