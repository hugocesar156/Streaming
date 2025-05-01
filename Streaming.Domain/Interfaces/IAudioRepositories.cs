using Streaming.Domain.Entities;

namespace Streaming.Domain.Interfaces
{
    public interface IAudioRepositories
    {
        void Delete(int id);
        void Insert(Audio request);
        void Update(Audio request);
    }
}
