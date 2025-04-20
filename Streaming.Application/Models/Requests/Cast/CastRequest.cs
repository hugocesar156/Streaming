using Streaming.Application.Validations;

namespace Streaming.Application.Models.Requests.Cast
{
    public partial class CastRequest
    {
        [Required]
        [StringLength(100)]
        public string Name { get; init; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Character { get; init; } = string.Empty;
    }
}
