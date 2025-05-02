using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Streaming.Application.Interfaces;
using Streaming.Application.Models.Requests.Series;
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
        private readonly ISeriesUseCase _seriesUseCase;

        public SeriesController(ISeriesUseCase seriesUseCase)
        {
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
                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }
    }
}
