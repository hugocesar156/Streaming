using Streaming.Application.Validations;

namespace Streaming.Application.Models.Requests
{
    public class ContentUpdateRequest
    {
        [Required]
        public int IdContent { get; init; }

        [Required]
        public string Description { get; init; } = string.Empty;
    }
}
