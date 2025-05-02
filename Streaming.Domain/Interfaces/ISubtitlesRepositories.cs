using Streaming.Domain.Entities;

namespace Streaming.Domain.Interfaces
{
    public interface ISubtitlesRepositories
    {
        Task Insert(Subtitles request);
    }
}
