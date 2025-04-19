using Streaming.Application.Validations;

namespace Streaming.Application.Models.Requests
{
    public class ContentInsertRequest
    {
        [Required]
        [StringLength(50)]
        public string Description { get; init; } = string.Empty;
    }
}
