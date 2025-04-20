using Streaming.Domain.Entities;

namespace Streaming.Domain.Interfaces
{
    public interface ICastRepositories
    {
        void Delete(int id);
        void Update(Cast request);
    }
}
