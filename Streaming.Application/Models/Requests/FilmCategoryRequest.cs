using Streaming.Application.Validations;

namespace Streaming.Application.Models.Requests
{
    public class FilmCategoryRequest
    {
        [Required]
        public int IdFilm { get; init; }

        [Required]
        public int[] Categories { get; init; } = [];
    }
}
