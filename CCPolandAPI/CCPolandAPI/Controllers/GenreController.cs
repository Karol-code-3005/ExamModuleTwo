using AutoMapper;
using CCPolandAPI.DAL.Repositories.Interfaces;
using CCPolandAPI.Models.DTOS.Author;
using CCPolandAPI.Models.DTOS.Genre;
using CCPolandAPI.Models.EntityModels;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCPolandAPI.Controllers
{
    [Route("api/genres")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreRepo _genreRepo;
        private readonly IMapper _mapper;

        public GenreController(IGenreRepo genreRepo, IMapper mapper)
        {
            _genreRepo = genreRepo;
            _mapper = mapper;
        }

        /// <summary>
        /// GET method returns all genres
        /// </summary>
        /// <returns>Returns list of GenreShortDtos</returns>
        /// <response code="200">Returns dtos for all genres in database</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreShortDto>>> GetAllGenres()
        {
            return Ok(await _genreRepo.GetAllAsync());
        }

        /// <summary>
        /// GET method return genres specified by id
        /// </summary>
        /// <param name="genreId"></param>
        /// <returns>Returns specified GenreLongDto</returns>
        /// <response code="200">Returns specifed genre's dto</response>
        [HttpGet]
        [Route("{genreId}")]
        public async Task<ActionResult<GenreLongDto>> GetGenre([FromRoute] int genreId)
        {
            return Ok(await _genreRepo.GetByIdAsync(genreId));
        }

        /// <summary>
        /// POST method add new Genre to database
        /// </summary>
        /// <param name="genreModifyDto"></param>
        /// <returns>Return endpoint to new object</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "name": "New Genre",
        ///        "definition": "Very good very nice"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns endpoint to new Genre</response>
        [HttpPost]
        public async Task<ActionResult> CreateNewGenre([FromBody] GenreModifyDto genreModifyDto)
        {
            int newGenreId = await _genreRepo.AddAsync(genreModifyDto);
            return Created($"/genres/{newGenreId}", null);
        }

        /// <summary>
        /// DELETE method delete specifed Genre from database
        /// </summary>
        /// <param name="genreId"></param>
        /// <returns>Returns 204 NoContent</returns>
        /// <response code="204">Returns no content</response>
        [HttpDelete]
        [Route("{genreId}")]
        public async Task<ActionResult> DeleteGenre(int genreId)
        {
            await _genreRepo.Delete(genreId);
            return NoContent();
        }

        /// <summary>
        /// PATCH method partial update of specifed genre
        /// </summary>
        /// <param name="genreId"></param>
        /// <param name="patchDoc"></param>
        /// <returns>Returns 204 NoContent</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PATCH /Todo
        ///     [
        ///       {
        ///         "op":"replace",
        ///         "path":"/Name",
        ///         "value": "Presentation"
        ///       },
        ///       {
        ///         "op":"replace",
        ///         "path":"/Definition",
        ///         "value": "Pdf presentation in powerpoint"
        ///       }
        ///     ]
        /// </remarks>
        /// <response code="204">Returns no content</response>
        [HttpPatch]
        [Route("{genreId}")]
        public async Task<ActionResult> PartialUpdateGenre([FromRoute] int genreId, [FromBody] JsonPatchDocument<GenreModifyDto> patchDoc)
        {
            Genre genreToUpdate = await _genreRepo.ReadModelAsync(genreId);

            GenreModifyDto genreToPatch = _mapper.Map<GenreModifyDto>(genreToUpdate);

            patchDoc.ApplyTo(genreToPatch, ModelState);
            if (!TryValidateModel(genreToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(genreToPatch, genreToUpdate);
            await _genreRepo.PartialUpdateAsync(genreToUpdate);
            return NoContent();
        }

        /// <summary>
        /// PUT method update existing genre in db
        /// </summary>
        /// <param name="genreId"></param>
        /// <param name="genreModifyDto"></param>
        /// <returns>Returns 204 no content</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /Todo
        ///     {
        ///        "name": "Update Genre",
        ///        "definition": "Very test test test"
        ///     }
        ///
        /// </remarks>
        /// <response code="204">Returns no content</response>
        [HttpPut]
        [Route("{genreId}")]
        public async Task<ActionResult> UpdateGenre([FromRoute] int genreId, [FromBody] GenreModifyDto genreModifyDto)
        {
            await _genreRepo.UpdateAsync(genreId, genreModifyDto);
            return NoContent();
        }
    }
}
