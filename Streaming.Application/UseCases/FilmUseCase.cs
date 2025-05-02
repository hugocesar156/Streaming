using Streaming.Application.Interfaces;
using Streaming.Application.Models.Requests.Film;
using Streaming.Application.Models.Responses.Audio;
using Streaming.Application.Models.Responses.Cast;
using Streaming.Application.Models.Responses.CatalogRegion;
using Streaming.Application.Models.Responses.Category;
using Streaming.Application.Models.Responses.Contents;
using Streaming.Application.Models.Responses.Film;
using Streaming.Application.Models.Responses.Language;
using Streaming.Application.Models.Responses.Media;
using Streaming.Application.Models.Responses.Subtitles;
using Streaming.Application.Services;
using Streaming.Domain.Entities;
using Streaming.Domain.Interfaces;
using Streaming.Shared;
using System.Net;

namespace Streaming.Application.UseCases
{
    public class FilmUseCase : IFilmUseCase
    {
        private readonly IAudioRepositories _audioRepositories;
        private readonly ICastRepositories _castRepositories;
        private readonly ICatalogRegionRepositories _catalogRegionRepositories;
        private readonly ICategoryRepositories _categoryRepositories;
        private readonly IContentRepositories _contentRepositories;
        private readonly IFilmRepositories _filmRepositories;
        private readonly ILanguageRepositories _languageRepositories;
        private readonly IMediaRepositories _mediaRepositories;
        private readonly ISubtitlesRepositories _subtitlesRepositories;

        public FilmUseCase(IAudioRepositories audioRepositories, ICastRepositories castRepositories, 
            ICatalogRegionRepositories catalogRegionRepositories, ICategoryRepositories categoryRepositories, 
            IContentRepositories contentRepositories, IFilmRepositories filmRepositories,
            ILanguageRepositories languageRepositories, IMediaRepositories mediaRepositories, ISubtitlesRepositories subtitlesRepositories)
        {
            _audioRepositories = audioRepositories;
            _castRepositories = castRepositories;
            _catalogRegionRepositories = catalogRegionRepositories;
            _categoryRepositories = categoryRepositories;
            _contentRepositories = contentRepositories;
            _filmRepositories = filmRepositories;
            _languageRepositories = languageRepositories;
            _mediaRepositories = mediaRepositories;
            _subtitlesRepositories = subtitlesRepositories;
        }

