using Streaming.Application.Validations;

namespace Streaming.Application.Models.Requests.SeriesEpisode
{
    public class SeriesEpisodeInsertRequest
    {
        [Required]
        [StringLength(50)]
        public string Name { get; init; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string Thumbnail { get; init; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string Synopsis { get; init; } = string.Empty;

        [Required]
        public short Season { get; init; }

        [Required]
        public short Episode { get; init; }

        [Required]
        [Time]
        public string Duration { get; init; } = string.Empty;

        [Required]
        public short Year { get; init; }

        [Time]
        [TimeLimit(nameof(Duration))]
        public string? OpeningStart { get; init; }

        [Time]
        [TimeLimit(nameof(Duration))]
        public string? CreditsStart { get; init; }

        [Required]
        public int IdSeries { get; init; }
    }
}
