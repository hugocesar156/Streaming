using Microsoft.AspNetCore.Mvc;
using Streaming.Application.Interfaces;
using Streaming.Application.Models.Requests.SeriesEpisode;
using Streaming.Shared;
using System.Net;

namespace Streaming.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SeriesEpisodeController : ControllerBase
    {
        private readonly ISeriesEpisodeUseCase _seriesEpisodeUseCase; 

        public SeriesEpisodeController(ISeriesEpisodeUseCase seriesEpisodeUseCase)
        {
            _seriesEpisodeUseCase = seriesEpisodeUseCase;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post(SeriesEpisodeInsertRequest request)
        {
            try
            {
                _seriesEpisodeUseCase.Insert(request);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (StreamingException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }
    }
}
