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
        private readonly ICategoryRepositories _categoryRepositories;
        private readonly IContentRepositories _contentRepositories;
        private readonly IFilmRepositories _filmRepositories;

        public FilmUseCase(ICategoryRepositories categoryRepositories, IContentRepositories contentRepositories, IFilmRepositories filmRepositories)
        {
            _categoryRepositories = categoryRepositories;
            _contentRepositories = contentRepositories;
            _filmRepositories = filmRepositories;
        }

        public void AddCasting(FilmCastInsertRequest request)
        {
            try
            {
                Path.Combine();
                _filmRepositories.Get(request.IdFilm);

                var casting = request.Casting.Select(x => new Cast(x.Name, x.Character)).ToList();
                _filmRepositories.AddCasting(casting, request.IdFilm);
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

        public void AddCategories(FilmCategoryRequest request)
        {
            try
            {
                _filmRepositories.Get(request.IdFilm);

                var categories = _categoryRepositories.GetAll();

                foreach (var item in request.Categories)
                {
                    if (!categories.Select(x => x.IdCategory).Contains(item))
                    {
                        throw new StreamingException(HttpStatusCode.UnprocessableEntity, ErrorMessages.RegisterNotFound, string.Format(ErrorMessages.Category.NotFound, item));
                    }
                }

                _filmRepositories.AddCategories(request.Categories.Distinct().ToArray(), request.IdFilm);
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

        public void AddContents(FilmContentRequest request)
        {
            try
            {
                _filmRepositories.Get(request.IdFilm);

                var contents = _contentRepositories.GetAll();

                foreach (var item in request.Contents)
                {
                    if (!contents.Select(x => x.IdContent).Contains(item))
                    {
                        throw new StreamingException(HttpStatusCode.UnprocessableEntity, ErrorMessages.RegisterNotFound, string.Format(ErrorMessages.Content.NotFound, item));
                    }
                }

                _filmRepositories.AddContents(request.Contents.Distinct().ToArray(), request.IdFilm);
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

        public FilmResponse Get(int id)
        {
            try
            {
                var film = _filmRepositories.Get(id);

                return new FilmResponse(film.IdFilm, film.Name, film.Duration, film.Classification, 
                    film.Synopsis, film.Thumbnail, film.Media, film.Preview, film.Year,
                    film.Categories.Select(x => new CategoryResponse(x.IdCategory, x.Name)).ToList(),
                    film.Contents.Select(x => new ContentResponse(x.IdContent, x.Description)).ToList(),
                    film.Casting.Select(x => new FilmCastResponse(x.IdCast, x.Name, x.Character)).ToList());
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
                if (request.Categories.Any())
                {
                    var categories = _categoryRepositories.GetAll();

                    foreach (var item in request.Categories)
                    {
                        if (!categories.Select(x => x.IdCategory).Contains(item))
                        {
                            throw new StreamingException(HttpStatusCode.UnprocessableEntity, ErrorMessages.RegisterNotFound, string.Format(ErrorMessages.Category.NotFound, item));
                        }
                    }
                }

                if (request.Contents.Any())
                {
                    var contents = _contentRepositories.GetAll();

                    foreach (var item in request.Contents)
                    {
                        if (!contents.Select(x => x.IdContent).Contains(item))
                        {
                            throw new StreamingException(HttpStatusCode.UnprocessableEntity, ErrorMessages.RegisterNotFound, string.Format(ErrorMessages.Content.NotFound, item));
                        }
                    }
                }

                var film = new Film(request.Name, request.Duration, request.Classification, request.Synopsis, 
                    request.Thumbnail, request.Media, request.Preview, request.Year);

                int idFilm = _filmRepositories.Insert(film);

                _filmRepositories.AddCategories(request.Categories.Distinct().ToArray(), idFilm);
                _filmRepositories.AddContents(request.Contents.Distinct().ToArray(), idFilm);

                _filmRepositories.AddCasting(request.Casting.Select(x => new Cast(x.Name, x.Character)).ToList(), idFilm);
            }
            catch (Exception ex) 
            {
                throw new StreamingException(HttpStatusCode.InternalServerError, ex.Message, ex.InnerException?.Message);
            }
        }

        public void RemoveCategories(FilmCategoryRequest request)
        {
            try
            {
                _filmRepositories.Get(request.IdFilm);

                var categories = _contentRepositories.GetAll();

                foreach (var item in request.Categories)
                {
                    if (!categories.Select(x => x.IdContent).Contains(item))
                    {
                        throw new StreamingException(HttpStatusCode.UnprocessableEntity, ErrorMessages.RegisterNotFound, string.Format(ErrorMessages.Category.NotFound, item));
                    }
                }

                _filmRepositories.RemoveCategories(request.Categories.Distinct().ToArray(), request.IdFilm);
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

        public void RemoveContents(FilmContentRequest request)
        {
            _filmRepositories.Get(request.IdFilm);

            var contents = _contentRepositories.GetAll();

            foreach (var item in request.Contents)
            {
                if (!contents.Select(x => x.IdContent).Contains(item))
                {
                    throw new StreamingException(HttpStatusCode.UnprocessableEntity, ErrorMessages.RegisterNotFound, string.Format(ErrorMessages.Content.NotFound, item));
                }
            }

            _filmRepositories.RemoveContents(request.Contents.Distinct().ToArray(), request.IdFilm);
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
