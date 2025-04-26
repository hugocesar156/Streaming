using Microsoft.AspNetCore.Mvc;
using Streaming.Application.Interfaces;
using Streaming.Application.Models.Requests.User;
using Streaming.Application.Models.Responses.User;
using Streaming.Shared;
using System.Net;

namespace Streaming.Controllers.Access
{
    [ApiController]
    [Route("access/user")]
    [ApiExplorerSettings(GroupName = "access")]
    public class UserController : ControllerBase
    {
        private readonly IUserUseCase _userUseCase;

        public UserController(IUserUseCase userUseCase)
        {
            _userUseCase = userUseCase;
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        public IActionResult Login(UserRequest request)
        {
            try
            {
                var response = _userUseCase.Login(request);
                return StatusCode((int)HttpStatusCode.OK, response);
            }
            catch (StreamingException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }

        [HttpPost("signup")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult SignUp(UserRequest request)
        {
            try
            {
                _userUseCase.SignUp(request);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (StreamingException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }
    }
}
