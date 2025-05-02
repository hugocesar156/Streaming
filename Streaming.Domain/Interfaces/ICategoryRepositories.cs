using Streaming.Domain.Entities;

namespace Streaming.Domain.Interfaces
{
    public interface ICategoryRepositories
    {
        Task Delete(int id);
        Task<Category> Get(int id);
        Task<List<Category>> GetAll();
        Task Insert(Category request);
        Task Update(Category request);
    }
}
