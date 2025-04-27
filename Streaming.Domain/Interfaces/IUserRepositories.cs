using Streaming.Domain.Entities;

namespace Streaming.Domain.Interfaces
{
    public interface IUserRepositories
    {
        User? FindByEmail(string email);
        User Get(int id);
        void SignIn(int id);
        int SignUp(User request);
    }
}
