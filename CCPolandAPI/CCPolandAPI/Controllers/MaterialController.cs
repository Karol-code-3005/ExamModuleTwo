using CCPolandAPI.DAL.Repositories.Interfaces;
using CCPolandAPI.Models.DTOS.Material;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCPolandAPI.Controllers
{
    [Route("api/materials")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialRepo _materialRepo;

        public MaterialController(IMaterialRepo materialRepo)
        {
            _materialRepo = materialRepo;
        }

        /// <summary>
        /// GET method returns all materials
        /// </summary>
        /// <returns>Returns list of MaterialShortDto</returns>
        /// <response code="200">Returns dtos for all materials in database</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaterialShortDto>>> GetAllMaterials()
        {
            return Ok(await _materialRepo.GetAllAsync());
        }

        /// <summary>
        /// GET method return material specified by id
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns>Returns specified MaterialLongDto</returns>
        /// <response code="200">Returns specifed material's dto</response>
        [HttpGet]
        [Route("{materialId}")]
        public async Task<ActionResult<MaterialLongDto>> GetMaterial([FromRoute] int materialId)
        {
            return Ok(await _materialRepo.GetByIdAsync(materialId));
        }

        /// <summary>
        /// POST method add new Material to database
        /// </summary>
        /// <param name="materialModifyDto"></param>
        /// <returns>Return endpoint to new object</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "title": "New Material",
        ///        "materialDescription": "Very good very nice material",
        ///        "location": "www.supernewextramaterial.com/material/good-material"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns endpoint to new Material</response>
        [HttpPost]
        public async Task<ActionResult> CreateNewMaterial([FromBody] MaterialModifyDto materialModifyDto)
        {
            int newMaterialId = await _materialRepo.AddAsync(materialModifyDto);
            return Created($"/materials/{newMaterialId}", null);
        }

        /// <summary>
        /// DELETE method delete specifed Material from database
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns>Returns 204 NoContent</returns>
        /// <response code="204">Returns no content</response>
        [HttpDelete]
        [Route("{materialId}")]
        public async Task<ActionResult> DeleteMaterial([FromRoute] int materialId)
        {
            await _materialRepo.Delete(materialId);
            return NoContent();
        }

        /// <summary>
        /// PUT method update existing material in db
        /// </summary>
        /// <param name="materialId"></param>
        /// <param name="materialModifyDto"></param>
        /// <returns>Returns 200 Okt</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /Todo
        ///     {
        ///        "title": "Put Material",
        ///        "materialDescription": "Very good very nice material update test",
        ///        "location": "www.supernewextramaterial.com/material/good-material/update"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns Ok</response>
        [HttpPut]
        [Route("{materialId}")]
        public async Task<ActionResult> UpdateMaterial([FromRoute] int materialId,[FromBody] MaterialModifyDto materialModifyDto)
        {
            await _materialRepo.UpdateAsync(materialId, materialModifyDto);
            return Ok();
        }

    }
}
