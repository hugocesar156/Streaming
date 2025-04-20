namespace Streaming.Domain.Entities
{
    public class CatalogRegion
    {
        public CatalogRegion(string name, string classification, string synospsis, Language language)
        {
            Name = name;
            Classification = classification;
            Synopsis = synospsis;
            Language = language;
        }

        public CatalogRegion(int idCatalogRegion, string name, string classification, string synospsis, Language language)
        {
            IdCatalogRegion = idCatalogRegion;
            Name = name;
            Classification = classification;
            Synopsis = synospsis;
            Language = language;
        }

        public int IdCatalogRegion { get; private set; }
        public string Name { get; private set; }
        public string Classification { get; private set; }
        public string Synopsis { get; private set; }
        public Language Language { get; private set; }
    }
}
