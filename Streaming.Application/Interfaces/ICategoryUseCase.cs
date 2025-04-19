using Streaming.Application.Models.Requests;
using Streaming.Application.Models.Responses;

namespace Streaming.Application.Interfaces
{
    public interface ICategoryUseCase
    {
        void Delete(int id);
        CategoryResponse Get(int id);
        List<CategoryResponse> GetAll();
        void Insert(CategoryInsertRequest request);
        void Update(CategoryUpdateRequest request);
    }
}
