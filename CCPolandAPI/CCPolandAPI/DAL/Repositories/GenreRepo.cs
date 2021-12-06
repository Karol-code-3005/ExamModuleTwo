using AutoMapper;
using CCPolandAPI.DAL.Data;
using CCPolandAPI.DAL.Repositories.Interfaces;
using CCPolandAPI.Models.DTOS.Genre;
using CCPolandAPI.Models.EntityModels;
using CCPolandAPI.Properties;
using CCPolandAPI.Services.ErrorHandling.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCPolandAPI.DAL.Repositories
{
    public class GenreRepo : IGenreRepo
    {
        private readonly CCPolandDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GenreRepo> _logger;

        public GenreRepo(CCPolandDbContext context, IMapper mapper, ILogger<GenreRepo> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> AddAsync(GenreModifyDto genreModifyDto)
        {
            _logger.LogInformation(Resource.ResourceManager.GetString("creatingGenre"));
            Genre genreModel = _mapper.Map<Genre>(genreModifyDto);
            await _context.Genres.AddAsync(genreModel);
            await _context.SaveChangesAsync();
            _logger.LogInformation(Resource.ResourceManager.GetString("succeeded"));
            return genreModel.Id;
        }

        public async Task Delete(int id)
        {
            _logger.LogInformation(Resource.ResourceManager.GetString("deletingGenre"));
            Genre genreModel = await _context.Genres.SingleOrDefaultAsync(x => x.Id == id);
            if (genreModel is null)
            {
                throw new NotFoundException(Resource.ResourceManager.GetString("genreNotFound"));
            }
            _context.Genres.Remove(genreModel);
            await _context.SaveChangesAsync();
            _logger.LogInformation(Resource.ResourceManager.GetString("succeeded"));
        }

        public async Task<IEnumerable<GenreShortDto>> GetAllAsync()
        {
            _logger.LogInformation(Resource.ResourceManager.GetString("gettingAllGenres"));
            List<Genre> listOfAllGenres = await _context.Genres.ToListAsync();
            var list = _mapper.Map<List<GenreShortDto>>(listOfAllGenres);
            _logger.LogInformation(Resource.ResourceManager.GetString("succeeded"));
            return list;
        }

        public async Task<GenreLongDto> GetByIdAsync(int id)
        {
            _logger.LogInformation(Resource.ResourceManager.GetString("gettingGenre"));
            Genre genre = await _context.Genres.Include(x => x.Materials).SingleOrDefaultAsync(x => x.Id == id);
            if (genre is null)
            {
                throw new NotFoundException(Resource.ResourceManager.GetString("genreNotFound"));
            }
            var genreToReturn = _mapper.Map<GenreLongDto>(genre);
            _logger.LogInformation(Resource.ResourceManager.GetString("succeeded"));
            return genreToReturn;
        }

        public async Task PartialUpdateAsync(Genre genreToUpdate)
        {
            _logger.LogInformation(Resource.ResourceManager.GetString("updatingGenre"));
            if (genreToUpdate is null)
            {
                throw new NotFoundException(Resource.ResourceManager.GetString("genreNotFound"));
            }
            _context.Genres.Update(genreToUpdate);
            await _context.SaveChangesAsync();
            _logger.LogInformation(Resource.ResourceManager.GetString("succeeded"));
        }

        public async Task<Genre> ReadModelAsync(int id)
        {
            _logger.LogInformation(Resource.ResourceManager.GetString("gettingGenre"));
            Genre genre = await _context.Genres.SingleOrDefaultAsync(x => x.Id == id);
            if (genre is null)
            {
                throw new NotFoundException(Resource.ResourceManager.GetString("genreNotFound"));
            }
            _logger.LogInformation(Resource.ResourceManager.GetString("succeeded"));
            return genre;
        }

        public async Task UpdateAsync(int id, GenreModifyDto genreModifyDto)
        {
            _logger.LogInformation(Resource.ResourceManager.GetString("updatingGenre"));
            Genre genreToUpdate = await _context.Genres.SingleOrDefaultAsync(x => x.Id == id);
            if (genreToUpdate is null)
            {
                throw new NotFoundException(Resource.ResourceManager.GetString("genreNotFound"));
            }
            _mapper.Map(genreModifyDto, genreToUpdate);
            //_context.Update(genreToUpdate);
            await _context.SaveChangesAsync();
            _logger.LogInformation(Resource.ResourceManager.GetString("succeeded"));
        }
    }
}