        public async Task AddAudio(FilmAudioInsertRequest request)
        {
            try
            {
                await _filmRepositories.Get(request.IdFilm);

                if (await _filmRepositories.FindAudio(request.IdFilm, request.Audio.IdLanguage) is not null)
                {
                    throw new StreamingException(HttpStatusCode.MethodNotAllowed, ErrorMessages.ActionNotAllowed, ErrorMessages.Film.Audio);
                }

                var audio = new Audio(request.Audio.Path, new Language(request.Audio.IdLanguage), request.IdFilm, null);
                await _audioRepositories.Insert(audio);
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

        public async Task AddCast(FilmCastInsertRequest request)
        {
            try
            {
                await _filmRepositories.Get(request.IdFilm);

                var cast = new Cast(request.Cast.Name, request.Cast.Character, request.IdFilm, null, null);
                await _castRepositories.Insert(cast);
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

        public async Task AddCategories(FilmCategoryRequest request)
        {
            try
            {
                await _filmRepositories.Get(request.IdFilm);

                var categories = await _categoryRepositories.GetAll();

                foreach (var item in request.Categories)
                {
                    if (!categories.Select(x => x.IdCategory).Contains(item))
                    {
                        throw new StreamingException(HttpStatusCode.UnprocessableEntity, ErrorMessages.RegisterNotFound, string.Format(ErrorMessages.Category.NotFound, item));
                    }
                }

                await _filmRepositories.AddCategories(request.Categories.Distinct().Select(x => new CatalogCategory(x, request.IdFilm, null)).ToList());
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

        public async Task AddContents(FilmContentRequest request)
        {
            try
            {
                await _filmRepositories.Get(request.IdFilm);

                var contents = await _contentRepositories.GetAll();

                foreach (var item in request.Contents)
                {
                    if (!contents.Select(x => x.IdContent).Contains(item))
                    {
                        throw new StreamingException(HttpStatusCode.UnprocessableEntity, ErrorMessages.RegisterNotFound, string.Format(ErrorMessages.Content.NotFound, item));
                    }
                }

                await _filmRepositories.AddContents(request.Contents.Distinct().Select(x => new CatalogContent(x, request.IdFilm, null)).ToList());
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

        public async Task AddInCatalog(FilmCatalogInsertRequest request)
        {
            try
            {
                await _filmRepositories.Get(request.IdFilm);

                if (await _filmRepositories.FindFilmCatalog(request.IdFilm, request.FilmRegion.IdLanguage) is not null)
                {
                    throw new StreamingException(HttpStatusCode.MethodNotAllowed, ErrorMessages.ActionNotAllowed, ErrorMessages.Film.RegionCatalog);
                }

                var filmCatalog = new CatalogRegion(request.FilmRegion.Name, request.FilmRegion.Classification, request.FilmRegion.Synospsis,
                    new Language(request.FilmRegion.IdLanguage), request.IdFilm, null);

                await _catalogRegionRepositories.Insert(filmCatalog);
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

        public async Task AddMedia(FilmMediaInsertRequest request)
        {
            try
            {
                await _filmRepositories.Get(request.IdFilm);

                if (await _filmRepositories.FindMedia(request.IdFilm, request.Media.IdResolution) is not null)
                {
                    throw new StreamingException(HttpStatusCode.MethodNotAllowed, ErrorMessages.ActionNotAllowed, ErrorMessages.Film.Media);
                }

                var media = new Media(request.Media.Path, new Resolution(request.Media.IdResolution), request.IdFilm, null);
                await _mediaRepositories.Insert(media);
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

        public async Task AddSubtitles(FilmSubtitlesInsertRequest request)
        {
            try
            {
                await _filmRepositories.Get(request.IdFilm);

                if (await _filmRepositories.FindSubtitles(request.IdFilm, request.Subtitles.IdLanguage) is not null)
                {
                    throw new StreamingException(HttpStatusCode.MethodNotAllowed, ErrorMessages.ActionNotAllowed, ErrorMessages.Film.Subtitles);
                }

                var subtitles = new Subtitles(request.Subtitles.Path, new Language(request.Subtitles.IdLanguage), request.IdFilm, null);
                await _subtitlesRepositories.Insert(subtitles);
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

        public async Task<FilmResponse> Get(int id)
        {
            try
            {
                var film = await _filmRepositories.Get(id);

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
                        film.Language.Code,
                        film.Language.CountryCode),

                    film.Categories.Select(x => new CategoryResponse(
                        x.IdCategory, 
                        x.Name)).ToList(),

                    film.Contents.Select(x => new ContentResponse(
                        x.IdContent,
                        x.Description)).ToList(),

                    film.Casting.Select(x => new CastResponse(
                        x.IdCast, 
                        x.Name, 
                        x.Character)).ToList(),
                        
                     film.Regions.Select(x => new CatalogRegionResponse(
                         x.IdCatalogRegion,
                         x.Name,
                         x.Classification,
                         x.Synopsis,
                         new LanguageResponse(
                             x.Language.IdLanguage,
                             x.Language.Description,
                             x.Language.Code,
                             x.Language.CountryCode))).ToList(),
                     
                     film.Medias.Select(x => new MediaResponse(
                         x.IdMedia,
                         x.Path,
                         new Models.Responses.Resolution.ResolutionResponse(
                             x.Resolution.IdResolution,
                             x.Resolution.Description,
                             x.Resolution.Pixels))).ToList(),
                     
                     film.Audios.Select(x => new AudioResponse(
                         x.IdAudio,
                         x.Path,
                         new LanguageResponse(
                             x.Language.IdLanguage,
                             x.Language.Description,
                             x.Language.Code,
                             x.Language.CountryCode))).ToList(),

                      film.Subtitles.Select(x => new SubtitlesResponse(
                         x.IdSubtitles,
                         x.Path,
                         new LanguageResponse(
                             x.Language.IdLanguage,
                             x.Language.Description,
                             x.Language.Code, 
                             x.Language.CountryCode))).ToList());
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

        public async Task<FilmCatalogResponse> GetInCatalog(int id, string ipAddress)
        {
            try
            {
                var film = await _filmRepositories.Get(id);

                var addressByIP = await IPServices.GetAddressByIPAsync(ipAddress);
                var language = await _languageRepositories.GetByCountryCode(addressByIP.CountryCode);

                if (film.Regions.Any(x => x.Language.IdLanguage == language.IdLanguage))
                {
                    return new FilmCatalogResponse(
                        film.IdFilm,
                        film.Regions.First(x => x.Language.IdLanguage == language.IdLanguage).Name,
                        film.Regions.First(x => x.Language.IdLanguage == language.IdLanguage).Classification ?? string.Empty,
                        film.Regions.First(x => x.Language.IdLanguage == language.IdLanguage).Synopsis,
                        film.Duration,
                        film.Thumbnail,
                        film.Year,
                        film.CreditsStart,
                        film.KidsContent,

                        film.Categories.Select(x => new CategoryResponse(
                            x.IdCategory,
                            x.Name)).ToList(),

                        film.Contents.Select(x => new ContentResponse(
                            x.IdContent,
                            x.Description)).ToList(),

                        film.Casting.Select(x => new CastResponse(
                            x.IdCast,
                            x.Name,
                            x.Character)).ToList(),

                        film.Medias.Select(x => new MediaResponse(
                            x.IdMedia,
                            x.Path,
                            new Models.Responses.Resolution.ResolutionResponse(
                                x.Resolution.IdResolution,
                                x.Resolution.Description,
                                x.Resolution.Pixels))).ToList(),

                        film.Audios.Select(x => new AudioResponse(
                            x.IdAudio,
                            x.Path,
                            new LanguageResponse(
                                x.Language.IdLanguage,
                                x.Language.Description,
                                x.Language.Code,
                                x.Language.CountryCode))).ToList(),
                        
                        film.Subtitles.Select(x => new SubtitlesResponse(
                            x.IdSubtitles,
                            x.Path,
                            new LanguageResponse(
                                x.Language.IdLanguage,
                                x.Language.Description,
                                x.Language.Code,
                                x.Language.CountryCode))).ToList());
                }

                throw new StreamingException(HttpStatusCode.UnprocessableEntity, ErrorMessages.RegisterNotFound, string.Format(ErrorMessages.Film.NotFoundInCatalog, id));
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

        public async Task Insert(FilmInsertRequest request)
        {
            try
            {
                if (request.Categories.Any())
                {
                    var categories = await _categoryRepositories.GetAll();

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
                    var contents = await _contentRepositories.GetAll();

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

                int idFilm = await _filmRepositories.Insert(film);

                await _filmRepositories.AddCategories(request.Categories.Distinct().Select(x => new CatalogCategory(x, idFilm, null)).ToList());
                await _filmRepositories.AddContents(request.Contents.Distinct().Select(x => new CatalogContent(x, idFilm, null)).ToList());

                await _castRepositories.InsertRange(request.Casting.Select(x => new Cast(x.Name, x.Character, idFilm, null, null)).ToList());
            }
            catch (Exception ex) 
            {
                throw new StreamingException(HttpStatusCode.InternalServerError, ex.Message, ex.InnerException?.Message);
            }
        }

        public async Task RemoveCategories(FilmCategoryRequest request)
        {
            try
            {
                await _filmRepositories.Get(request.IdFilm);

                var categories = await _contentRepositories.GetAll();

                foreach (var item in request.Categories)
                {
                    if (!categories.Select(x => x.IdContent).Contains(item))
                    {
                        throw new StreamingException(HttpStatusCode.UnprocessableEntity, ErrorMessages.RegisterNotFound, string.Format(ErrorMessages.Category.NotFound, item));
                    }
                }

                await _filmRepositories.RemoveCategories(request.Categories.Distinct().Select(x => new CatalogCategory(x, request.IdFilm, null)).ToList());
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

        public async Task RemoveContents(FilmContentRequest request)
        {
            await _filmRepositories.Get(request.IdFilm);

            var contents = await _contentRepositories.GetAll();

            foreach (var item in request.Contents)
            {
                if (!contents.Select(x => x.IdContent).Contains(item))
                {
                    throw new StreamingException(HttpStatusCode.UnprocessableEntity, ErrorMessages.RegisterNotFound, string.Format(ErrorMessages.Content.NotFound, item));
                }
            }

            await _filmRepositories.RemoveContents(request.Contents.Distinct().Select(x => new CatalogContent(x, request.IdFilm, null)).ToList());
        }

        public async Task Update(FilmUpdateRequest request)
        {
            try
            {
                var film = new Film(request.IdFilm, request.Name, request.Duration, request.Thumbnail, request.Year, 
                    request.CreditsStart, request.KidsContent, new Language(request.IdLanguage));

                await _filmRepositories.Update(film);
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

        public async Task UpdateCast(FilmCastUpdateRequest request)
        {
            try
            {
                var cast = new Cast(request.IdCast, request.Cast.Name, request.Cast.Character, null, null, null);
                await _castRepositories.Update(cast);
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
