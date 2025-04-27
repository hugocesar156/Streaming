using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Streaming.Application.Interfaces;
using Streaming.Application.Models.Requests.Profile;
using Streaming.Shared;
using System.Net;
using System.Security.Claims;

namespace Streaming.Controllers.Access
{
    [Authorize]
    [ApiController]
    [Route("access/profile")]
    [ApiExplorerSettings(GroupName = "access")]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileUseCase _profileUseCase;

        public ProfileController(IProfileUseCase profileUseCase)
        {
            _profileUseCase = profileUseCase;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Put(int id)
        {
            try
            {
                _profileUseCase.Delete(id);
                return StatusCode((int)HttpStatusCode.NoContent);
            }
            catch (StreamingException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public IActionResult Post(ProfileIsertRequest request)
        {
            try
            {
                int idUser = int.Parse(HttpContext.User.FindFirstValue(ClaimTypes.PrimarySid) ?? "0");

                _profileUseCase.Insert(request, idUser);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (StreamingException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Put(ProfileUpdateRequest request)
        {
            try
            {
                _profileUseCase.Update(request);
                return StatusCode((int)HttpStatusCode.NoContent);
            }
            catch (StreamingException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }
    }
}
