using Streaming.Domain.Entities;

namespace Streaming.Domain.Interfaces
{
    public interface IFilmRepositories
    {
        void AddCategories(int[] request, int idFilm);
        void AddContents(int[] request, int idFilm);
        Audio? FindAudio(int idFilm, int idLanguage);
        CatalogRegion? FindFilmCatalog(int idFilm, int idLanguage);
        Media? FindMedia(int idFilm, int idResolutiion);
        Subtitles? FindSubtitles(int idFilm, int idLanguage);
        Film Get(int id);
        int Insert(Film request);
        void RemoveCategories(int[] request, int idFilm);
        void RemoveContents(int[] request, int idFilm);
        void Update(Film request);
    }
}
