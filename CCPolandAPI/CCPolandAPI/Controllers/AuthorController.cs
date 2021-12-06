using AutoMapper;
using CCPolandAPI.DAL.Repositories.Interfaces;
using CCPolandAPI.Models.DTOS.Author;
using CCPolandAPI.Models.EntityModels;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCPolandAPI.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepo _authorRepo;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorRepo authorRepo, IMapper mapper)
        {
            _authorRepo = authorRepo;
            _mapper = mapper;
        }

        /// <summary>
        /// GET method returns all authors
        /// </summary>
        /// <returns>Returns list of AuthorsShortDtos</returns>
        /// <response code="200">Returns dtos for all authors in databse</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorShortDto>>> GetAllAuthors()
        {
            return Ok(await _authorRepo.GetAllAsync());
        }

        /// <summary>
        /// GET method return authors specified by id
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns>Returns specified AuthorLongDto</returns>
        /// <response code="200">Returns specifed author's dto</response>
        [HttpGet]
        [Route("{authorId}")]
        public async Task<ActionResult<AuthorLongDto>> GetAuthor([FromRoute] int authorId)
        {
            return Ok(await _authorRepo.GetByIdAsync(authorId));
        }

        /// <summary>
        /// POST method add new Author to database
        /// </summary>
        /// <param name="authorModifyDto"></param>
        /// <returns>Return endpoint to new object</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "name": "New Author",
        ///        "authorDescription": "Very good very nice"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns endpoint to new Author</response>
        [HttpPost]
        public async Task<ActionResult> CreateNewAuthor([FromBody] AuthorModifyDto authorModifyDto)
        {
            int newDirectorId = await _authorRepo.AddAsync(authorModifyDto);
            return Created($"/authors/{newDirectorId}", null);
        }

        /// <summary>
        /// DELETE method delete specifed Author from database
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns>Returns 204 NoContent</returns>
        /// <response code="204">Returns no content</response>
        [HttpDelete]
        [Route("{authorId}")]
        public async Task<ActionResult> DeleteAuthor(int authorId)
        {
            await _authorRepo.Delete(authorId);
            return NoContent();
        }

        /// <summary>
        /// PATCH method partial update of specifed author
        /// </summary>
        /// <param name="authorId"></param>
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
        ///         "value": "Wild Hog"
        ///       },
        ///       {
        ///         "op":"replace",
        ///         "path":"/AuthorDescription",
        ///         "value": "Young, wild, inteligent and free"
        ///       }
        ///     ]
        /// </remarks>
        /// <response code="204">Returns no content</response>
        [HttpPatch]
        [Route("{authorId}")]
        public async Task<ActionResult> PartialUpdateAuthor([FromRoute] int authorId, [FromBody] JsonPatchDocument<AuthorModifyDto> patchDoc)
        {
            Author authorToUpdate = await _authorRepo.ReadModelAsync(authorId);

            AuthorModifyDto authorToPatch = _mapper.Map<AuthorModifyDto>(authorToUpdate);

            patchDoc.ApplyTo(authorToPatch, ModelState);
            if(!TryValidateModel(authorToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(authorToPatch, authorToUpdate);
            await _authorRepo.PartialUpdateAsync(authorToUpdate);
            return NoContent();
        }

        /// <summary>
        /// PUT method update existing author in db
        /// </summary>
        /// <param name="authorId"></param>
        /// <param name="authorModifyDto"></param>
        /// <returns>Returns 204 no content</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /Todo
        ///     {
        ///        "name": "Update Author"
        ///        "authorDescription": "Very good very nice"
        ///     }
        ///
        /// </remarks>
        /// <response code="204">Returns no content</response>
        [HttpPut]
        [Route("{authorId}")]
        public async Task<ActionResult> UpdateAuthor([FromRoute] int authorId, [FromBody] AuthorModifyDto authorModifyDto)
        {
            await _authorRepo.UpdateAsync(authorId, authorModifyDto);
            return NoContent();
        }


    }
}
