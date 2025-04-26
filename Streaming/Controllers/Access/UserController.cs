using Microsoft.AspNetCore.Mvc;
using Streaming.Shared;

namespace Streaming.Controllers.Access
{
    [ApiController]
    [Route("access/user")]
    [ApiExplorerSettings(GroupName = "access")]
    public class UserController : ControllerBase
    {
        public UserController()
        {
            
        }

        [HttpPost("login")]
        public IActionResult Login()
        {
            try
            {
                return Ok();
            }
            catch (StreamingException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }
    }
}
