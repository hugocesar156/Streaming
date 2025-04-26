using Streaming.DAL.Context;
using Streaming.DAL.Models;
using Streaming.Domain.Entities;
using Streaming.Domain.Interfaces;

namespace Streaming.DAL.Repositories
{
    public class ProfileRepositories : IProfileRepositories
    {
        private readonly StreamingDataContext _dataContext;

        public ProfileRepositories(StreamingDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Insert(Profile request)
        {
            var entity = new PROFILE
            {
                NAME = request.Name,
                AVATAR = request.Avatar,
                ID_USER = request.IdUser
            };

            _dataContext.Add(entity);
            _dataContext.SaveChanges();
        }
    }
}
