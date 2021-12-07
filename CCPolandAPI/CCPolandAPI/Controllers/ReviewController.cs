using CCPolandAPI.DAL.Repositories.Interfaces.IModel;
using CCPolandAPI.Models.DTOS.Review;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CCPolandAPI.Controllers
{
    [Route("api/materials/{materialId}/reviews")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepo _reviewRepo;

        public ReviewController(IReviewRepo reviewRepo)
        {
            _reviewRepo = reviewRepo;
        }

        /// <summary>
        /// POST method add new Review to database
        /// </summary>
        /// <param name="materialId"></param>
        /// <param name="reviewModifyDto"></param>
        /// <returns>Return endpoint to new object</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "text": "Post Review text",
        ///        "rating": 7
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns endpoint to new review</response>
        [HttpPost]
        public async Task<ActionResult> CreateNewReview([FromBody] ReviewModifyDto reviewModifyDto, [FromRoute] int materialId)
        {
            int newReviewId = await _reviewRepo.AddAsync(reviewModifyDto, materialId);
            return Created($"/reviews/{newReviewId}", null);
        }

        /// <summary>
        /// DELETE method delete specifed review for specifed material from database
        /// </summary>
        /// <param name="materialId"></param>
        /// <param name="reviewId"></param>
        /// <returns>Returns 204 NoContent</returns>
        /// <response code="204">Returns no content</response>
        [HttpDelete]
        [Route("{reviewId}")]
        public async Task<ActionResult> DeleteReview([FromRoute] int materialId, [FromRoute] int reviewId)
        {
            await _reviewRepo.Delete(materialId, reviewId);
            return NoContent();
        }

        /// <summary>
        /// PUT method update existing review for specifed material
        /// </summary>
        /// <param name="materialId"></param>
        /// <param name="reviewId"></param>
        /// <param name="reviewModifyDto"></param>
        /// <returns>Returns 200 Okt</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /Todo
        ///     {
        ///        "text": "Update Review text",
        ///        "rating": 5
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns Ok</response>
        [HttpPut]
        [Route("{reviewId}")]
        public async Task<ActionResult> UpdateReview([FromRoute] int materialId, [FromRoute] int reviewId, [FromBody] ReviewModifyDto reviewModifyDto)
        {
            await _reviewRepo.UpdateAsync(materialId, reviewId, reviewModifyDto);
            return Ok();
        }

    }
}
