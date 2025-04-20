using Streaming.Application.Validations;

namespace Streaming.Application.Models.Requests.Media
{
    public partial class MediaRequest
    {
        [Required]
        [StringLength(200)]
        public string Path { get; init; } = string.Empty;

        [Required]
        public int IdResolution { get; init; }
    }
}
