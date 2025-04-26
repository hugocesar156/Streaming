using Streaming.Application.Models.Requests.User;
using Streaming.Application.Models.Responses.User;

namespace Streaming.Application.Interfaces
{
    public interface IUserUseCase
    {
        UserResponse Login(UserRequest request);
        void SignUp(UserRequest request);
    }
}
