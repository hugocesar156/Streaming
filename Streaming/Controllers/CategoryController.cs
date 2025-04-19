using Microsoft.AspNetCore.Mvc;
using Streaming.Application.Interfaces;
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
    }
}
