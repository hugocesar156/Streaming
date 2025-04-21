namespace Streaming.Domain.Entities
{
    public class Subtitles
    {
        public Subtitles(int idSubtitles, string path, Language language, int? idFilm, int? idSeriesEpisode)
        {
            IdSubtitles = idSubtitles;
            Path = path;
            Language = language;
            IdFilm = idFilm;
            IdSeriesEpisode = idSeriesEpisode;
        }

        public Subtitles(string path, Language language, int? idFilm, int? idSeriesEpisode)
        {
            Path = path;
            Language = language;
            IdFilm = idFilm;
            IdSeriesEpisode = idSeriesEpisode;
        }

        public int IdSubtitles { get; private set; }
        public string Path { get; private set; }
        public Language Language { get; private set; }
        public int? IdFilm { get; private set; }
        public int? IdSeriesEpisode { get; private set; }
    }
}
