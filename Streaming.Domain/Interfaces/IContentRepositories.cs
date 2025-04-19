using Streaming.Domain.Entities;

namespace Streaming.Domain.Interfaces
{
    public interface IContentRepositories
    {
        void Delete(int id);
        Content Get(int id);
        List<Content> GetAll();
        void Insert(Content request);
        void Update(Content request);
    }
}
