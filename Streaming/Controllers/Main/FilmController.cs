using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Streaming.Application.Interfaces;
using Streaming.Application.Models.Requests.Film;
using Streaming.Application.Models.Responses.Film;
using Streaming.Application.UseCases;
using Streaming.Shared;
using System.Net;

namespace Streaming.Controllers.Main
{
    [Authorize]
    [ApiController]
    [Route("main/film")]
    [ApiExplorerSettings(GroupName = "main")]
    public class FilmController : ControllerBase
    {
        private readonly IFilmUseCase _filmUseCase;

        public FilmController(IFilmUseCase filmUseCase)
        {
            _filmUseCase = filmUseCase;
        }

        [HttpPost("addaudio")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AddAudio(FilmAudioInsertRequest request)
        {
            try
            {
                _filmUseCase.AddAudio(request);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (StreamingException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }

        [HttpPost("addcast")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AddCast(FilmCastInsertRequest request)
        {
            try
            {
                _filmUseCase.AddCast(request);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (StreamingException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }

        [HttpPost("addcategories")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AddCategories(FilmCategoryRequest request)
        {
            try
            {
                _filmUseCase.AddCategories(request);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (StreamingException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }

        [HttpPost("addcontents")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AddContents(FilmContentRequest request)
        {
            try
            {
                _filmUseCase.AddContents(request);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (StreamingException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }

        [HttpPost("addincatalog")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AddInCatalog(FilmCatalogInsertRequest request)
        {
            try
            {
                _filmUseCase.AddInCatalog(request);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (StreamingException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }

        [HttpPost("addmedia")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AddMedia(FilmMediaInsertRequest request)
        {
            try
            {
                _filmUseCase.AddMedia(request);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (StreamingException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }

        [HttpPost("addsubtitles")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AddSubtitles(FilmSubtitlesInsertRequest request)
        {
            try
            {
                _filmUseCase.AddSubtitles(request);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (StreamingException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FilmResponse), StatusCodes.Status200OK)]
        public IActionResult Get(int id)
        {
            try
            {
                var response = _filmUseCase.Get(id);
                return StatusCode((int)HttpStatusCode.OK, response);
            }
            catch (StreamingException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }

        [HttpGet("getincatalog/{id}")]
        [ProducesResponseType(typeof(FilmResponse), StatusCodes.Status200OK)]
        public IActionResult GetInCatalog(int id)
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
                    var response = _filmUseCase.GetInCatalog(id, ipAddress);
                    return StatusCode((int)HttpStatusCode.OK, response);
                }

                throw new StreamingException(HttpStatusCode.InternalServerError, ErrorMessages.InternalServerError, ErrorMessages.ClientIPNotFound);
            }
            catch (StreamingException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post(FilmInsertRequest request)
        {
            try
            {
                _filmUseCase.Insert(request);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (StreamingException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Put(FilmUpdateRequest request)
        {
            try
            {
                _filmUseCase.Update(request);
                return StatusCode((int)HttpStatusCode.NoContent);
            }
            catch (StreamingException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }

        [HttpPost("removecategories")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult RemoveCategories(FilmCategoryRequest request)
        {
            try
            {
                _filmUseCase.RemoveCategories(request);
                return StatusCode((int)HttpStatusCode.NoContent);
            }
            catch (StreamingException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }

        [HttpPost("removecontents")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult RemoveContents(FilmContentRequest request)
        {
            try
            {
                _filmUseCase.RemoveContents(request);
                return StatusCode((int)HttpStatusCode.NoContent);
            }
            catch (StreamingException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }

        [HttpPut("updatecast")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult UpdateCast(FilmCastUpdateRequest request)
        {
            try
            {
                _filmUseCase.UpdateCast(request);
                return StatusCode((int)HttpStatusCode.NoContent);
            }
            catch (StreamingException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }
    }
}
