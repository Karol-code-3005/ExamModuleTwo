using CCPolandAPI.Models.DTOS.Review;
using System.Threading.Tasks;

namespace CCPolandAPI.DAL.Repositories.Interfaces.IModel
{
    public interface IReviewRepo
    {
        Task<int> AddAsync(ReviewModifyDto reviewModifyDto, int materialId);
        Task Delete(int materialId, int reviewId);
        Task UpdateAsync(int materialId, int reviewId, ReviewModifyDto reviewModifyDto);
    }
}
