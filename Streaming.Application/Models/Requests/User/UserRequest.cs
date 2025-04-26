using Streaming.Application.Validations;

namespace Streaming.Application.Models.Requests.User
{
    public class UserRequest
    {
        [Required]
        [Email]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
