namespace Streaming.Domain.Entities
{
    public class TemplateContent
    {
        public TemplateContent(int idTemplateContent, string name, string content, int idTemplate, Language language)
        {
            IdTemplateContent = idTemplateContent;
            Name = name;
            Content = content;
            IdTemplate = idTemplate;
            Language = language;
        }

        public int IdTemplateContent { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public int IdTemplate { get; set; }
        public Language Language { get; set; }
    }
}
