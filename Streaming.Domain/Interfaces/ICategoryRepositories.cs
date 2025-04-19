using Streaming.Domain.Entities;

namespace Streaming.Domain.Interfaces
{
    public interface ICategoryRepositories
    {
        void Delete(int id);
        Category Get(int id);
        List<Category> GetAll();
        void Insert(Category request);
        void Update(Category request);
    }
}
