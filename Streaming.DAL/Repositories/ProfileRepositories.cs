using Microsoft.EntityFrameworkCore;
using Streaming.DAL.Context;
using Streaming.DAL.Models;
using Streaming.Domain.Entities;
using Streaming.Domain.Interfaces;
using Streaming.Shared;
using System.Net;

namespace Streaming.DAL.Repositories
{
    public class ProfileRepositories : IProfileRepositories
    {
        private readonly StreamingDataContext _dataContext;

        public ProfileRepositories(StreamingDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Delete(int id)
        {
            var entity = _dataContext.PROFILEs.FirstOrDefault(x => x.ID_PROFILE == id);

            if (entity is null)
            {
                throw new StreamingException(HttpStatusCode.UnprocessableEntity, ErrorMessages.RegisterNotFound, string.Format(ErrorMessages.Profile.NotFound, id));
            }

            _dataContext.Remove(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Profile> Get(int id)
        {
            var entity = await _dataContext.PROFILEs.FirstOrDefaultAsync(x => x.ID_PROFILE == id);

            if (entity is null)
            {
                throw new StreamingException(HttpStatusCode.UnprocessableEntity, ErrorMessages.RegisterNotFound, string.Format(ErrorMessages.Profile.NotFound, id));
            }

            return new Profile(entity.ID_PROFILE, entity.NAME, entity.AVATAR, entity.KIDS_CONTENT, entity.ID_USER);
        }

        public async Task Insert(Profile request)
        {
            var entity = new PROFILE
            {
                NAME = request.Name,
                AVATAR = request.Avatar,
                ID_USER = request.IdUser
            };

            _dataContext.Add(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Update(Profile request)
        {
            var entity = await _dataContext.PROFILEs.FirstOrDefaultAsync(x => x.ID_PROFILE == request.IdProfile);

            if (entity is null)
            {
                throw new StreamingException(HttpStatusCode.UnprocessableEntity, ErrorMessages.RegisterNotFound, string.Format(ErrorMessages.Profile.NotFound, request.IdProfile));
            }

            entity.NAME = request.Name;
            entity.AVATAR = request.Avatar;

            _dataContext.Update(entity);
            await _dataContext.SaveChangesAsync();
        }
    }
}
