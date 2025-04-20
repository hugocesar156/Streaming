using Streaming.Domain.Entities;

namespace Streaming.Domain.Interfaces
{
    public interface IMediaRepositories
    {
        void Insert(Media request);
    }
}
