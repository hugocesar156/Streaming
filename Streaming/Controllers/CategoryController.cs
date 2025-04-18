using Microsoft.AspNetCore.Mvc;
using Streaming.Application.Interfaces;

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
                return Ok(response);
            }
            catch (Exception) 
            {
                return BadRequest();
            }
        }
    }
}
