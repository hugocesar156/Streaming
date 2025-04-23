using Microsoft.AspNetCore.Mvc;
using Streaming.Application.Interfaces;
using Streaming.Application.Models.Requests.Series;
using Streaming.Shared;
using System.Net;

namespace Streaming.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SeriesController : ControllerBase
    {
        private readonly ISeriesUseCase _seriesUseCase;

        public SeriesController(ISeriesUseCase seriesUseCase)
        {
            _seriesUseCase = seriesUseCase;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post(SeriesInsertRequest request)
        {
            try
            {
                _seriesUseCase.Insert(request);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (StreamingException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Put(SeriesUpdateRequest request)
        {
            try
            {
                _seriesUseCase.Update(request);
                return StatusCode((int)HttpStatusCode.NoContent);
            }
            catch (StreamingException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }
    }
}
