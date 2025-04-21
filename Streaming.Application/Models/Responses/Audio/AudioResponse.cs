using Streaming.Application.Models.Responses.Language;

namespace Streaming.Application.Models.Responses.Audio
{
    public partial class AudioResponse
    {
        public AudioResponse(int idAudio, string path, LanguageResponse language)
        {
            IdAudio = idAudio;
            Path = path;
            Language = language;
        }

        public int IdAudio { get; private set; }
        public string Path { get; private set; }
        public LanguageResponse Language { get; private set; }
    }
}
