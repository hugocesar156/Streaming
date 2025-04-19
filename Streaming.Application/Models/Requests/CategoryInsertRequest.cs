using Streaming.Application.Validations;

namespace Streaming.Application.Models.Requests
{
    public class CategoryInsertRequest
    {
        [Required]
        [StringLength(30)]
        public string Name { get; init; } = string.Empty;
    }
}
