using Streaming.Application.Validations;

namespace Streaming.Application.Models.Requests
{
    public class FilmInsertRequest
    {
        [Required]
        [StringLength(50)]
        public string Name { get; init; } = string.Empty;

        [Required]
        public short Duration { get; init; }

        [Required]
        [StringLength(5)]
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

        public int[] Categories { get; init; } = [];

        public int[] Contents { get; init; } = [];

        public List<FilmCastRequest> Casting { get; set; } = [];
    }
}
