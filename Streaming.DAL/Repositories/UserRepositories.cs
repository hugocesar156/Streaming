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

        public User? FindByEmail(string email)
        {
            var entity = _dataContext.USERs
                .Include(x => x.PROFILEs)
                .FirstOrDefault(x => x.EMAIL.Equals(email));

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

        public User Get(int id)
        {
            var entity = _dataContext.USERs.FirstOrDefault(x => x.ID_USER == id);

            if (entity is null) 
            {
                throw new StreamingException(HttpStatusCode.UnprocessableEntity, ErrorMessages.RegisterNotFound, string.Format(ErrorMessages.User.NotFound, id));
            }

            return new User(entity.ID_USER, entity.EMAIL, entity.PASSWORD, entity.SALT, entity.SIGN_UP_DATE, entity.SIGN_IN_DATE, []);
        }

        public void SignIn(int id)
        {
            var entity = _dataContext.USERs.FirstOrDefault(x => x.ID_USER == id);

            if (entity is null)
            {
                throw new StreamingException(HttpStatusCode.UnprocessableEntity, ErrorMessages.RegisterNotFound, string.Format(ErrorMessages.User.NotFound, id));
            }

            entity.SIGN_IN_DATE = DateTime.Now;

            _dataContext.Update(entity);
            _dataContext.SaveChanges();
        }

        public int SignUp(User request)
        {
            var entity = new USER
            {
                EMAIL = request.Email,
                PASSWORD = request.Password,
                SALT = request.Salt,
                SIGN_UP_DATE = DateTime.Now
            };

            _dataContext.Add(entity);
            _dataContext.SaveChanges();

            return entity.ID_USER;
        }
    }
}
