using Streaming.Domain.Entities;

namespace Streaming.Domain.Interfaces
{
    public interface IFilmRepositories
    {
        void Delete(int id);
        Film Get(int id);
        List<Film> GetAll();
        void Insert(Film request);
        void Update(Film request);
    }
}
