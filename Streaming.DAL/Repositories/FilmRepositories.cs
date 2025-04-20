using Microsoft.EntityFrameworkCore;
using Streaming.DAL.Context;
using Streaming.DAL.Models;
using Streaming.Domain.Entities;
using Streaming.Domain.Interfaces;
using Streaming.Shared;
using System.Net;

namespace Streaming.DAL.Repositories
{
    public class FilmRepositories : IFilmRepositories
    {
        private readonly StreamingDataContext _dataContext;

        public FilmRepositories(StreamingDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void AddCasting(List<Cast> request, int idFilm)
        {
            var entities = new List<CAST>();

            foreach (var item in request) 
            {
                entities.Add(new CAST
                {
                    NAME = item.Name,
                    CHARACTER = item.Character,
                    ID_FILM = idFilm
                });
            }

            _dataContext.AddRange(entities);
            _dataContext.SaveChanges();
        }

        public void AddCategories(int[] request, int idFilm)
        {
            var entities = new List<CATALOG_CATEGORY>();

            foreach (var item in request)
            {
                entities.Add(new CATALOG_CATEGORY
                {
                    ID_FILM = idFilm,
                    ID_CATEGORY = item
                });
            }

            _dataContext.AddRange(entities);
            _dataContext.SaveChanges();
        }

        public void AddContents(int[] request, int idFilm)
        {
            var entities = new List<CATALOG_CONTENT>();

            foreach (var item in request)
            {
                entities.Add(new CATALOG_CONTENT
                {
                    ID_FILM = idFilm,
                    ID_CONTENT = item
                });
            }

            _dataContext.AddRange(entities);
            _dataContext.SaveChanges();
        }

        public CatalogRegion? FindFilmCatalog(int idFilm, int idLanguage)
        {
            var entity = _dataContext.CATALOG_REGIONs.Include(x => x.ID_LANGUAGENavigation)
                .FirstOrDefault(x => x.ID_FILM == idFilm && x.ID_LANGUAGE == idLanguage);

            if (entity is not null)
            {
                return new CatalogRegion(
                    entity.ID_CATALOG_REGION,
                    entity.NAME,
                    entity.CLASSIFICATION,
                    entity.SYNOPSIS,
                    new Language(
                        entity.ID_LANGUAGENavigation.ID_LANGUAGE,
                        entity.ID_LANGUAGENavigation.DESCRIPTION,
                        entity.ID_LANGUAGENavigation.CODE),
                    entity.ID_FILM,
                    entity.ID_SERIES_EPISODE);
            }

            return null;
        }

        public Media? FindMedia(int idFilm, int idMedia)
        {
            var entity = _dataContext.MEDIAs.Include(x => x.ID_RESOLUTIONNavigation)
                .FirstOrDefault(x => x.ID_FILM == idFilm && x.ID_MEDIA == idMedia);

            if (entity is not null)
            {
                return new Media(
                    entity.ID_MEDIA, 
                    entity.PATH, 
                    new Resolution(
                        entity.ID_RESOLUTIONNavigation.ID_RESOLUTION,
                        entity.ID_RESOLUTIONNavigation.DESCRIPTION,
                        entity.ID_RESOLUTIONNavigation.PIXELS),
                    entity.ID_FILM,
                    entity.ID_SERIES_EPISODE);
            }

            return null;
        }

        public Film Get(int id)
        {
            var entity = _dataContext.FILMs
                .Include(x => x.CATALOG_CATEGORies).ThenInclude(x => x.ID_CATEGORYNavigation)
                .Include(x => x.CATALOG_CONTENTs).ThenInclude(x => x.ID_CONTENTNavigation)
                .Include(x => x.CASTs)
                .Include(x => x.ID_LANGUAGENavigation)
                .Include(x => x.CATALOG_REGIONs).ThenInclude(x => x.ID_LANGUAGENavigation)
                .FirstOrDefault(x => x.ID_FILM == id);

            if (entity is not null)
            {
                return new Film(
                        entity.ID_FILM, 
                        entity.NAME, 
                        entity.DURATION, 
                        entity.THUMBNAIL, 
                        entity.YEAR, 
                        entity.CREDITS_START,
                        entity.KIDS_CONTENT,

                        new Language(
                            entity.ID_LANGUAGENavigation.ID_LANGUAGE, 
                            entity.ID_LANGUAGENavigation.DESCRIPTION, 
                            entity.ID_LANGUAGENavigation.CODE),

                        entity.CATALOG_CATEGORies.Select(x => new Category(
                            x.ID_CATEGORYNavigation.ID_CATEGORY, 
                            x.ID_CATEGORYNavigation.NAME)).ToList(),

                        entity.CATALOG_CONTENTs.Select(x => new Content(
                            x.ID_CONTENTNavigation.ID_CONTENT, 
                            x.ID_CONTENTNavigation.DESCRIPTION)).ToList(),

                        entity.CASTs.Select(x => new Cast(
                            x.ID_CAST, 
                            x.NAME, 
                            x.CHARACTER,
                            null)).ToList(), 

                        entity.CATALOG_REGIONs.Select(x => new CatalogRegion(
                            x.ID_CATALOG_REGION,
                            x.NAME, 
                            x.CLASSIFICATION, 
                            x.SYNOPSIS,
                            new Language(
                                x.ID_LANGUAGENavigation.ID_LANGUAGE, 
                                x.ID_LANGUAGENavigation.DESCRIPTION, 
                                x.ID_LANGUAGENavigation.CODE), 
                        entity.ID_FILM, null)).ToList());
            }

            throw new StreamingException(HttpStatusCode.UnprocessableEntity, ErrorMessages.RegisterNotFound, string.Format(ErrorMessages.Film.NotFound, id));
        }

        public int Insert(Film request)
        {
            var entity = new FILM
            {
                NAME = request.Name,
                DURATION = request.Duration,
                THUMBNAIL = request.Thumbnail,
                YEAR = request.Year,
                CREDITS_START = request.CreditsStart,
                KIDS_CONTENT = request.KidsContent,
                ID_LANGUAGE = request.Language.IdLanguage
            };

            _dataContext.Add(entity);
            _dataContext.SaveChanges();

            return entity.ID_FILM;
        }

        public void RemoveCategories(int[] request, int idFilm)
        {
            var entities = _dataContext.CATALOG_CATEGORies.Where(x => x.ID_FILM == idFilm && request.Contains(x.ID_CATEGORY)).ToList();

            _dataContext.RemoveRange(entities);
            _dataContext.SaveChanges();
        }

        public void RemoveContents(int[] request, int idFilm)
        {
            var entities = _dataContext.CATALOG_CONTENTs.Where(x => x.ID_FILM == idFilm && request.Contains(x.ID_CONTENT)).ToList();

            _dataContext.RemoveRange(entities);
            _dataContext.SaveChanges();
        }

        public void Update(Film request)
        {
            var entity = _dataContext.FILMs.FirstOrDefault(x => x.ID_FILM == request.IdFilm);

            if (entity is null)
            {
                throw new StreamingException(HttpStatusCode.UnprocessableEntity, ErrorMessages.RegisterNotFound, string.Format(ErrorMessages.Film.NotFound, request.IdFilm));
            }

            entity.NAME = request.Name;
            entity.DURATION = request.Duration;
            entity.THUMBNAIL = request.Thumbnail;
            entity.YEAR = request.Year;
            entity.CREDITS_START = request.CreditsStart;
            entity.KIDS_CONTENT = request.KidsContent;
            entity.ID_LANGUAGE = request.Language.IdLanguage;

            _dataContext.Update(entity);
            _dataContext.SaveChanges();
        }
    }
}
