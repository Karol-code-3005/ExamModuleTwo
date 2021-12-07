using CCPolandAPI.DAL.Interfaces.IAble;
using CCPolandAPI.Models.DTOS.Material;
using CCPolandAPI.Models.DTOS.Review;
using CCPolandAPI.Models.EntityModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCPolandAPI.DAL.Repositories.Interfaces.IModel
{
    public interface IReviewRepo
    {
        Task<int> AddAsync(ReviewModifyDto reviewModifyDto, int materialId);
        Task Delete(int materialId, int reviewId);
        Task UpdateAsync(int materialId, int reviewId, ReviewModifyDto reviewModifyDto);

        //Task<ReviewDto> GetById(int id);
        //Task<IEnumerable<ReviewDto>> GetAll();
    }
}
