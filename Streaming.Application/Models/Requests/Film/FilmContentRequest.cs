using Streaming.Application.Validations;

namespace Streaming.Application.Models.Requests.Film
{
    public class FilmContentRequest
    {
        [Required]
        public int IdFilm { get; init; }

        [Required]
        public int[] Contents { get; init; } = [];
    }
}
