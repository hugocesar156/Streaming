using Streaming.Application.Models.Requests;
using Streaming.Application.Models.Responses;

namespace Streaming.Application.Interfaces
{
    public interface IContentUseCase
    {
        void Delete(int id);
        ContentResponse Get(int id);
        List<ContentResponse> GetAll();
        void Insert(ContentInsertRequest request);
        void Update(ContentUpdateRequest request);
    }
}
