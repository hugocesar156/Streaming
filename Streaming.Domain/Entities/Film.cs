namespace Streaming.Domain.Entities
{
    public class Film
    {
        public Film(int idFilm, string name, short duration, string thumbnail, short year, short? creditsStart, bool kidsContent, Language language)
        {
            IdFilm = idFilm;
            Name = name;
            Duration = duration;
            Thumbnail = thumbnail;
            Year = year;
            CreditsStart = creditsStart;
            KidsContent = kidsContent;
            Language = language;
            Categories = [];
            Contents = [];
            Casting = [];
            Regions = [];
        }

        public Film(string name, short duration, string thumbnail, short year, short? creditsStart, bool kidsContent, Language language)
        {
            Name = name;
            Duration = duration;
            Thumbnail = thumbnail;
            Year = year;
            CreditsStart = creditsStart;
            KidsContent = kidsContent;
            Language = language;
            Categories = [];
            Contents = [];
            Casting = [];
            Regions = [];
        }

        public Film(int idFilm, string name, short duration, string thumbnail, short year, short? creditsStart, bool kidsContent,
            Language language, List<Category> categories, List<Content> contents, List<Cast> casting, List<CatalogRegion> regions)
        {
            IdFilm = idFilm;
            Name = name;    
            Duration = duration;
            Thumbnail = thumbnail;
            Year = year;
            CreditsStart = creditsStart;
            KidsContent = kidsContent;
            Language = language;
            Categories = categories.Select(x => new Category(x.IdCategory, x.Name)).ToList();
            Contents = contents.Select(x => new Content(x.IdContent, x.Description)).ToList();
            Casting = casting.Select(x => new Cast(x.IdCast, x.Name, x.Character, null)).ToList();
            Regions = regions.Select(x => new CatalogRegion(x.IdCatalogRegion, x.Name, x.Classification, x.Synopsis, 
                new Language(x.Language.IdLanguage, x.Language.Description, x.Language.Code), x.IdFilm, null)).ToList();
        }

        public int IdFilm { get; private set; }
        public string Name { get; private set; }
        public short Duration { get; private set; }
        public string Thumbnail { get; private set; }
        public short Year { get; private set; }
        public short? CreditsStart { get; set; }
        public bool KidsContent { get; set; }
        public Language Language { get; private set; }
        public List<Category> Categories { get; private set; }
        public List<Content> Contents { get; private set; }
        public List<Cast> Casting { get; private set; }
        public List<CatalogRegion> Regions { get; set; }
    }
}
