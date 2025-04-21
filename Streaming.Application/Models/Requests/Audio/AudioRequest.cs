using Streaming.Application.Validations;

namespace Streaming.Application.Models.Requests.Audio
{
    public partial class AudioRequest
    {
        [Required]
        [StringLength(200)]
        public string Path { get; init; } = string.Empty;

        [Required]
        public int IdLanguage { get; init; }
    }
}
