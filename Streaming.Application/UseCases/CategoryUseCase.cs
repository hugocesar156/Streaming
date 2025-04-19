using Streaming.Application.Interfaces;
using Streaming.Application.Models.Requests;
using Streaming.Application.Models.Responses;
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

        public void Delete(int id)
        {
            try
            {
                _categoryRepositories.Delete(id);
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

        public CategoryResponse Get(int id)
        {
            try
            {
                var category = _categoryRepositories.Get(id);
                var response = new CategoryResponse(category.IdCategory, category.Name);

                return response;
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

        public List<CategoryResponse> GetAll()
        {
            try
            {
                var category = _categoryRepositories.GetAll();
                var response = category.Select(x => new CategoryResponse(x.IdCategory, x.Name)).ToList();

                return response;
            }
            catch (Exception ex)
            {
                throw new StreamingException(HttpStatusCode.InternalServerError, ex.Message, ex.InnerException?.Message);
            }
        }

        public void Insert(CategoryInsertRequest request)
        {
            try
            {
                var category = new Category(request.Name);
                _categoryRepositories.Insert(category);
            }
            catch (Exception ex)
            {
                throw new StreamingException(HttpStatusCode.InternalServerError, ex.Message, ex.InnerException?.Message);
            }
        }

        public void Update(CategoryUpdateRequest request)
        {
            try
            {
                var category = new Category(request.Id, request.Name);
                _categoryRepositories.Update(category);
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
