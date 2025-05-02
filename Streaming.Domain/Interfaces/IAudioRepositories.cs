using Streaming.Domain.Entities;

namespace Streaming.Domain.Interfaces
{
    public interface IAudioRepositories
    {
        Task Delete(int id);
        Task Insert(Audio request);
        Task Update(Audio request);
    }
}
