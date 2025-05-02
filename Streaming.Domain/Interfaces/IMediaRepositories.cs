using Streaming.Domain.Entities;

namespace Streaming.Domain.Interfaces
{
    public interface IMediaRepositories
    {
        Task Insert(Media request);
    }
}
