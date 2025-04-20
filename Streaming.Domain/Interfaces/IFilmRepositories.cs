using Streaming.Domain.Entities;

namespace Streaming.Domain.Interfaces
{
    public interface IFilmRepositories
    {
        void AddCasting(List<Cast> request, int idFilm);
        void AddCategories(int[] request, int idFilm);
        void AddContents(int[] request, int idFilm);
        Film Get(int id);
        int Insert(Film request);
        void RemoveCategories(int[] request, int idFilm);
        void RemoveContents(int[] request, int idFilm);
        void Update(Film request);
    }
}
