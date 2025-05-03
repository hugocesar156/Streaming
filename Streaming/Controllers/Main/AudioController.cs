using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Streaming.Application.Interfaces;
using Streaming.Application.Services;
using Streaming.Shared;
using System.Net;

namespace Streaming.Controllers.Main
{
    [Authorize]
    [ApiController]
    [Route("main/audio")]
    [ApiExplorerSettings(GroupName = "main")]
    public class AudioController : ControllerBase
    {
        private readonly ILogger<AudioController> _logger;
        private readonly IAudioUseCase _audioUseCase;

        public AudioController(ILogger<AudioController> logger, IAudioUseCase audioUseCase)
        {
            _logger = logger;
            _audioUseCase = audioUseCase;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _audioUseCase.Delete(id);
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
