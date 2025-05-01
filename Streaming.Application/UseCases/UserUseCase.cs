using Microsoft.Extensions.Configuration;
using Streaming.Application.Interfaces;
using Streaming.Application.Models.Requests.User;
using Streaming.Application.Models.Responses.Profile;
using Streaming.Application.Models.Responses.User;
using Streaming.Application.Services;
using Streaming.Domain.Entities;
using Streaming.Domain.Interfaces;
using Streaming.Shared;
using System.Net;

namespace Streaming.Application.UseCases
{
    public class UserUseCase : IUserUseCase
    {
        private readonly IConfiguration _configuration;
        private readonly IProfileRepositories _profileRepositories;
        private readonly IUserRepositories _userRepositories;

        public UserUseCase(IConfiguration configuration, IProfileRepositories profileRepositories, IUserRepositories userRepositories)
        {
            _configuration = configuration;
            _profileRepositories = profileRepositories;
            _userRepositories = userRepositories;
        }

        public UserResponse Login(UserRequest request)
        {
            try
            {
                var user = _userRepositories.FindByEmail(request.Email);

                if (user is not null)
                {
                    if (EncryptServices.VerifyPassword(request.Password, user.Salt, user.Password))
                    {
                        _userRepositories.SignIn(user.IdUser);

                        var token = TokenServices.GenerateToken(user.IdUser, _configuration["JWTSigningKey"]?.ToString() ?? string.Empty);
                        return new UserResponse(token, user.Profiles.Select(x => new ProfileResponse(x.IdProfile, x.Name, x.Avatar, x.KidsContent)).ToList());
                    }

                    throw new StreamingException(HttpStatusCode.MethodNotAllowed, ErrorMessages.ActionNotAllowed, ErrorMessages.User.WrongPassword);
                }

                throw new StreamingException(HttpStatusCode.MethodNotAllowed, ErrorMessages.ActionNotAllowed, ErrorMessages.User.EmailNotFound);
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

        public void SignUp(UserRequest request)
        {
            try
            {
                if (_userRepositories.FindByEmail(request.Email) is not null)
                {
                    throw new StreamingException(HttpStatusCode.MethodNotAllowed, ErrorMessages.ActionNotAllowed, ErrorMessages.User.InvalidEmail);
                } 

                var (password, salt) = EncryptServices.EncryptPassword(request.Password);

                var user = new User(request.Email, password, salt);
                var iUser = _userRepositories.SignUp(user);

                _profileRepositories.Insert(new Profile(iUser));
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
