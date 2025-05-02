using Streaming.Domain.Entities;

namespace Streaming.Domain.Interfaces
{
    public interface ICastRepositories
    {
        Task Delete(int id);
        Task Insert(Cast request);
        Task InsertRange(List<Cast> request);
        Task Update(Cast request);
    }
}
