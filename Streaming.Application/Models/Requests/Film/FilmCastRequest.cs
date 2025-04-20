using Streaming.Application.Validations;

namespace Streaming.Application.Models.Requests.Film
{
    public partial class FilmCastRequest
    {
        [Required]
        [StringLength(100)]
        public string Name { get; init; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Character { get; init; } = string.Empty;
    }
}
