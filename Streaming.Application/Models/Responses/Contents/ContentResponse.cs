namespace Streaming.Application.Models.Responses.Contents
{
    public class ContentResponse
    {
        public ContentResponse(int idContent, string description)
        {
            IdContent = idContent;
            Description = description;
        }

        public int IdContent { get; private set; }
        public string Description { get; private set; }
    }
}
