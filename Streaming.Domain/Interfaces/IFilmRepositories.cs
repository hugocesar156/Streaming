using Streaming.Domain.Entities;

namespace Streaming.Domain.Interfaces
{
    public interface IFilmRepositories
    {
        void AddCategories(int[] request, int idFilm);
        void AddContents(int[] request, int idFilm);
        CatalogRegion? FindFilmCatalog(int idFilm, int idLanguage);
        Media? FindMedia(int idFilm, int idMedia);
        Film Get(int id);
        int Insert(Film request);
        void RemoveCategories(int[] request, int idFilm);
        void RemoveContents(int[] request, int idFilm);
        void Update(Film request);
    }
}
