using Streaming.Application.Validations;

namespace Streaming.Application.Models.Requests.Film
{
    public class FilmUpdateRequest
    {
        [Required]
        public int IdFilm { get; init; }

        [Required]
        [StringLength(50)]
        public string Name { get; init; } = string.Empty;

        [Required]
        [Time]
        public string Duration { get; init; } = string.Empty;

        [Required]
        public string Thumbnail { get; init; } = string.Empty;

        [Required]
        public short Year { get; init; }

        [Time]
        [TimeLimit(nameof(Duration))]
        public string? CreditsStart { get; init; }

        [Required]
        public bool KidsContent { get; init; }

        [Required]
        public int IdLanguage { get; init; }
    }
}
