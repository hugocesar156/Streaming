using Streaming.Application.Models.Requests.Cast;
using Streaming.Application.Models.Requests.Film;
using Streaming.Application.Models.Responses.Film;

namespace Streaming.Application.Interfaces
{
    public interface IFilmUseCase
    {
        void AddCasting(FilmCastInsertRequest request);
        void AddCategories(FilmCategoryRequest request);
        void AddContents(FilmContentRequest request);
        void AddInCatalog(FilmCatalogInsertRequest request);
        void AddMedia(FilmMediaInsertRequest request);
        FilmResponse Get(int id);
        void Insert(FilmInsertRequest request);
        void RemoveCategories(FilmCategoryRequest request);
        void RemoveContents(FilmContentRequest request);
        void Update(FilmUpdateRequest request);
        void UpdateCast(CastUpdateRequest request);
    }
}
