using Streaming.Application.Models.Responses.Category;
using Streaming.Application.Models.Responses.Contents;
using Streaming.Application.Models.Responses.Language;

namespace Streaming.Application.Models.Responses.Film
{
    public class FilmResponse
    {
        public FilmResponse(int idFilm, string name, short duration, string thumbnail, short year, short? openingStart, short? creditsStart, bool kidsContent, 
            LanguageResponse language, List<CategoryResponse> categories, List<ContentResponse> contents, List<FilmCastResponse> casting, List<FilmRegionResponse> regions)
        {
            IdFilm = idFilm;
            Name = name;
            Duration = duration;
            Thumbnail = thumbnail;
            Year = year;
            CreditsStart = creditsStart;
            OpeningStart = openingStart;
            KidsContent = kidsContent;
            Language = language;
            Categories = categories.Select(x => new CategoryResponse(x.IdCategory, x.Name)).ToList();
            Contents = contents.Select(x => new ContentResponse(x.IdContent, x.Description)).ToList();
            Casting = casting.Select(x => new FilmCastResponse(x.IdCast, x.Name, x.Character)).ToList();
            Regions = regions;
        }

        public int IdFilm { get; private set; }
        public string Name { get; private set; }
        public short Duration { get; private set; }
        public string Thumbnail { get; private set; }
        public short Year { get; private set; }
        public short? OpeningStart { get; private set; }
        public short? CreditsStart { get; private set; }
        public bool KidsContent { get; private set; }
        public LanguageResponse Language { get; private set; }
        public List<CategoryResponse> Categories { get; private set; }
        public List<ContentResponse> Contents { get; private set; }
        public List<FilmCastResponse> Casting { get; private set; }
        public List<FilmRegionResponse> Regions { get; set; }
    }
}
