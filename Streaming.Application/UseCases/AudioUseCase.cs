using Streaming.Application.Interfaces;
using Streaming.Application.Models.Requests.Audio;
using Streaming.Domain.Entities;
using Streaming.Domain.Interfaces;
using Streaming.Shared;
using System.Net;

namespace Streaming.Application.UseCases
{
    public class AudioUseCase : IAudioUseCase
    {
        private readonly IAudioRepositories _audioRepositories;

        public AudioUseCase(IAudioRepositories audioRepositories)
        {
            _audioRepositories = audioRepositories;
        }

        public void Delete(int id)
        {
            try
            {
                _audioRepositories.Delete(id);
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

        public void Update(AudioUpdateRequest request)
        {
            try
            {
                var audio = new Audio(request.IdAudio, request.Path, new Language(request.IdLanguage), null, null);
                _audioRepositories.Update(audio);
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
