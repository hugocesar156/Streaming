using Streaming.Application.Models.Requests.Category;
using Streaming.Application.Models.Responses.Category;

namespace Streaming.Application.Interfaces
{
    public interface ICategoryUseCase
    {
        Task Delete(int id);
        Task<CategoryResponse> Get(int id);
        Task<List<CategoryResponse>> GetAll();
        Task Insert(CategoryInsertRequest request);
        Task Update(CategoryUpdateRequest request);
    }
}
