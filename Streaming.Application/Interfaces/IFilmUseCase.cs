using Streaming.Application.Models.Requests.Film;
using Streaming.Application.Models.Responses.Film;

namespace Streaming.Application.Interfaces
{
    public interface IFilmUseCase
    {
        Task AddAudio(FilmAudioInsertRequest request);
        Task AddCast(FilmCastInsertRequest request);
        Task AddCategories(FilmCategoryRequest request);
        Task AddContents(FilmContentRequest request);
        Task AddInCatalog(FilmCatalogInsertRequest request);
        Task AddMedia(FilmMediaInsertRequest request);
        Task AddSubtitles(FilmSubtitlesInsertRequest request);
        Task<FilmResponse> Get(int id);
        Task<FilmCatalogResponse> GetInCatalog(int id, string ipAddress);
        Task Insert(FilmInsertRequest request);
        Task RemoveCategories(FilmCategoryRequest request);
        Task RemoveContents(FilmContentRequest request);
        Task Update(FilmUpdateRequest request);
        Task UpdateCast(FilmCastUpdateRequest request);
    }
}
