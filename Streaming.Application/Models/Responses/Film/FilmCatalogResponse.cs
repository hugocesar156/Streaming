using Streaming.Application.Models.Responses.Audio;
using Streaming.Application.Models.Responses.Cast;
using Streaming.Application.Models.Responses.Category;
using Streaming.Application.Models.Responses.Contents;
using Streaming.Application.Models.Responses.Media;
using Streaming.Application.Models.Responses.Subtitles;

namespace Streaming.Application.Models.Responses.Film
{
    public class FilmCatalogResponse
    {
        public FilmCatalogResponse(int idFilm, string name, string classification, string synopsis, string duration, string thumbnail, 
            short year, string? creditsStart, bool kidsContent, List<CategoryResponse> categories, List<ContentResponse> contents, 
            List<CastResponse> casting, List<MediaResponse> medias, List<AudioResponse> audios, List<SubtitlesResponse> subtitles)
        {
            IdFilm = idFilm;
            Name = name;
            Classification = classification;
            Synopsis = synopsis;
            Duration = duration;
            Thumbnail = thumbnail;
            Year = year;
            CreditsStart = creditsStart;
            KidsContent = kidsContent;
            Categories = categories;
            Contents = contents;
            Casting = casting;
            Medias = medias;
            Audios = audios;
            Subtitles = subtitles;
        }

        public int IdFilm { get; private set; }
        public string Name { get; private set; }
        public string Classification { get; private set; }
        public string Synopsis { get; private set; }
        public string Duration { get; private set; }
        public string Thumbnail { get; private set; }
        public short Year { get; private set; }
        public string? CreditsStart { get; private set; }
        public bool KidsContent { get; private set; }
        public List<CategoryResponse> Categories { get; private set; }
        public List<ContentResponse> Contents { get; private set; }
        public List<CastResponse> Casting { get; private set; }
        public List<MediaResponse> Medias { get; private set; }
        public List<AudioResponse> Audios { get; private set; }
        public List<SubtitlesResponse> Subtitles { get; private set; }
    }
}
