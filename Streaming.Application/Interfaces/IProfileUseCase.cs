using Streaming.Application.Models.Requests.Profile;

namespace Streaming.Application.Interfaces
{
    public interface IProfileUseCase
    {
        void Delete(int id);
        void Insert(ProfileIsertRequest request, int idUser);
        void Update(ProfileUpdateRequest request);
    }
}
