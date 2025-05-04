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
        private readonly IEmailSenderRepositories _emailSenderRepositories;
        private readonly ILanguageRepositories _languageRepositories;
        private readonly IProfileRepositories _profileRepositories;
        private readonly ITemplateRepositories _templateRepositories;
        private readonly IUserRepositories _userRepositories;

        public UserUseCase(IConfiguration configuration, IEmailSenderRepositories emailSenderRepositories, 
            ILanguageRepositories languageRepositories, IProfileRepositories profileRepositories,
            ITemplateRepositories templateRepositories, IUserRepositories userRepositories)
        {
            _configuration = configuration;
            _emailSenderRepositories = emailSenderRepositories;
            _languageRepositories = languageRepositories;
            _profileRepositories = profileRepositories;
            _templateRepositories = templateRepositories;
            _userRepositories = userRepositories;
        }

        public async Task<UserResponse> Login(UserRequest request)
        {
            try
            {
                var user = await _userRepositories.FindByEmail(request.Email);

                if (user is not null)
                {
                    if (EncryptServices.VerifyPassword(request.Password, user.Salt, user.Password))
                    {
                        await _userRepositories.SignIn(user.IdUser);

                        string token = TokenServices.GenerateToken(user.IdUser, _configuration["JWTSigningKey"]?.ToString() ?? string.Empty);
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

        public async Task SendPasswordCode(string email, string ipAddress)
        {
            try
            {
                var user = await _userRepositories.FindByEmail(email);

                if (user is null)
                {
                    throw new StreamingException(HttpStatusCode.MethodNotAllowed, ErrorMessages.ActionNotAllowed, ErrorMessages.User.EmailNotFound);
                }

                var addressByIP = await IPServices.GetAddressByIPAsync(ipAddress);
                var language = await _languageRepositories.GetByCountryCode(addressByIP.CountryCode);

                var template = await _templateRepositories.GetByName(TemplateName.ResetPassword, language.IdLanguage);
                var templateContent = template.Contents.First(x => x.Language.IdLanguage == language.IdLanguage);

                string code = new Random().Next(10000, 99999).ToString();

                var emailSender = await _emailSenderRepositories.Get();
                EmailServices.SendEmail(emailSender, user.Email, templateContent.Name, string.Format(templateContent.Content, code));

                var passwordCode = new PasswordCode(user.IdUser, code);
                await _userRepositories.InsertPasswordCode(passwordCode);
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

        public async Task SignUp(UserRequest request)
        {
            try
            {
                if (await _userRepositories.FindByEmail(request.Email) is not null)
                {
                    throw new StreamingException(HttpStatusCode.MethodNotAllowed, ErrorMessages.ActionNotAllowed, ErrorMessages.User.InvalidEmail);
                } 

                var (password, salt) = EncryptServices.EncryptPassword(request.Password);

                var user = new User(request.Email, password, salt);
                int iUser = await _userRepositories.SignUp(user);

                await _profileRepositories.Insert(new Profile(iUser));
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
