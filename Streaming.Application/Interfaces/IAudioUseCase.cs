using Streaming.Application.Models.Requests.Audio;

namespace Streaming.Application.Interfaces
{
    public interface IAudioUseCase
    {
        Task Delete(int id);
        Task Update(AudioUpdateRequest request);
    }
}
