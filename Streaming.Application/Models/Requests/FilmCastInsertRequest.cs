using Streaming.Application.Validations;

namespace Streaming.Application.Models.Requests
{
    public class FilmCastInsertRequest
    {
        [Required]
        [StringLength(100)]
        public int IdFilm { get; init; }

        public List<FilmCastRequest> Casting { get; set; } = [];
    }
}
