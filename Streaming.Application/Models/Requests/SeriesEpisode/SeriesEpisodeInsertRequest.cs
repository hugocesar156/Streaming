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
        public short Duration { get; init; }

        [Required]
        public short Year { get; init; }

        public short? OpeningStart { get; init; }

        public short? CreditsStart { get; init; }

        [Required]
        public int IdSeries { get; init; }
    }
}
