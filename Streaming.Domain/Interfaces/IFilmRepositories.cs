using Streaming.Domain.Entities;

namespace Streaming.Domain.Interfaces
{
    public interface IFilmRepositories
    {
        void AddCategories(List<CatalogCategory> request);
        void AddContents(List<CatalogContent> request);
        Audio? FindAudio(int idFilm, int idLanguage);
        CatalogRegion? FindFilmCatalog(int idFilm, int idLanguage);
        Media? FindMedia(int idFilm, int idResolutiion);
        Subtitles? FindSubtitles(int idFilm, int idLanguage);
        Film Get(int id);
        int Insert(Film request);
        void RemoveCategories(List<CatalogCategory> request);
        void RemoveContents(List<CatalogContent> request);
        void Update(Film request);
    }
}
