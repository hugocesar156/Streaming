using Streaming.Application.Validations;

namespace Streaming.Application.Models.Requests
{
    public class FilmUpdateRequest
    {
        [Required]
        public int IdFilm { get; init; }

        [Required]
        public string Name { get; init; } = string.Empty;

        [Required]
        public short Duration { get; init; }

        [Required]
        public string Classification { get; init; } = string.Empty;

        [Required]
        public string Synopsis { get; init; } = string.Empty;

        [Required]
        public string Thumbnail { get; init; } = string.Empty;

        [Required]
        public string Media { get; init; } = string.Empty;

        [Required]
        public string Preview { get; init; } = string.Empty;

        [Required]
        public short Year { get; init; }
    }
}
