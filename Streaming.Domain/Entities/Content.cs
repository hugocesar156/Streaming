namespace Streaming.Domain.Entities
{
    public class Content
    {
        public Content(string description)
        {
            Description = description;
        }

        public Content(int idContent, string description)
        {
            IdContent = idContent;
            Description = description;
        }

        public int IdContent { get; private set; }
        public string Description { get; private set; }
    }
}
