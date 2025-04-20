using Streaming.Application.Models.Requests;
using Streaming.Application.Models.Responses;

namespace Streaming.Application.Interfaces
{
    public interface IFilmUseCase
    {
        void AddCasting(FilmCastInsertRequest request);
        void AddCategories(FilmCategoryRequest request);
        void AddContents(FilmContentRequest request);
        //void Delete(int id);
        FilmResponse Get(int id);
        //List<FilmResponse> GetAll();
        void Insert(FilmInsertRequest request);
        void RemoveCategories(FilmCategoryRequest request);
        void RemoveContents(FilmContentRequest request);
        void Update(FilmUpdateRequest request);
    }
}
