namespace Streaming.Application.Models.Requests
{
    public class FilmContentRequest
    {
        public int IdFilm { get; init; }
        public int[] Contents { get; init; } = [];
    }
}
