using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Streaming.Application.Interfaces;
using Streaming.Application.Models.Requests.SeriesEpisode;
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
        private readonly ISeriesEpisodeUseCase _seriesEpisodeUseCase; 

        public SeriesEpisodeController(ISeriesEpisodeUseCase seriesEpisodeUseCase)
        {
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
                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }
    }
}
