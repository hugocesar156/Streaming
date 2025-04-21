using Streaming.Application.Models.Responses.Language;

namespace Streaming.Application.Models.Responses.CatalogRegion
{
    public partial class CatalogRegionResponse
    {
        public CatalogRegionResponse(int idCatalogRegion, string name, string? classification, string synopsis, LanguageResponse language)
        {
            IdCatalogRegion = idCatalogRegion;
            Name = name;
            Classificacion = classification;
            Synopsis = synopsis;
            Language = language;
        }

        public CatalogRegionResponse(string name, string? classification, string synopsis, LanguageResponse language)
        {
            Name = name;
            Classificacion = classification;
            Synopsis = synopsis;
            Language = language;
        }

        public int IdCatalogRegion { get; private set; }
        public string Name { get; private set; }
        public string? Classificacion { get; private set; }
        public string Synopsis { get; private set; }
        public LanguageResponse Language { get; private set; }
    }
}
