namespace Streaming.Application.Models.Responses.User
{
    public class UserResponse
    {
        public UserResponse(string tokenAccess)
        {
            TokenAccess = tokenAccess;
        }

        public string TokenAccess { get; set; } = string.Empty;
    }
}
