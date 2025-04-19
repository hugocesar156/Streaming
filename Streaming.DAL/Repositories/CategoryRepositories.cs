using Streaming.DAL.Context;
using Streaming.DAL.Models;
using Streaming.Domain.Entities;
using Streaming.Domain.Interfaces;
using Streaming.Shared;
using System.Net;

namespace Streaming.DAL.Repositories
{
    public class CategoryRepositories : ICategoryRepositories
    {
        private readonly StreamingDataContext _dataContext;

        public CategoryRepositories(StreamingDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Delete(int id)
        {
            var entity = _dataContext.CATEGORies.FirstOrDefault(x => x.ID_CATEGORY == id);

            if (entity is null)
            {
                throw new StreamingException(HttpStatusCode.UnprocessableEntity, ErrorMessages.RegisterNotFound, string.Format(ErrorMessages.Category.NotFound, id));
            }

            _dataContext.Remove(entity);
            _dataContext.SaveChanges();
        }

        public Category Get(int id)
        {
            var entity = _dataContext.CATEGORies.FirstOrDefault(x => x.ID_CATEGORY == id);

            if (entity is not null)
            {
                return new Category(entity.ID_CATEGORY, entity.NAME);
            }

            throw new StreamingException(HttpStatusCode.UnprocessableEntity, ErrorMessages.RegisterNotFound, string.Format(ErrorMessages.Category.NotFound, id));
        }

        public List<Category> GetAll()
        {
            var entities = _dataContext.CATEGORies.OrderBy(x => x.NAME).ToList();

            return entities.Select(x => new Category(x.ID_CATEGORY, x.NAME)).ToList();
        }

        public void Insert(Category request)
        {
            var entity = new CATEGORY
            {
                NAME = request.Name
            };

            _dataContext.Add(entity);
            _dataContext.SaveChanges();
        }

        public void Update(Category request)
        {
            var entity = _dataContext.CATEGORies.FirstOrDefault(x => x.ID_CATEGORY == request.IdCategory);

            if (entity is null)
            {
                throw new StreamingException(HttpStatusCode.UnprocessableEntity, ErrorMessages.RegisterNotFound, string.Format(ErrorMessages.Category.NotFound, request.IdCategory));
            }

            entity.NAME = request.Name;

            _dataContext.Update(entity);
            _dataContext.SaveChanges();
        }
    }
}
