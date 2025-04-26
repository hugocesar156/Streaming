using Streaming.Domain.Entities;

namespace Streaming.Domain.Interfaces
{
    public interface IProfileRepositories
    {
        void Insert(Profile request);
    }
}
