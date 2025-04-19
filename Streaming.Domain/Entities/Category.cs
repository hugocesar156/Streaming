namespace Streaming.Domain.Entities
{
    public class Category
    {
        public Category(string name)
        {
            Name = name;
        }

        public Category(int idCategory, string name)
        {
            IdCategory = idCategory;
            Name = name;
        }

        public int IdCategory { get; private set; }
        public string Name { get; private set; }
    }
}
