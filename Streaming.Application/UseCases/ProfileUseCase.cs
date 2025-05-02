using Streaming.Application.Interfaces;
using Streaming.Application.Models.Requests.Profile;
using Streaming.Domain.Entities;
using Streaming.Domain.Interfaces;
using Streaming.Shared;
using System.Net;

namespace Streaming.Application.UseCases
{
    public class ProfileUseCase : IProfileUseCase
    {
        private readonly IProfileRepositories _profileRepositories;
        private readonly IUserRepositories _userRepositories;

        public ProfileUseCase(IProfileRepositories profileRepositories, IUserRepositories userRepositories)
        {
            _profileRepositories = profileRepositories;
            _userRepositories = userRepositories;
        }

        public async Task Delete(int id)
        {
            try
            {
                await _profileRepositories.Delete(id);
            }
            catch (StreamingException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new StreamingException(HttpStatusCode.InternalServerError, ex.Message, ex.InnerException?.Message);
            }
        }

        public async Task Insert(ProfileIsertRequest request, int idUser)
        {
            try
            {
                await _userRepositories.Get(idUser);

                var profile = new Profile(request.Name, request.Avatar, request.KidsContent, idUser);
                await _profileRepositories.Insert(profile);
            }
            catch (StreamingException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new StreamingException(HttpStatusCode.InternalServerError, ex.Message, ex.InnerException?.Message);
            }
        }

        public async Task Update(ProfileUpdateRequest request)
        {
            try
            {
                var profile = new Profile(request.IdProfile, request.Name, request.Avatar, request.KidsContent);
                await _profileRepositories.Update(profile);
            }
            catch (StreamingException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new StreamingException(HttpStatusCode.InternalServerError, ex.Message, ex.InnerException?.Message);
            }
        }
    }
}
