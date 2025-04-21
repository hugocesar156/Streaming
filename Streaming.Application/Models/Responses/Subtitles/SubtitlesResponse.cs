using Streaming.Application.Models.Responses.Language;

namespace Streaming.Application.Models.Responses.Subtitles
{
    public partial class SubtitlesResponse
    {
        public SubtitlesResponse(int idSubtitles, string path, LanguageResponse language)
        {
            IdSubtitles = idSubtitles;
            Path = path;
            Language = language;
        }

        public int IdSubtitles { get; private set; }
        public string Path { get; private set; }
        public LanguageResponse Language { get; private set; }
    }
}
