using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Streaming.Application.Interfaces;
using Streaming.Application.Models.Requests.Category;
using Streaming.Application.Models.Responses.Category;
using Streaming.Shared;
using System.Net;

namespace Streaming.Controllers.Main
{
    [Authorize]
    [ApiController]
    [Route("main/category")]
    [ApiExplorerSettings(GroupName = "main")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryUseCase _categoryUseCase;

        public CategoryController(ICategoryUseCase categoryUseCase)
        {
            _categoryUseCase = categoryUseCase;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _categoryUseCase.Delete(id);
                return StatusCode((int)HttpStatusCode.NoContent);
            }
            catch (StreamingException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var response = await _categoryUseCase.Get(id);
                return StatusCode((int)HttpStatusCode.OK, response);
            }
            catch (StreamingException ex) 
            {
                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CategoryResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _categoryUseCase.GetAll();
                return StatusCode((int)HttpStatusCode.OK, response);
            }
            catch (StreamingException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Post(CategoryInsertRequest request)
        {
            try
            {
                await _categoryUseCase.Insert(request);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (StreamingException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Put(CategoryUpdateRequest request)
        {
            try
            {
                await _categoryUseCase.Update(request);
                return StatusCode((int)HttpStatusCode.NoContent);
            }
            catch (StreamingException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }
    }
}
