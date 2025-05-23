﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Streaming.Application.Interfaces;
using Streaming.Application.Models.Requests.Film;
using Streaming.Application.Models.Responses.Film;
using Streaming.Application.Services;
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
        private readonly ILogger<FilmController> _logger;
        private readonly IFilmUseCase _filmUseCase;

        public FilmController(ILogger<FilmController> logger, IFilmUseCase filmUseCase)
        {
            _filmUseCase = filmUseCase;
            _logger = logger;
        }

        [HttpPost("addaudio")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddAudio(FilmAudioInsertRequest request)
        {
            try
            {
                await _filmUseCase.AddAudio(request);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (StreamingException ex)
            {
                LogServices.WriteFile(_logger, ControllerContext.HttpContext.Request.Path,
                    ex.Error, ex.Description, (int)ex.StatusCode, JsonConvert.SerializeObject(request));

                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }

        [HttpPost("addcast")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddCast(FilmCastInsertRequest request)
        {
            try
            {
                await _filmUseCase.AddCast(request);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (StreamingException ex)
            {
                LogServices.WriteFile(_logger, ControllerContext.HttpContext.Request.Path,
                    ex.Error, ex.Description, (int)ex.StatusCode, JsonConvert.SerializeObject(request));

                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }

        [HttpPost("addcategories")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddCategories(FilmCategoryRequest request)
        {
            try
            {
                await _filmUseCase.AddCategories(request);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (StreamingException ex)
            {
                LogServices.WriteFile(_logger, ControllerContext.HttpContext.Request.Path,
                    ex.Error, ex.Description, (int)ex.StatusCode, JsonConvert.SerializeObject(request));

                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }

        [HttpPost("addcontents")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddContents(FilmContentRequest request)
        {
            try
            {
                await _filmUseCase.AddContents(request);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (StreamingException ex)
            {
                LogServices.WriteFile(_logger, ControllerContext.HttpContext.Request.Path,
                    ex.Error, ex.Description, (int)ex.StatusCode, JsonConvert.SerializeObject(request));

                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }

        [HttpPost("addincatalog")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddInCatalog(FilmCatalogInsertRequest request)
        {
            try
            {
                await _filmUseCase.AddInCatalog(request);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (StreamingException ex)
            {
                LogServices.WriteFile(_logger, ControllerContext.HttpContext.Request.Path,
                    ex.Error, ex.Description, (int)ex.StatusCode, JsonConvert.SerializeObject(request));

                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }

        [HttpPost("addmedia")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddMedia(FilmMediaInsertRequest request)
        {
            try
            {
                await _filmUseCase.AddMedia(request);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (StreamingException ex)
            {
                LogServices.WriteFile(_logger, ControllerContext.HttpContext.Request.Path,
                    ex.Error, ex.Description, (int)ex.StatusCode, JsonConvert.SerializeObject(request));

                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }

        [HttpPost("addsubtitles")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddSubtitles(FilmSubtitlesInsertRequest request)
        {
            try
            {
                await _filmUseCase.AddSubtitles(request);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (StreamingException ex)
            {
                LogServices.WriteFile(_logger, ControllerContext.HttpContext.Request.Path,
                    ex.Error, ex.Description, (int)ex.StatusCode, JsonConvert.SerializeObject(request));

                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FilmResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var response = await _filmUseCase.Get(id);
                return StatusCode((int)HttpStatusCode.OK, response);
            }
            catch (StreamingException ex)
            {
                LogServices.WriteFile(_logger, ControllerContext.HttpContext.Request.Path,
                    ex.Error, ex.Description, (int)ex.StatusCode);

                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }

        [HttpGet("getincatalog/{id}")]
        [ProducesResponseType(typeof(FilmCatalogResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetInCatalog(int id)
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
                    var response = await _filmUseCase.GetInCatalog(id, ipAddress);
                    return StatusCode((int)HttpStatusCode.OK, response);
                }

                throw new StreamingException(HttpStatusCode.InternalServerError, ErrorMessages.InternalServerError, ErrorMessages.ClientIPNotFound);
            }
            catch (StreamingException ex)
            {
                LogServices.WriteFile(_logger, ControllerContext.HttpContext.Request.Path,
                    ex.Error, ex.Description, (int)ex.StatusCode);

                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Post(FilmInsertRequest request)
        {
            try
            {
                await _filmUseCase.Insert(request);
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
        public async Task<IActionResult> Put(FilmUpdateRequest request)
        {
            try
            {
                await _filmUseCase.Update(request);
                return StatusCode((int)HttpStatusCode.NoContent);
            }
            catch (StreamingException ex)
            {
                LogServices.WriteFile(_logger, ControllerContext.HttpContext.Request.Path,
                    ex.Error, ex.Description, (int)ex.StatusCode, JsonConvert.SerializeObject(request));

                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }

        [HttpPost("removecategories")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> RemoveCategories(FilmCategoryRequest request)
        {
            try
            {
                await _filmUseCase.RemoveCategories(request);
                return StatusCode((int)HttpStatusCode.NoContent);
            }
            catch (StreamingException ex)
            {
                LogServices.WriteFile(_logger, ControllerContext.HttpContext.Request.Path,
                    ex.Error, ex.Description, (int)ex.StatusCode, JsonConvert.SerializeObject(request));

                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }

        [HttpPost("removecontents")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> RemoveContents(FilmContentRequest request)
        {
            try
            {
                await _filmUseCase.RemoveContents(request);
                return StatusCode((int)HttpStatusCode.NoContent);
            }
            catch (StreamingException ex)
            {
                LogServices.WriteFile(_logger, ControllerContext.HttpContext.Request.Path,
                    ex.Error, ex.Description, (int)ex.StatusCode, JsonConvert.SerializeObject(request));

                return StatusCode((int)ex.StatusCode, new { ex.Error, ex.Description });
            }
        }

        [HttpPut("updatecast")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateCast(FilmCastUpdateRequest request)
        {
            try
            {
                await _filmUseCase.UpdateCast(request);
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
