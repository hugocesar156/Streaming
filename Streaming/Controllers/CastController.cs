using Microsoft.AspNetCore.Mvc;
using Streaming.Domain.Interfaces;
using Streaming.Shared;
using System.Net;

namespace Streaming.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CastController : ControllerBase
    {
        private readonly ICastRepositories _castRepositories;

        public CastController(ICastRepositories castRepositories)
        {
            _castRepositories = castRepositories;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(int id)
        {
            try
            {
                _castRepositories.Delete(id);
                return StatusCode((int)HttpStatusCode.NoContent);
            }
            catch (StreamingException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }
    }
}
