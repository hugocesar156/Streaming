using Microsoft.EntityFrameworkCore;
using Streaming.DAL.Context;
using Streaming.DAL.Models;
using Streaming.Domain.Entities;
using Streaming.Domain.Interfaces;
using Streaming.Shared;
using System.Net;

namespace Streaming.DAL.Repositories
{
    public class UserRepositories : IUserRepositories
    {
        private readonly StreamingDataContext _dataContext;

        public UserRepositories(StreamingDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<User?> FindByEmail(string email)
        {
            var entity = await _dataContext.USERs
                .Include(x => x.PROFILEs)
                .FirstOrDefaultAsync(x => x.EMAIL.Equals(email));

            if (entity is not null)
            {
                return new User(
                    entity.ID_USER, 
                    entity.EMAIL,
                    entity.PASSWORD,
                    entity.SALT, 
                    entity.SIGN_UP_DATE,
                    entity.SIGN_IN_DATE,
                    
                    entity.PROFILEs.Select(x => new Profile(
                        x.ID_PROFILE,
                        x.NAME,
                        x.AVATAR,
                        x.KIDS_CONTENT,
                        x.ID_USER)).ToList());
            }

            return null;
        }

        public async Task<User> Get(int id)
        {
            var entity = await _dataContext.USERs.FirstOrDefaultAsync(x => x.ID_USER == id);

            if (entity is not null) 
            {
                return new User(entity.ID_USER, entity.EMAIL, entity.PASSWORD, entity.SALT, entity.SIGN_UP_DATE, entity.SIGN_IN_DATE, []);
            }

            throw new StreamingException(HttpStatusCode.UnprocessableEntity, ErrorMessages.RegisterNotFound, string.Format(ErrorMessages.User.NotFound, id));
        }

        public async Task InsertPasswordCode(PasswordCode request)
        {
            var entity = new PASSWORD_CODE
            {
                ID_USER = request.IdUser,
                CODE = request.Code,
                VERIFIED = false,
                CREATION_DATE = DateTime.Now
            };

            _dataContext.Add(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task SignIn(int id)
        {
            var entity = await _dataContext.USERs.FirstOrDefaultAsync(x => x.ID_USER == id);

            if (entity is null)
            {
                throw new StreamingException(HttpStatusCode.UnprocessableEntity, ErrorMessages.RegisterNotFound, string.Format(ErrorMessages.User.NotFound, id));
            }

            entity.SIGN_IN_DATE = DateTime.Now;

            _dataContext.Update(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<int> SignUp(User request)
        {
            var entity = new USER
            {
                EMAIL = request.Email,
                PASSWORD = request.Password,
                SALT = request.Salt,
                SIGN_UP_DATE = DateTime.Now
            };

            _dataContext.Add(entity);
            await _dataContext.SaveChangesAsync();

            return entity.ID_USER;
        }
    }
}
