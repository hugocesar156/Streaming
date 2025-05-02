using Streaming.Domain.Entities;

namespace Streaming.Domain.Interfaces
{
    public interface IProfileRepositories
    {
        Task Delete(int id);
        Task<Profile> Get(int id);
        Task Insert(Profile request);
        Task Update(Profile request);
    }
}
