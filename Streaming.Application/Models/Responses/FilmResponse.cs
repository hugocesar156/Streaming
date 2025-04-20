namespace Streaming.Application.Models.Responses
{
    public class FilmResponse
    {
        public FilmResponse(int idFilm, string name, short duration, string classification, string synopsis, string thumbnail,
            string media, string preview, short year, List<CategoryResponse> categories, List<ContentResponse> contents, List<FilmCastResponse> casting)
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
            Categories = categories.Select(x => new CategoryResponse(x.IdCategory, x.Name)).ToList();
            Contents = contents.Select(x => new ContentResponse(x.IdContent, x.Description)).ToList();
            Casting = casting.Select(x => new FilmCastResponse(x.IdCast, x.Name, x.Character)).ToList();
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
        public List<CategoryResponse> Categories { get; private set; }
        public List<ContentResponse> Contents { get; private set; }
        public List<FilmCastResponse> Casting { get; private set; }
    }
}
