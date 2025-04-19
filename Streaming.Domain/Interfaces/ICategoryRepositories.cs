using Streaming.Domain.Entities;

namespace Streaming.Domain.Interfaces
{
    public interface ICategoryRepositories
    {
        List<Category> Get();
        void Post(Category request);
    }
}
