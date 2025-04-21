using Streaming.Application.Models.Responses.Resolution;

namespace Streaming.Application.Models.Responses.Media
{
    public partial class MediaResponse
    {
        public MediaResponse(int idMedia, string path, ResolutionResponse resolution)
        {
            IdMedia = idMedia;
            Path = path;
            Resolution = resolution;
        }

        public int IdMedia { get; private set; }
        public string Path { get; private set; }
        public ResolutionResponse Resolution { get; private set; }
    }
}
