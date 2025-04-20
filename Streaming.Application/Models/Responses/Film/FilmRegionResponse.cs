using Streaming.Application.Models.Responses.Language;

namespace Streaming.Application.Models.Responses.Film
{
    public class FilmRegionResponse
    {
        public FilmRegionResponse(string name, string classification, string synopsis, LanguageResponse language)
        {
            Name = name;
            Classificacion = classification;
            Synopsis = synopsis;
            Language = language;
        }

        public string Name { get; private set; }
        public string Classificacion { get; private set; }
        public string Synopsis { get; private set; }
        public LanguageResponse Language { get; private set; }
    }
}
