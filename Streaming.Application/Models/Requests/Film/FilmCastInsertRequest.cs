using Streaming.Application.Models.Requests.Cast;
using Streaming.Application.Validations;

namespace Streaming.Application.Models.Requests.Film
{
    public class FilmCastInsertRequest
    {
        [Required]
        public int IdFilm { get; init; }

        public List<CastRequest> Casting { get; set; } = [];
    }
}
