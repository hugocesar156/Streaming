namespace Streaming.Domain.Entities
{
    public class Template
    {
        public Template(int idTemplate)
        {
            IdTemplate = idTemplate;
            Name = string.Empty;
            Contents = [];
            Variables = [];
        }

        public Template(int idTemplate, string name, List<TemplateContent> contents, List<TemplateVariable> variables)
        {
            IdTemplate = idTemplate;
            Name = name;
            Contents = contents;
            Variables = variables;
        }

        public int IdTemplate { get; private set; }
        public string Name { get; private set; }
        public List<TemplateContent> Contents { get; set; }
        public List<TemplateVariable> Variables { get; set; }
    }
}
