namespace Streaming.Domain.Entities
{
    public class SeriesEpisode
    {
        public SeriesEpisode(string name, string thumbnail, string synopsis, short season, short episode,
           string duration, short year, string? openingStart, string? creditsStart, int idSeries)
        {
            Name = name;
            Thumbnail = thumbnail;
            Synopsis = synopsis;
            Season = season;    
            Episode = episode;
            Duration = duration;
            Year = year;
            OpeningStart = openingStart;
            CreditsStart = creditsStart;
            IdSeries = idSeries;
        }

        public SeriesEpisode(int idSeriesEpisode, string name, string thumbnail, string synopsis, short season,
            short episode, string duration, short year, string? openingStart, string? creditsStart, int idSeries)
        {
            IdSeriesEpisode = idSeriesEpisode;
            Name = name;
            Thumbnail = thumbnail;
            Synopsis = synopsis;
            Season = season;
            Episode = episode;
            Duration = duration;
            Year = year;
            OpeningStart = openingStart;
            CreditsStart = creditsStart;
            IdSeries = idSeries;
        }

        public int IdSeriesEpisode { get; private set; }
        public string Name { get; private set; }
        public string Thumbnail { get; private set; }
        public string Synopsis { get; private set; }
        public short Season { get; private set; }
        public short Episode { get; private set; }
        public string Duration { get; private set; }
        public short Year { get; private set; }
        public string? OpeningStart { get; private set; }
        public string? CreditsStart { get; private set; }
        public int IdSeries { get; private set; }
    }
}
