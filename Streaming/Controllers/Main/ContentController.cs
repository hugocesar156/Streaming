using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Streaming.Application.Interfaces;
using Streaming.Application.Models.Requests.Content;
using Streaming.Application.Models.Responses.Contents;
using Streaming.Shared;
using System.Net;

namespace Streaming.Controllers.Main
{
    [Authorize]
    [ApiController]
    [Route("main/content")]
    [ApiExplorerSettings(GroupName = "main")]
    public class ContentController : ControllerBase
    {
        private readonly IContentUseCase _contentUseCase;

        public ContentController(IContentUseCase contentUseCase)
        {
            _contentUseCase = contentUseCase;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _contentUseCase.Delete(id);
                return StatusCode((int)HttpStatusCode.NoContent);
            }
            catch (StreamingException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ContentResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var response = await _contentUseCase.Get(id);
                return StatusCode((int)HttpStatusCode.OK, response);
            }
            catch (StreamingException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ContentResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _contentUseCase.GetAll();
                return StatusCode((int)HttpStatusCode.OK, response);
            }
            catch (StreamingException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Post(ContentInsertRequest request)
        {
            try
            {
                await _contentUseCase.Insert(request);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (StreamingException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Put(ContentUpdateRequest request)
        {
            try
            {
                await _contentUseCase.Update(request);
                return StatusCode((int)HttpStatusCode.NoContent);
            }
            catch (StreamingException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }
    }
}
