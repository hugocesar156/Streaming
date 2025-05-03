using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Streaming.Application.Interfaces;
using Streaming.Application.Models.Responses.CatalogRegion;
using Streaming.Application.Services;
using Streaming.Shared;
using System.Net;

namespace Streaming.Controllers.Main
{
    [Authorize]
    [ApiController]
    [Route("main/catalogregion")]
    [ApiExplorerSettings(GroupName = "main")]
    public class CatalogRegionController : ControllerBase
    {
        private readonly ILogger<CatalogRegionController> _logger;
        private readonly ICatalogRegionUseCase _catalogRegionUseCase;

        public CatalogRegionController(ILogger<CatalogRegionController> logger, ICatalogRegionUseCase catalogRegionUseCase)
        {
            _logger = logger;
            _catalogRegionUseCase = catalogRegionUseCase;
        }

        [HttpGet("{idProfile}")]
        [ProducesResponseType(typeof(CatalogRegionPageResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int idProfile, int pageNumber = 1, int pageSize = 50, int idCategory = 0, string search = "")
        {
            try
            {
                var forwardedIp = Request.Headers["X-Forwarded-For"].FirstOrDefault();

                var remoteIpAddress = HttpContext.Connection.RemoteIpAddress;

                if (remoteIpAddress is not null && remoteIpAddress.IsIPv4MappedToIPv6)
                    remoteIpAddress = remoteIpAddress.MapToIPv4();

                string? ipAddress = !string.IsNullOrEmpty(forwardedIp) ? forwardedIp : remoteIpAddress?.ToString();

                if (!string.IsNullOrEmpty(ipAddress))
                {
                    var response = await _catalogRegionUseCase.Get(idProfile, pageNumber > 0 ? pageNumber : 1, pageSize > 0 ? pageSize : 50, idCategory, search, ipAddress);
                    return StatusCode((int)HttpStatusCode.OK, response);
                }

                throw new StreamingException(HttpStatusCode.InternalServerError, ErrorMessages.InternalServerError, ErrorMessages.ClientIPNotFound);
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
