using Streaming.Application.Interfaces;
using Streaming.Application.Models.Requests.Category;
using Streaming.Application.Models.Responses.Category;
using Streaming.Domain.Entities;
using Streaming.Domain.Interfaces;
using Streaming.Shared;
using System.Net;

namespace Streaming.Application.UseCases
{
    public class CategoryUseCase : ICategoryUseCase
    {
        private readonly ICategoryRepositories _categoryRepositories;

        public CategoryUseCase(ICategoryRepositories categoryRepositories)
        {
            _categoryRepositories = categoryRepositories;
        }

        public async Task Delete(int id)
        {
            try
            {
                await _categoryRepositories.Delete(id);
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

        public async Task<CategoryResponse> Get(int id)
        {
            try
            {
                var category = await _categoryRepositories.Get(id);
                return new CategoryResponse(category.IdCategory, category.Name);
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

        public async Task<List<CategoryResponse>> GetAll()
        {
            try
            {
                var categories = await _categoryRepositories.GetAll();
                return categories.Select(x => new CategoryResponse(x.IdCategory, x.Name)).ToList();
            }
            catch (Exception ex)
            {
                throw new StreamingException(HttpStatusCode.InternalServerError, ex.Message, ex.InnerException?.Message);
            }
        }

        public async Task Insert(CategoryInsertRequest request)
        {
            try
            {
                var category = new Category(request.Name);
                await _categoryRepositories.Insert(category);
            }
            catch (Exception ex)
            {
                throw new StreamingException(HttpStatusCode.InternalServerError, ex.Message, ex.InnerException?.Message);
            }
        }

        public async Task Update(CategoryUpdateRequest request)
        {
            try
            {
                var category = new Category(request.Id, request.Name);
                await _categoryRepositories.Update(category);
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
