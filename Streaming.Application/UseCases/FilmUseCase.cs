using Streaming.Application.Interfaces;
using Streaming.Application.Models.Requests.Cast;
using Streaming.Application.Models.Requests.Film;
using Streaming.Application.Models.Responses.Category;
using Streaming.Application.Models.Responses.Contents;
using Streaming.Application.Models.Responses.Film;
using Streaming.Application.Models.Responses.Language;
using Streaming.Domain.Entities;
using Streaming.Domain.Interfaces;
using Streaming.Shared;
using System.Net;

namespace Streaming.Application.UseCases
{
    public class FilmUseCase : IFilmUseCase
    {
        private readonly ICastRepositories _castRepositories;
        private readonly ICatalogRegionRepositories _catalogRegionRepositories;
        private readonly ICategoryRepositories _categoryRepositories;
        private readonly IContentRepositories _contentRepositories;
        private readonly IFilmRepositories _filmRepositories;

        public FilmUseCase(ICastRepositories castRepositories, ICatalogRegionRepositories catalogRegionRepositories,
            ICategoryRepositories categoryRepositories, IContentRepositories contentRepositories, IFilmRepositories filmRepositories)
        {
            _castRepositories = castRepositories;
            _catalogRegionRepositories = catalogRegionRepositories;
            _categoryRepositories = categoryRepositories;
            _contentRepositories = contentRepositories;
            _filmRepositories = filmRepositories;
        }

        public void AddCasting(FilmCastInsertRequest request)
        {
            try
            {
                _filmRepositories.Get(request.IdFilm);

                var casting = request.Casting.Select(x => new Cast(x.Name, x.Character, null)).ToList();
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

        public void AddInCatalog(FilmCatalogInsertRequest request)
        {
            try
            {
                _filmRepositories.Get(request.IdFilm);

                if (_filmRepositories.FindFilmCatalog(request.IdFilm, request.FilmRegion.IdLanguage) is not null)
                {
                    throw new StreamingException(HttpStatusCode.MethodNotAllowed, ErrorMessages.ActionNotAllowed, ErrorMessages.Film.RegionCatalog);
                }

                var filmCatalog = new CatalogRegion(request.FilmRegion.Name, request.FilmRegion.Classification, request.FilmRegion.Synospsis,
                    new Language(request.FilmRegion.IdLanguage), request.IdFilm, null);

                _catalogRegionRepositories.Insert(filmCatalog);
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

                return new FilmResponse(
                    film.IdFilm,
                    film.Name,
                    film.Duration, 
                    film.Thumbnail, 
                    film.Year,
                    film.CreditsStart, 
                    film.KidsContent,

                    new LanguageResponse(
                        film.Language.IdLanguage, 
                        film.Language.Description, 
                        film.Language.Code),

                    film.Categories.Select(x => new CategoryResponse(
                        x.IdCategory, 
                        x.Name)).ToList(),

                    film.Contents.Select(x => new ContentResponse(
                        x.IdContent,
                        x.Description)).ToList(),

                    film.Casting.Select(x => new FilmCastResponse(
                        x.IdCast, 
                        x.Name, 
                        x.Character)).ToList(),
                        
                     film.Regions.Select(x => new FilmRegionResponse(
                         x.Name,
                         x.Classification,
                         x.Synopsis,
                         new LanguageResponse(
                             x.Language.IdLanguage,
                             x.Language.Description,
                             x.Language.Code))).ToList());
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

                var film = new Film(request.Name, request.Duration, request.Thumbnail, request.Year,
                    request.CreditsStart, request.KidsContent, new Language(request.IdLanguage));

                int idFilm = _filmRepositories.Insert(film);

                _filmRepositories.AddCategories(request.Categories.Distinct().ToArray(), idFilm);
                _filmRepositories.AddContents(request.Contents.Distinct().ToArray(), idFilm);

                _filmRepositories.AddCasting(request.Casting.Select(x => new Cast(x.Name, x.Character, null)).ToList(), idFilm);
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
                var film = new Film(request.IdFilm, request.Name, request.Duration, request.Thumbnail, request.Year, 
                    request.CreditsStart, request.KidsContent, new Language(request.IdLanguage));

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

        public void UpdateCast(CastUpdateRequest request)
        {
            try
            {
                var cast = new Cast(request.IdCast, request.Name, request.Character, null);
                _castRepositories.Update(cast);
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
