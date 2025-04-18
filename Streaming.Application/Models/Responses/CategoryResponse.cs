namespace Streaming.Application.Models.Responses
{
    public class CategoryResponse
    {
        public CategoryResponse(int idCategory, string name)
        {
            IdCategory = idCategory;
            Name = name;
        }

        public int IdCategory { get; private set; }
        public string Name { get; private set; }
    }
}
