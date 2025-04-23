using Streaming.Application.Models.Requests.Cast;
using Streaming.Application.Validations;

namespace Streaming.Application.Models.Requests.Film
{
    public class FilmInsertRequest
    {
        [Required]
        [StringLength(50)]
        public string Name { get; init; } = string.Empty;

        [Required]
        public short Duration { get; init; }

        [Required]
        [StringLength(200)]
        public string Thumbnail { get; init; } = string.Empty;

        [Required]
        public short Year { get; init; }

        public short? CreditsStart { get; init; }

        [Required]
        public bool KidsContent { get; init; }

        [Required]
        public int IdLanguage { get; init; } 

        public int[] Categories { get; init; } = [];

        public int[] Contents { get; init; } = [];

        public List<CastRequest> Casting { get; set; } = [];
    }
}
