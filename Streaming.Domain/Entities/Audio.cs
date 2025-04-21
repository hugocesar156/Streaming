namespace Streaming.Domain.Entities
{
    public class Audio
    {
        public Audio(int idAudio, string path, Language language, int? idFilm, int? idSeriesEpisode)
        {
            IdAudio = idAudio;
            Path = path;
            Language = language;
            IdFilm = idFilm;
            IdSeriesEpisode = idSeriesEpisode;
        }

        public Audio(string path, Language language, int? idFilm, int? idSeriesEpisode)
        {
            Path = path;
            Language = language;
            IdFilm = idFilm;
            IdSeriesEpisode = idSeriesEpisode;
        }

        public int IdAudio { get; private set; }
        public string Path { get; private set; }
        public Language Language { get; private set; }
        public int? IdFilm { get; private set; }
        public int? IdSeriesEpisode { get; private set; }
    }
}
