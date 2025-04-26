using Streaming.Application.Models.Responses.Profile;

namespace Streaming.Application.Models.Responses.User
{
    public class UserResponse
    {
        public UserResponse(string tokenAccess, List<ProfileResponse> profiles)
        {
            TokenAccess = tokenAccess;
            Profiles = profiles;
        }

        public string TokenAccess { get; set; } = string.Empty;
        public List<ProfileResponse> Profiles { get; set; }
    }
}
