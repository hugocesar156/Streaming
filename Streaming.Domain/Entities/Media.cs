namespace Streaming.Domain.Entities
{
    public class Media
    {
        public Media(string path, Resolution resolution, int? idFilm, int? idSeriesEpisode)
        {
            Path = path;
            Resolution = resolution;
            IdFilm = idFilm;
            IdSeriesEpisode = idSeriesEpisode;
        }

        public Media(int idMedia, string path, Resolution resolution, int? idFilm, int? idSeriesEpisode)
        {
            IdMedia = idMedia;
            Path = path;
            Resolution = resolution;
            IdFilm = idFilm;
            IdSeriesEpisode = idSeriesEpisode;
        }

        public int IdMedia { get; private set; }
        public string Path { get; private set; }
        public Resolution Resolution { get; private set; }
        public int? IdFilm { get; private set; }
        public int? IdSeriesEpisode { get; private set; }
    }
}
