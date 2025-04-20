using Streaming.Application.Validations;

namespace Streaming.Application.Models.Requests.Content
{
    public class ContentUpdateRequest
    {
        [Required]
        public int IdContent { get; init; }

        [Required]
        [StringLength(50)]
        public string Description { get; init; } = string.Empty;
    }
}
