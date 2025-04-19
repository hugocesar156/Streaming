namespace Streaming.Application.Models.Requests
{
    public class ContentUpdateRequest
    {
        public int IdContent { get; init; }
        public string Description { get; init; } = string.Empty;
    }
}
