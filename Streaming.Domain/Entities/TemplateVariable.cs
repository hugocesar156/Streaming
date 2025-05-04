namespace Streaming.Domain.Entities
{
    public class TemplateVariable
    {
        public TemplateVariable(int idTemplateVariable, string name, byte position, int idTemplate)
        {
            IdTemplateVariable = idTemplateVariable;
            Name = name;
            Position = position;
            IdTemplate = idTemplate;
        }

        public int IdTemplateVariable { get; set; }
        public string Name { get; set; }
        public byte Position { get; set; }
        public int IdTemplate { get; set; }
    }
}
