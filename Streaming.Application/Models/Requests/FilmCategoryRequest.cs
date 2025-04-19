namespace Streaming.Application.Models.Requests
{
    public class FilmCategoryRequest
    {
        public int IdFilm { get; init; }
        public int[] Categories { get; init; } = [];
    }
}
