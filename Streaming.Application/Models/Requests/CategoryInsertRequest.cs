using Streaming.Application.Validations;

namespace Streaming.Application.Models.Requests
{
    public class CategoryInsertRequest
    {
        [Required]
        public string Name { get; init; } = string.Empty;
    }
}
