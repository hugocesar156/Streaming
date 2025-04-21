using Streaming.Application.Models.Requests.Subtitles;
using Streaming.Application.Validations;

namespace Streaming.Application.Models.Requests.Film
{
    public class FilmSubtitlesInsertRequest
    {
        [Required]
        public int IdFilm { get; init; }
        public required SubtitlesRequest Subtitles { get; init; }
    }
}
