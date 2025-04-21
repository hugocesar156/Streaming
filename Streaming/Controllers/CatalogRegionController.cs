using Microsoft.AspNetCore.Mvc;
using Streaming.Application.Interfaces;
using Streaming.Application.Models.Responses.CatalogRegion;
using Streaming.Shared;
using System.Net;

namespace Streaming.Controllers
{
    public class CatalogRegionController : ControllerBase
    {
        private readonly ICatalogRegionUseCase _catalogRegionUseCase;

        public CatalogRegionController(ICatalogRegionUseCase catalogRegionUseCase)
        {
            _catalogRegionUseCase = catalogRegionUseCase;
        }

        [HttpGet("{pageNumber?}/{pageSize?}")]
        [ProducesResponseType(typeof(CatalogRegionPageResponse), StatusCodes.Status200OK)]
        public IActionResult Get(int pageNumber = 1, int pageSize = 50)
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
                    var response = _catalogRegionUseCase.Get(pageNumber, pageSize, ipAddress);
                    return StatusCode((int)HttpStatusCode.OK, response);
                }

                throw new StreamingException(HttpStatusCode.InternalServerError, ErrorMessages.InternalServerError, ErrorMessages.ClientIPNotFound);
            }
            catch (StreamingException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }
    }
}
