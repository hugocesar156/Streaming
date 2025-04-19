namespace Streaming.Domain.Entities
{
    public class Film
    {
        public Film(int idFilm, string name, short duration, string classification, string synopsis, string thumbnail, 
            string media, string preview, short year)
        {
            IdFilm = idFilm;
            Name = name;
            Duration = duration;
            Classification = classification;
            Synopsis = synopsis;
            Thumbnail = thumbnail;
            Media = media;
            Preview = preview;
            Year = year;
            Categories = [];
            Contents = [];
        }

        public Film(string name, short duration, string classification, string synopsis, string thumbnail, string media, 
            string preview, short year)
        {
            Name = name;
            Duration = duration;
            Classification = classification;
            Synopsis = synopsis;
            Thumbnail = thumbnail;
            Media = media;
            Preview = preview;
            Year = year;
            Categories = [];
            Contents = [];
        }

        public Film(int idFilm, string name, short duration, string classification, string synopsis, string thumbnail, 
            string media, string preview, short year, List<Category> categories, List<Content> contents)
        {
            IdFilm = idFilm;
            Name = name;    
            Duration = duration;
            Classification = classification;
            Synopsis = synopsis;
            Thumbnail = thumbnail;
            Media = media;
            Preview = preview;
            Year = year;
            Categories = categories.Select(x => new Category(x.IdCategory, x.Name)).ToList();
            Contents = contents.Select(x => new Content(x.IdContent, x.Description)).ToList();
        }

        public int IdFilm { get; private set; }
        public string Name { get; private set; }
        public short Duration { get; private set; }
        public string Classification { get; private set; }
        public string Synopsis { get; private set; }
        public string Thumbnail { get; private set; }
        public string Media { get; private set; }
        public string Preview { get; private set; }
        public short Year { get; private set; }
        public List<Category> Categories { get; private set; }
        public List<Content> Contents { get; private set; }
    }
}
