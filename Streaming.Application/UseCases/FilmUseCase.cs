using Streaming.Application.Interfaces;
using Streaming.Application.Models.Requests;
using Streaming.Application.Models.Responses;
using Streaming.Domain.Entities;
using Streaming.Domain.Interfaces;
using Streaming.Shared;
using System.Net;

namespace Streaming.Application.UseCases
{
    public class FilmUseCase : IFilmUseCase
    {
        private readonly IFilmRepositories _filmRepositories;

        public FilmUseCase(IFilmRepositories filmRepositories)
        {
            _filmRepositories = filmRepositories;
        }

        public FilmResponse Get(int id)
        {
            try
            {
                var film = _filmRepositories.Get(id);

                return new FilmResponse(film.IdFilm, film.Name, film.Duration, film.Classification, 
                    film.Synopsis, film.Thumbnail, film.Media, film.Preview, film.Year,
                    film.Categories.Select(x => new CategoryResponse(x.IdCategory, x.Name)).ToList(),
                    film.Contents.Select(x => new ContentResponse(x.IdContent, x.Description)).ToList());
            }
            catch (StreamingException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new StreamingException(HttpStatusCode.InternalServerError, ex.Message, ex.InnerException?.Message);
            }
        }

        public void Insert(FilmInsertRequest request)
        {
            try
            {
                var film = new Film(request.Name, request.Duration, request.Classification, request.Synopsis, 
                    request.Thumbnail, request.Media, request.Preview, request.Year, request.Categories, request.Contents);

                _filmRepositories.Insert(film);
            }
            catch (StreamingException)
            {
                throw;
            }
            catch (Exception ex) 
            {
                throw new StreamingException(HttpStatusCode.InternalServerError, ex.Message, ex.InnerException?.Message);
            }
        }

        public void Update(FilmUpdateRequest request)
        {
            try
            {
                var film = new Film(request.IdFilm, request.Name, request.Duration, request.Classification, request.Synopsis,
                    request.Thumbnail, request.Media, request.Preview, request.Year);

                _filmRepositories.Update(film);
            }
            catch (StreamingException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new StreamingException(HttpStatusCode.InternalServerError, ex.Message, ex.InnerException?.Message);
            }
        }
    }
}
