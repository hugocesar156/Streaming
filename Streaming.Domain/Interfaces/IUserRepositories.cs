using Streaming.Domain.Entities;

namespace Streaming.Domain.Interfaces
{
    public interface IUserRepositories
    {
        Task<User?> FindByEmail(string email);
        Task<User> Get(int id);
        Task InsertPasswordCode(PasswordCode request);
        Task SignIn(int id);
        Task<int> SignUp(User request);
    }
}
