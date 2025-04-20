using Streaming.Application.Models.Requests.Media;
using Streaming.Application.Validations;

namespace Streaming.Application.Models.Requests.Film
{
    public class FilmMediaInsertRequest
    {
        [Required]
        public int IdFilm { get; init; }

        public required MediaRequest Media { get; init; }
    }
}
