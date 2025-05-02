using Streaming.Application.Models.Requests.Profile;

namespace Streaming.Application.Interfaces
{
    public interface IProfileUseCase
    {
        Task Delete(int id);
        Task Insert(ProfileIsertRequest request, int idUser);
        Task Update(ProfileUpdateRequest request);
    }
}
