using Streaming.Application.Validations;

namespace Streaming.Application.Models.Requests.Film
{
    public class FilmCastUpdateRequest
    {
        [Required]
        public int IdCast { get; init; }

        [Required]
        [StringLength(100)]
        public string Name { get; init; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Character { get; init; } = string.Empty;
    }
}
