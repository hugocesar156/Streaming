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

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Film Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Film> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(Film request)
        {
            var filmEntity = new FILM
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

            var transaction = _dataContext.Database.BeginTransaction();
            transaction.CreateSavepoint("InsertFilm");

            _dataContext.Add(filmEntity);
            _dataContext.SaveChanges();

            if (request.Categories.Any())
            {
                var categoryEntities = new List<FILM_CATEGORY>();

                foreach (var item in request.Categories)
                {
                    categoryEntities.Add(new FILM_CATEGORY
                    {
                        ID_FILM = filmEntity.ID_FILM,
                        ID_CATEGORY = item.IdCategory
                    });
                }

                try
                {
                    _dataContext.AddRange(categoryEntities);
                    _dataContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    transaction.RollbackToSavepoint("InsertFilm");
                    throw new StreamingException(HttpStatusCode.UnprocessableEntity, ErrorMessages.RegisterNotFound, ErrorMessages.Category.NotFound);
                }
            }

            if (request.Contents.Any())
            {
                var contentEntities = new List<FILM_CONTENT>();

                foreach (var item in request.Contents)
                {
                    contentEntities.Add(new FILM_CONTENT
                    {
                        ID_FILM = filmEntity.ID_FILM,
                        ID_CONTENT = item.IdContent
                    });
                }

                try
                {
                    _dataContext.AddRange(contentEntities);
                    _dataContext.SaveChanges();
                }
                catch (Exception)
                {
                    transaction.RollbackToSavepoint("InsertFilm");
                    throw new StreamingException(HttpStatusCode.UnprocessableEntity, ErrorMessages.RegisterNotFound, ErrorMessages.Content.NotFound);
                }
            }

            transaction.Commit();
        }

        public void Update(Film request)
        {
            throw new NotImplementedException();
        }
    }
}
