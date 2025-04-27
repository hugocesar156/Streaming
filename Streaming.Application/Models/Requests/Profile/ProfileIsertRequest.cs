using Streaming.Application.Validations;

namespace Streaming.Application.Models.Requests.Profile
{
    public class ProfileIsertRequest
    {
        [Required]
        [StringLength(30)]
        public string Name { get; init; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string Avatar { get; init; } = string.Empty;
    }
}
