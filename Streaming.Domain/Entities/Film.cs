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
            Medias = [];
            Audios = [];
            Subtitles = [];
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
            Medias = [];
            Audios = [];
            Subtitles = [];
        }

        public Film(int idFilm, string name, short duration, string thumbnail, short year, short? creditsStart, bool kidsContent,
            Language language, List<Category> categories, List<Content> contents, List<Cast> casting, List<CatalogRegion> regions,
            List<Media> medias, List<Audio> audios, List<Subtitles> subtitles)
        {
            IdFilm = idFilm;
            Name = name;    
            Duration = duration;
            Thumbnail = thumbnail;
            Year = year;
            CreditsStart = creditsStart;
            KidsContent = kidsContent;
            Language = language;
            Categories = categories;
            Contents = contents;
            Casting = casting;
            Regions = regions;
            Medias = medias;
            Audios = audios;
            Subtitles = subtitles;
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
        public List<Media> Medias { get; set; }
        public List<Audio> Audios { get; set; }
        public List<Subtitles> Subtitles { get; set; }
    }
}
