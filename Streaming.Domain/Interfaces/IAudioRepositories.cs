using Streaming.Domain.Entities;

namespace Streaming.Domain.Interfaces
{
    public interface IAudioRepositories
    {
        void Insert(Audio request);
    }
}
