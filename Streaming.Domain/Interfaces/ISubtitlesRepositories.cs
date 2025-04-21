using Streaming.Domain.Entities;

namespace Streaming.Domain.Interfaces
{
    public interface ISubtitlesRepositories
    {
        void Insert(Subtitles request);
    }
}
