using Streaming.Application.Models.Requests.Audio;

namespace Streaming.Application.Interfaces
{
    public interface IAudioUseCase
    {
        void Delete(int id);
        void Update(AudioUpdateRequest request);
    }
}
