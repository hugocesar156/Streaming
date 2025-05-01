using Streaming.Application.Validations;

namespace Streaming.Application.Models.Requests.Audio
{
    public class AudioUpdateRequest
    {
        [Required]
        public int IdAudio { get; init; }

        [Required]
        [StringLength(200)]
        public string Path { get; init; } = string.Empty;

        [Required]
        public int IdLanguage { get; init; }
    }
}
