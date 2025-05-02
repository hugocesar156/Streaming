using Streaming.Domain.Entities;

namespace Streaming.Domain.Interfaces
{
    public interface IFilmRepositories
    {
        Task AddCategories(List<CatalogCategory> request);
        Task AddContents(List<CatalogContent> request);
        Task<Audio?> FindAudio(int idFilm, int idLanguage);
        Task<CatalogRegion?> FindFilmCatalog(int idFilm, int idLanguage);
        Task<Media?> FindMedia(int idFilm, int idResolutiion);
        Task<Subtitles?> FindSubtitles(int idFilm, int idLanguage);
        Task<Film> Get(int id);
        Task<int> Insert(Film request);
        Task RemoveCategories(List<CatalogCategory> request);
        Task RemoveContents(List<CatalogContent> request);
        Task Update(Film request);
    }
}
