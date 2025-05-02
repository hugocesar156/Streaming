using Microsoft.EntityFrameworkCore;
using Streaming.DAL.Context;
using Streaming.DAL.Models;
using Streaming.Domain.Entities;
using Streaming.Domain.Interfaces;
using Streaming.Shared;
using System.Net;

namespace Streaming.DAL.Repositories
{
    public class CastRepositories : ICastRepositories
    {
        private readonly StreamingDataContext _dataContext;

        public CastRepositories(StreamingDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Delete(int id)
        {
            var entity = await _dataContext.CASTs.FirstOrDefaultAsync(x => x.ID_CAST == id);

            if (entity is null)
            {
                throw new StreamingException(HttpStatusCode.UnprocessableEntity, ErrorMessages.RegisterNotFound, string.Format(ErrorMessages.Cast.NotFound, id));
            }

            _dataContext.Remove(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Insert(Cast request)
        {
            var entities = new CAST
            {
                NAME = request.Name,
                CHARACTER = request.Character,
                ID_FILM = request.IdFilm,
                ID_SERIES = request.IdSeries,
                SEASON = request.Season
            };

            _dataContext.AddRange(entities);
            await _dataContext.SaveChangesAsync();
        }

        public async Task InsertRange(List<Cast> request)
        {
            var entities = new List<CAST>();

            foreach (var item in request)
            {
                entities.Add(new CAST
                {
                    NAME = item.Name,
                    CHARACTER = item.Character,
                    ID_FILM = item.IdFilm,
                    ID_SERIES = item.IdSeries,
                    SEASON = item.Season
                });
            }

            _dataContext.AddRange(entities);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Update(Cast request)
        {
            var entity = await _dataContext.CASTs.FirstOrDefaultAsync(x => x.ID_CAST == request.IdCast);

            if (entity is null)
            {
                throw new StreamingException(HttpStatusCode.UnprocessableEntity, ErrorMessages.RegisterNotFound, string.Format(ErrorMessages.Cast.NotFound, request.IdCast));
            }

            entity.NAME = request.Name;
            entity.CHARACTER = request.Character;
            entity.SEASON = request.Season;

            _dataContext.Update(entity);
            await _dataContext.SaveChangesAsync();
        }
    }
}
