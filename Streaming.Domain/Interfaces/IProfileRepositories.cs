using Streaming.Domain.Entities;

namespace Streaming.Domain.Interfaces
{
    public interface IProfileRepositories
    {
        void Delete(int id);
        Profile Get(int id);
        void Insert(Profile request);
        void Update(Profile request);
    }
}
