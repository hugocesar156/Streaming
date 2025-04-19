using Streaming.Application.Models.Requests;
using Streaming.Application.Models.Responses;

namespace Streaming.Application.Interfaces
{
    public interface ICategoryUseCase
    {
        List<CategoryResponse> Get();
        void Post(CategoryRequest request);
    }
}
