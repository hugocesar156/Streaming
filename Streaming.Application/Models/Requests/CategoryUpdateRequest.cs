using Streaming.Application.Validations;

namespace Streaming.Application.Models.Requests
{
    public class CategoryUpdateRequest
    {
        [Required]
        public int Id { get; init; }

        [Required]
        [StringLength(30)]
        public string Name { get; init; } = string.Empty;
    }
}
