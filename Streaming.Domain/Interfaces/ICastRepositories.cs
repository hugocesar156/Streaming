using Streaming.Domain.Entities;

namespace Streaming.Domain.Interfaces
{
    public interface ICastRepositories
    {
        void Delete(int id);
        void Insert(Cast request);
        void InsertRange(List<Cast> request);
        void Update(Cast request);
    }
}
