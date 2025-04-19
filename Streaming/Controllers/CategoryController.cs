using Microsoft.AspNetCore.Mvc;
using Streaming.Application.Interfaces;
using Streaming.Application.Models.Requests;
using Streaming.Application.Models.Responses;
using Streaming.Shared;
using System.Net;

namespace Streaming.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryUseCase _categoryUseCase;

        public CategoryController(ILogger<CategoryController> logger, ICategoryUseCase categoryUseCase)
        {
            _logger = logger;
            _categoryUseCase = categoryUseCase;
        }

        [HttpGet]
        [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            try
            {
                var response = _categoryUseCase.Get();
                return StatusCode((int)HttpStatusCode.OK, response);
            }
            catch (StreamingException ex) 
            {
                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }

        [HttpPost]
        public IActionResult Post(CategoryRequest request)
        {
            try
            {
                _categoryUseCase.Post(request);
                return StatusCode((int)HttpStatusCode.OK);
            }
            catch (StreamingException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }
    }
}
