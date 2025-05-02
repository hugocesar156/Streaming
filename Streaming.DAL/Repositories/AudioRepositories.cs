using Microsoft.EntityFrameworkCore;
using Streaming.DAL.Context;
using Streaming.DAL.Models;
using Streaming.Domain.Entities;
using Streaming.Domain.Interfaces;
using Streaming.Shared;
using System.Net;

namespace Streaming.DAL.Repositories
{
    public class AudioRepositories : IAudioRepositories
    {
        private readonly StreamingDataContext _dataContext;

        public AudioRepositories(StreamingDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Delete(int id)
        {
            var entity = await _dataContext.AUDIOs.FirstOrDefaultAsync(x => x.ID_AUDIO == id);

            if (entity is null)
            {
                throw new StreamingException(HttpStatusCode.UnprocessableEntity, ErrorMessages.RegisterNotFound, string.Format(ErrorMessages.Audio.NotFound, id));
            }

            _dataContext.Remove(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Insert(Audio request)
        {
            var entity = new AUDIO 
            {
                PATH = request.Path,
                ID_LANGUAGE = request.Language.IdLanguage,
                ID_FILM = request.IdFilm,
                ID_SERIES_EPISODE = request.IdSeriesEpisode
            };

            _dataContext.Add(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Update(Audio request)
        {
            var entity = await _dataContext.AUDIOs.FirstOrDefaultAsync(x => x.ID_AUDIO == request.IdAudio);

            if (entity is null)
            {
                throw new StreamingException(HttpStatusCode.UnprocessableEntity, ErrorMessages.RegisterNotFound, string.Format(ErrorMessages.Audio.NotFound, request.IdAudio));
            }

            entity.PATH = request.Path;
            entity.ID_LANGUAGE = request.Language.IdLanguage;

            _dataContext.Update(entity);
            await _dataContext.SaveChangesAsync();
        }
    }
}
