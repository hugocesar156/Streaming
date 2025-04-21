namespace Streaming.Domain.Entities
{
    public class CatalogRegion
    {
        public CatalogRegion(string name, string? classification, string synospsis, Language language, int? idFilm, int? idSeries)
        {
            Name = name;
            Classification = classification;
            Synopsis = synospsis;
            Language = language;
            IdFilm = idFilm;
            IdSeries = idSeries;
        }

        public CatalogRegion(int idCatalogRegion, string name, string? classification, string synospsis, Language language,
            int? idFilm, int? idSeries)
        {
            IdCatalogRegion = idCatalogRegion;
            Name = name;
            Classification = classification;
            Synopsis = synospsis;
            Language = language;
            IdFilm = idFilm;
            IdSeries = idSeries;
        }

        public int IdCatalogRegion { get; private set; }
        public string Name { get; private set; }
        public string? Classification { get; private set; }
        public string Synopsis { get; private set; }
        public Language Language { get; private set; }
        public int? IdFilm { get; set; }
        public int? IdSeries { get; set; }
    }
}
