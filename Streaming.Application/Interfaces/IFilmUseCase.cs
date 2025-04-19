using Streaming.Application.Models.Requests;
using Streaming.Application.Models.Responses;

namespace Streaming.Application.Interfaces
{
    public interface IFilmUseCase
    {
        //void Delete(int id);
        //FilmResponse Get(int id);
        //List<FilmResponse> GetAll();
        void Insert(FilmInsertRequest request);
        void Update(FilmUpdateRequest request);
    }
}
