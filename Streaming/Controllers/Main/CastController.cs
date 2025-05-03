using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Streaming.Application.Services;
using Streaming.Domain.Interfaces;
using Streaming.Shared;
using System.Net;

namespace Streaming.Controllers.Main
{
    [Authorize]
    [ApiController]
    [Route("main/cast")]
    [ApiExplorerSettings(GroupName = "main")]
    public class CastController : ControllerBase
    {
        private readonly ILogger<CastController> _logger;
        private readonly ICastRepositories _castRepositories;

        public CastController(ILogger<CastController> logger, ICastRepositories castRepositories)
        {
            _logger = logger;
            _castRepositories = castRepositories;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _castRepositories.Delete(id);
                return StatusCode((int)HttpStatusCode.NoContent);
            }
            catch (StreamingException ex)
            {
                LogServices.WriteFile(_logger, ControllerContext.HttpContext.Request.Path,
                    ex.Error, ex.Description, (int)ex.StatusCode);

                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }
    }
}
