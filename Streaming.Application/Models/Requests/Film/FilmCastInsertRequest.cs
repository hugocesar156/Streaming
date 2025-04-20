using Streaming.Application.Validations;

namespace Streaming.Application.Models.Requests.Film
{
    public class FilmCastInsertRequest
    {
        [Required]
        public int IdFilm { get; init; }

        public List<FilmCastRequest> Casting { get; set; } = [];
    }
}
