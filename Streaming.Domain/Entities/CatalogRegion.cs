namespace Streaming.Domain.Entities
{
    public class CatalogRegion
    {
        public CatalogRegion(string name, string classification, string synospsis, Language language, int? idFilm, int? idSeriesEpisode)
        {
            Name = name;
            Classification = classification;
            Synopsis = synospsis;
            Language = language;
            IdFilm = idFilm;
            IdSeriesEpisode = idSeriesEpisode;
        }

        public CatalogRegion(int idCatalogRegion, string name, string classification, string synospsis, Language language,
            int? idFilm, int? idSeriesEpisode)
        {
            IdCatalogRegion = idCatalogRegion;
            Name = name;
            Classification = classification;
            Synopsis = synospsis;
            Language = language;
            IdFilm = idFilm;
            IdSeriesEpisode = idSeriesEpisode;
        }

        public int IdCatalogRegion { get; private set; }
        public string Name { get; private set; }
        public string Classification { get; private set; }
        public string Synopsis { get; private set; }
        public Language Language { get; private set; }
        public int? IdFilm { get; set; }
        public int? IdSeriesEpisode { get; set; }
    }
}
