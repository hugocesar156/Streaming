using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Streaming.Application.Interfaces;
using Streaming.Application.Models.Services;
using Streaming.Application.Services;
using Streaming.Shared;
using System.Net;

namespace Streaming.Controllers.Audit
{
    [Authorize]
    [ApiController]
    [Route("audit/log")]
    [ApiExplorerSettings(GroupName = "audit")]
    public class LogController : ControllerBase
    {
        private readonly ILogger<LogController> _logger;
        private readonly ILogUseCase _logUseCase;

        public LogController(ILogger<LogController> logger, ILogUseCase logUseCase)
        {
            _logger = logger;
            _logUseCase = logUseCase;
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(DateTime cutOffDate)
        {
            try
            {
                _logUseCase.Delete(cutOffDate);
                return StatusCode((int)HttpStatusCode.NoContent);
            }
            catch (StreamingException ex)
            {
                LogServices.WriteFile(_logger, ControllerContext.HttpContext.Request.Path,
                    ex.Error, ex.Description, (int)ex.StatusCode);

                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Log>), StatusCodes.Status200OK)]
        public IActionResult Get(DateTime dateStart, DateTime dateEnd)
        {
            try
            {
                var response = _logUseCase.GetByInterval(dateStart, dateEnd);
                return StatusCode((int)HttpStatusCode.OK, response);
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
