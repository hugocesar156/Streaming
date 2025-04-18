using Streaming.DAL.Context;
using Streaming.Domain.Entities;
using Streaming.Domain.Interfaces;

namespace Streaming.DAL.Repositories
{
    public class CategoryRepositories : ICategoryRepositories
    {
        private readonly StreamingDataContext _dataContext;

        public CategoryRepositories(StreamingDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Category> Get()
        {
            var entities = _dataContext.CATEGORies.OrderBy(x => x.NAME).ToList();

            return entities.Select(x => new Category(x.ID_CATEGORY, x.NAME)).ToList();
        }
    }
}
