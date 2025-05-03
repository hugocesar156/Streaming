using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Streaming.Application.Interfaces;
using Streaming.Application.Models.Requests.SeriesEpisode;
using Streaming.Application.Services;
using Streaming.Shared;
using System.Net;

namespace Streaming.Controllers.Main
{
    [Authorize]
    [ApiController]
    [Route("main/seriesepisode")]
    [ApiExplorerSettings(GroupName = "main")]
    public class SeriesEpisodeController : ControllerBase
    {
        private readonly ILogger<SeriesEpisodeController> _logger;
        private readonly ISeriesEpisodeUseCase _seriesEpisodeUseCase; 

        public SeriesEpisodeController(ILogger<SeriesEpisodeController> logger, ISeriesEpisodeUseCase seriesEpisodeUseCase)
        {
            _logger = logger;
            _seriesEpisodeUseCase = seriesEpisodeUseCase;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Post(SeriesEpisodeInsertRequest request)
        {
            try
            {
                await _seriesEpisodeUseCase.Insert(request);
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
