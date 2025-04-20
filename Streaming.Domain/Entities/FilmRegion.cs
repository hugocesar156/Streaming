namespace Streaming.Domain.Entities
{
    public class FilmRegion
    {
        public FilmRegion(string name, string classification, string synospsis, Language language)
        {
            Name = name;
            Classification = classification;
            Synopsis = synospsis;
            Language = language;
        }

        public FilmRegion(int idFilmRegion, string name, string classification, string synospsis, Language language)
        {
            IdFilmRegion = idFilmRegion;
            Name = name;
            Classification = classification;
            Synopsis = synospsis;
            Language = language;
        }

        public int IdFilmRegion { get; private set; }
        public string Name { get; private set; }
        public string Classification { get; private set; }
        public string Synopsis { get; private set; }
        public Language Language { get; private set; }
    }
}
