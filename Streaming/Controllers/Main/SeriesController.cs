using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Streaming.Application.Interfaces;
using Streaming.Application.Models.Requests.Series;
using Streaming.Application.Services;
using Streaming.Shared;
using System.Net;

namespace Streaming.Controllers.Main
{
    [Authorize]
    [ApiController]
    [Route("main/series")]
    [ApiExplorerSettings(GroupName = "main")]
    public class SeriesController : ControllerBase
    {
        private readonly ILogger<SeriesController> _logger;
        private readonly ISeriesUseCase _seriesUseCase;

        public SeriesController(ILogger<SeriesController> logger, ISeriesUseCase seriesUseCase)
        {
            _logger = logger;
            _seriesUseCase = seriesUseCase;
        }

        [HttpPost("addincatalog")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddInCatalog(SeriesCatalogInsertRequest request)
        {
            try
            {
                await _seriesUseCase.AddInCatalog(request);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (StreamingException ex)
            {
                LogServices.WriteFile(_logger, ControllerContext.HttpContext.Request.Path,
                    ex.Error, ex.Description, (int)ex.StatusCode, JsonConvert.SerializeObject(request));

                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Post(SeriesInsertRequest request)
        {
            try
            {
                await _seriesUseCase.Insert(request);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (StreamingException ex)
            {
                LogServices.WriteFile(_logger, ControllerContext.HttpContext.Request.Path,
                    ex.Error, ex.Description, (int)ex.StatusCode, JsonConvert.SerializeObject(request));

                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Put(SeriesUpdateRequest request)
        {
            try
            {
                await _seriesUseCase.Update(request);
                return StatusCode((int)HttpStatusCode.NoContent);
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
