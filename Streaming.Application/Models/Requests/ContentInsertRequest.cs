using Streaming.Application.Validations;

namespace Streaming.Application.Models.Requests
{
    public class ContentInsertRequest
    {
        [Required]
        public string Description { get; init; } = string.Empty;
    }
}
