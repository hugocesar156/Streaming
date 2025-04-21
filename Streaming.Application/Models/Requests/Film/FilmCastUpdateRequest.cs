using Streaming.Application.Models.Requests.Cast;
using Streaming.Application.Validations;

namespace Streaming.Application.Models.Requests.Film
{
    public class FilmCastUpdateRequest
    {
        [Required]
        public int IdCast { get; init; }

        public required CastRequest Cast { get; init; }
    }
}
