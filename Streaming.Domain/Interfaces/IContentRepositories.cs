using Streaming.Domain.Entities;

namespace Streaming.Domain.Interfaces
{
    public interface IContentRepositories
    {
        Task Delete(int id);
        Task<Content> Get(int id);
        Task<List<Content>> GetAll();
        Task Insert(Content request);
        Task Update(Content request);
    }
}
