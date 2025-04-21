using Streaming.Application.Models.Responses.Audio;
using Streaming.Application.Models.Responses.Cast;
using Streaming.Application.Models.Responses.CatalogRegion;
using Streaming.Application.Models.Responses.Category;
using Streaming.Application.Models.Responses.Contents;
using Streaming.Application.Models.Responses.Language;
using Streaming.Application.Models.Responses.Media;
using Streaming.Application.Models.Responses.Subtitles;

namespace Streaming.Application.Models.Responses.Film
{
    public class FilmResponse
    {
        public FilmResponse(int idFilm, string name, short duration, string thumbnail, short year, short? creditsStart, bool kidsContent, 
            LanguageResponse language, List<CategoryResponse> categories, List<ContentResponse> contents, List<CastResponse> casting, 
            List<CatalogRegionResponse> regions, List<MediaResponse> medias, List<AudioResponse> audios, List<SubtitlesResponse> subtitles)
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
        public short? CreditsStart { get; private set; }
        public bool KidsContent { get; private set; }
        public LanguageResponse Language { get; private set; }
        public List<CategoryResponse> Categories { get; private set; }
        public List<ContentResponse> Contents { get; private set; }
        public List<CastResponse> Casting { get; private set; }
        public List<CatalogRegionResponse> Regions { get; private set; }
        public List<MediaResponse> Medias { get; private set; }
        public List<AudioResponse> Audios { get; private set; }
        public List<SubtitlesResponse> Subtitles { get; private set; }
    }
}
