using Streaming.Domain.Entities;

namespace Streaming.Domain.Interfaces
{
    public interface IUserRepositories
    {
        User? FindByEmail(string email);
        void SignIn(int idUser);
        void SignUp(User request);
    }
}
