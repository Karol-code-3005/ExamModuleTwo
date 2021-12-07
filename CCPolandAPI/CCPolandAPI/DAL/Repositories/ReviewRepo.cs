using AutoMapper;
using CCPolandAPI.DAL.Data;
using CCPolandAPI.DAL.Repositories.Interfaces.IModel;
using CCPolandAPI.Models.DTOS.Review;
using CCPolandAPI.Models.EntityModels;
using CCPolandAPI.Properties;
using CCPolandAPI.Services.ErrorHandling.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace CCPolandAPI.DAL.Repositories
{
    public class ReviewRepo : IReviewRepo
    {
        private readonly CCPolandDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<ReviewRepo> _logger;

        public ReviewRepo(CCPolandDbContext context, IMapper mapper, ILogger<ReviewRepo> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }
   
        public async Task<int> AddAsync(ReviewModifyDto reviewModifyDto, int materialId)
        {
            _logger.LogInformation(Resource.ResourceManager.GetString("creatingReview"));
            Review reviewModel = _mapper.Map<Review>(reviewModifyDto);
            reviewModel.MaterialId = materialId;
            await _context.Reviews.AddAsync(reviewModel);
            await _context.SaveChangesAsync();
            _logger.LogInformation(Resource.ResourceManager.GetString("succeeded"));
            return reviewModel.Id;
        }

        public async Task Delete(int materialId, int reviewId)
        {
            _logger.LogInformation(Resource.ResourceManager.GetString("deletingReview"));
            Review reviewModel = await _context.Reviews.Where(x =>x.MaterialId == materialId).SingleOrDefaultAsync(x => x.Id == reviewId);
            if (reviewModel is null)
            {
                throw new NotFoundException(Resource.ResourceManager.GetString("reviewNotFound"));
            }
            _context.Reviews.Remove(reviewModel);
            await _context.SaveChangesAsync();
            _logger.LogInformation(Resource.ResourceManager.GetString("succeeded"));
        }

        public async Task UpdateAsync(int materialId, int reviewId, ReviewModifyDto reviewModifyDto)
        {
            _logger.LogInformation(Resource.ResourceManager.GetString("updatingReview"));
            Review reviewToUpdate = await _context.Reviews.SingleOrDefaultAsync(x => x.Id == reviewId);
            if (reviewToUpdate is null)
            {
                throw new NotFoundException(Resource.ResourceManager.GetString("reviewNotFound"));
            }
            _mapper.Map(reviewModifyDto, reviewToUpdate);
            reviewToUpdate.MaterialId = materialId;
            //_context.Update(genreToUpdate);
            await _context.SaveChangesAsync();
            _logger.LogInformation(Resource.ResourceManager.GetString("succeeded"));
        }
    }
}
