using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Streaming.Application.Interfaces;
using Streaming.Application.Models.Requests.User;
using Streaming.Application.Models.Responses.User;
using Streaming.Application.Services;
using Streaming.Shared;
using System.Net;

namespace Streaming.Controllers.Access
{
    [ApiController]
    [Route("access/user")]
    [ApiExplorerSettings(GroupName = "access")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserUseCase _userUseCase;

        public UserController(ILogger<UserController> logger, IUserUseCase userUseCase)
        {
            _logger = logger;
            _userUseCase = userUseCase;
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Login(UserRequest request)
        {
            try
            {
                var response = await _userUseCase.Login(request);
                return StatusCode((int)HttpStatusCode.OK, response);
            }
            catch (StreamingException ex)
            {
                LogServices.WriteFile(_logger, ControllerContext.HttpContext.Request.Path, 
                    ex.Error, ex.Description, (int)ex.StatusCode, JsonConvert.SerializeObject(request));

                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }

        [HttpPost("signup")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> SignUp(UserRequest request)
        {
            try
            {
                await _userUseCase.SignUp(request);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (StreamingException ex)
            {
                LogServices.WriteFile(_logger, ControllerContext.HttpContext.Request.Path,
                   ex.Error, ex.Description, (int)ex.StatusCode, JsonConvert.SerializeObject(request));

                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }
    }
}
