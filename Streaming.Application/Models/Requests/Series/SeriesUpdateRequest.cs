using Streaming.Application.Validations;

namespace Streaming.Application.Models.Requests.Series
{
    public class SeriesUpdateRequest
    {
        [Required]
        public int IdSeries { get; init; }

        [Required]
        [StringLength(50)]
        public string Name { get; init; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string Thumbnail { get; init; } = string.Empty;

        [Required]
        public short Year { get; init; }

        [Required]
        public bool KidsContent { get; init; }

        [Required]
        public int IdLanguage { get; init; }
    }
}
