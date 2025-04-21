using Streaming.Application.Models.Requests.Audio;
using Streaming.Application.Validations;

namespace Streaming.Application.Models.Requests.Film
{
    public class FilmAudioInsertRequest
    {
        [Required]
        public int IdFilm { get; set; }

        public required AudioRequest Audio { get; set; }
    }
}
