using Streaming.Application.Models.Requests.User;
using Streaming.Application.Models.Responses.User;

namespace Streaming.Application.Interfaces
{
    public interface IUserUseCase
    {
        Task<UserResponse> Login(UserRequest request);
        Task SendPasswordCode(string email, string ipAddress);
        Task SignUp(UserRequest request);
    }
}
