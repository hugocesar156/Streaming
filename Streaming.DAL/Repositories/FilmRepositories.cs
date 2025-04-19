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

        public void AddCategories(int[] request, int idFilm)
        {
            var entities = new List<FILM_CATEGORY>();

            foreach (var item in request)
            {
                entities.Add(new FILM_CATEGORY
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
            var entities = new List<FILM_CONTENT>();

            foreach (var item in request)
            {
                entities.Add(new FILM_CONTENT
                {
                    ID_FILM = idFilm,
                    ID_CONTENT = item
                });
            }

            _dataContext.AddRange(entities);
            _dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Film Get(int id)
        {
            var entity = _dataContext.FILMs
                .Include(x => x.FILM_CATEGORies).ThenInclude(x => x.ID_CATEGORYNavigation)
                .Include(x => x.FILM_CONTENTs).ThenInclude(x => x.ID_CONTENTNavigation)
                .FirstOrDefault(x => x.ID_FILM == id);

            if (entity is not null)
            {
                return new Film(entity.ID_FILM, entity.NAME, entity.DURATION, entity.CLASSIFICATION, entity.SYNOPSIS,
                    entity.THUMBNAIL, entity.MEDIA, entity.PREVIEW, entity.YEAR,
                    entity.FILM_CATEGORies.Select(x => new Category(x.ID_CATEGORYNavigation.ID_CATEGORY, x.ID_CATEGORYNavigation.NAME)).ToList(),
                    entity.FILM_CONTENTs.Select(x => new Content(x.ID_CONTENTNavigation.ID_CONTENT, x.ID_CONTENTNavigation.DESCRIPTION)).ToList());
            }

            throw new StreamingException(HttpStatusCode.UnprocessableEntity, ErrorMessages.RegisterNotFound, string.Format(ErrorMessages.Film.NotFound, id));
        }

        public List<Film> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Insert(Film request)
        {
            var entity = new FILM
            {
                NAME = request.Name,
                DURATION = request.Duration,
                CLASSIFICATION = request.Classification,
                SYNOPSIS = request.Synopsis,
                THUMBNAIL = request.Thumbnail,
                MEDIA = request.Media,
                PREVIEW = request.Preview,
                YEAR = request.Year
            };

            _dataContext.Add(entity);
            _dataContext.SaveChanges();

            return entity.ID_FILM;
        }

        public void RemoveCategories(int[] request, int idFilm)
        {
            var entities = _dataContext.FILM_CATEGORies.Where(x => x.ID_FILM == idFilm && request.Contains(x.ID_CATEGORY)).ToList();

            _dataContext.RemoveRange(entities);
            _dataContext.SaveChanges();
        }

        public void RemoveContents(int[] request, int idFilm)
        {
            var entities = _dataContext.FILM_CONTENTs.Where(x => x.ID_FILM == idFilm && request.Contains(x.ID_CONTENT)).ToList();

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
            entity.CLASSIFICATION = request.Classification;
            entity.SYNOPSIS = request.Synopsis;
            entity.THUMBNAIL = request.Thumbnail;
            entity.MEDIA = request.Media;
            entity.PREVIEW = request.Preview;
            entity.YEAR = request.Year;

            _dataContext.Update(entity);
            _dataContext.SaveChanges();
        }
    }
}
