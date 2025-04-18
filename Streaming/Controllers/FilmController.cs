﻿using Microsoft.AspNetCore.Mvc;
using Streaming.Application.Interfaces;
using Streaming.Application.Models.Requests;
using Streaming.Application.Models.Responses;
using Streaming.Shared;
using System.Net;

namespace Streaming.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmController : ControllerBase
    {
        private readonly IFilmUseCase _filmUseCase;

        public FilmController(IFilmUseCase filmUseCase)
        {
            _filmUseCase = filmUseCase;
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
        public IActionResult Removecategories(FilmCategoryRequest request)
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
    }
}
