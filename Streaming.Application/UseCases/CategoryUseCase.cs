using Streaming.Application.Interfaces;
using Streaming.Application.Models.Responses;
using Streaming.Domain.Interfaces;

namespace Streaming.Application.UseCases
{
    public class CategoryUseCase : ICategoryUseCase
    {
        private readonly ICategoryRepositories _categoryRepositories;

        public CategoryUseCase(ICategoryRepositories categoryRepositories)
        {
            _categoryRepositories = categoryRepositories;
        }

        public List<CategoryResponse> Get()
        {
            try
            {
                var category = _categoryRepositories.Get();
                var response = category.Select(x => new CategoryResponse(x.IdCategory, x.Name)).ToList();

                return response;
            }
            catch (Exception) 
            {
                throw;
            }
        }
    }
}
