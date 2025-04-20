namespace Streaming.Domain.Entities
{
    public class Film
    {
        public Film(int idFilm, string name, short duration, string classification, string synopsis, string thumbnail, short year, Language language)
        {
            IdFilm = idFilm;
            Name = name;
            Duration = duration;
            Classification = classification;
            Synopsis = synopsis;
            Thumbnail = thumbnail;
            Year = year;
            Language = language;
            Categories = [];
            Contents = [];
            Casting = [];
        }

        public Film(string name, short duration, string classification, string synopsis, string thumbnail, short year, Language language)
        {
            Name = name;
            Duration = duration;
            Classification = classification;
            Synopsis = synopsis;
            Thumbnail = thumbnail;
            Year = year;
            Language = language;
            Categories = [];
            Contents = [];
            Casting = [];
        }

        public Film(int idFilm, string name, short duration, string classification, string synopsis, string thumbnail, 
            short year, Language language, List<Category> categories, List<Content> contents, List<Cast> casting)
        {
            IdFilm = idFilm;
            Name = name;    
            Duration = duration;
            Classification = classification;
            Synopsis = synopsis;
            Thumbnail = thumbnail;
            Year = year;
            Language = language;
            Categories = categories.Select(x => new Category(x.IdCategory, x.Name)).ToList();
            Contents = contents.Select(x => new Content(x.IdContent, x.Description)).ToList();
            Casting = casting.Select(x => new Cast(x.IdCast, x.Name, x.Character)).ToList();
        }

        public int IdFilm { get; private set; }
        public string Name { get; private set; }
        public short Duration { get; private set; }
        public string Classification { get; private set; }
        public string Synopsis { get; private set; }
        public string Thumbnail { get; private set; }
        public short Year { get; private set; }
        public Language Language { get; private set; }
        public List<Category> Categories { get; private set; }
        public List<Content> Contents { get; private set; }
        public List<Cast> Casting { get; private set; }
    }
}
