namespace Streaming.Application.Models.Responses.Resolution
{
    public partial class ResolutionResponse
    {
        public ResolutionResponse(int idResolution, string description, string pixels)
        {
            IdResolution = idResolution;
            Description = description;
            Pixels = pixels;
        }

        public int IdResolution { get; private set; }
        public string Description { get; private set; }
        public string Pixels { get; private set; }
    }
}
