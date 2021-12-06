using AutoMapper;
using CCPolandAPI.DAL.Data;
using CCPolandAPI.DAL.Repositories.Interfaces;
using CCPolandAPI.Models.DTOS.Author;
using CCPolandAPI.Models.EntityModels;
using CCPolandAPI.Properties;
using CCPolandAPI.Services.ErrorHandling.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCPolandAPI.DAL.Repositories
{
    public class AuthorRepo : IAuthorRepo
    {
        private readonly CCPolandDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthorRepo> _logger;

        public AuthorRepo(CCPolandDbContext context, IMapper mapper, ILogger<AuthorRepo> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> AddAsync(AuthorModifyDto authorModifyDto)
        {
            _logger.LogInformation(Resource.ResourceManager.GetString("creatingAuthor"));
            Author authorModel = _mapper.Map<Author>(authorModifyDto);
            await _context.Authors.AddAsync(authorModel);
            await _context.SaveChangesAsync();
            _logger.LogInformation(Resource.ResourceManager.GetString("succeeded"));

            return authorModel.Id;
        }

        public async Task Delete(int id)
        {
            _logger.LogInformation(Resource.ResourceManager.GetString("deletingAuthor"));
            Author authorModel = await _context.Authors.SingleOrDefaultAsync(x => x.Id == id);
            if(authorModel is null)
            {
                throw new NotFoundException(Resource.ResourceManager.GetString("authorNotFound"));
            }
            _context.Authors.Remove(authorModel);
            await _context.SaveChangesAsync();
            _logger.LogInformation(Resource.ResourceManager.GetString("succeeded"));
        }

        public async Task<IEnumerable<AuthorShortDto>> GetAllAsync()
        {
            _logger.LogInformation(Resource.ResourceManager.GetString("gettingAllAuthors"));
            List<Author> listOfAllAuthors = await _context.Authors.ToListAsync();
            var list =  _mapper.Map<List<AuthorShortDto>>(listOfAllAuthors);
            _logger.LogInformation(Resource.ResourceManager.GetString("succeeded"));
            return list;
        }

        public async Task<AuthorLongDto> GetByIdAsync(int id)
        {
            _logger.LogInformation(Resource.ResourceManager.GetString("gettingAuthor"));
            Author author = await _context.Authors.Include(x =>x.Materials).SingleOrDefaultAsync(x =>x.Id == id);
            if (author is null)
            {
                throw new NotFoundException(Resource.ResourceManager.GetString("authorNotFound"));
            }
            var authorToReturn = _mapper.Map<AuthorLongDto>(author);
            _logger.LogInformation(Resource.ResourceManager.GetString("succeeded"));
            return authorToReturn;
        }

        public async Task<Author> ReadModelAsync(int id)
        {
            _logger.LogInformation(Resource.ResourceManager.GetString("gettingAuthor"));
            Author author = await _context.Authors.SingleOrDefaultAsync(x => x.Id==id);
            if (author is null)
            {
                throw new NotFoundException(Resource.ResourceManager.GetString("authorNotFound"));
            }
            _logger.LogInformation(Resource.ResourceManager.GetString("succeeded"));
            return author;
        }

        public async Task PartialUpdateAsync(Author authorToUpdate)
        {
            _logger.LogInformation(Resource.ResourceManager.GetString("updatingAuthor"));
            if (authorToUpdate is null)
            {
                throw new NotFoundException(Resource.ResourceManager.GetString("authorNotFound"));
            }
            _context.Authors.Update(authorToUpdate);
            await _context.SaveChangesAsync();
            _logger.LogInformation(Resource.ResourceManager.GetString("succeeded"));
        }

        public async Task UpdateAsync(int id, AuthorModifyDto authorModifyDto)
        {
            _logger.LogInformation(Resource.ResourceManager.GetString("updatingAuthor"));
            Author authorToUpdate = await _context.Authors.SingleOrDefaultAsync(x =>x.Id==id);
            if (authorToUpdate is null)
            {
                throw new NotFoundException(Resource.ResourceManager.GetString("authorNotFound"));
            }
            _mapper.Map(authorModifyDto, authorToUpdate);
            //_context.Update(authorToUpdate);
            await _context.SaveChangesAsync();
            _logger.LogInformation(Resource.ResourceManager.GetString("succeeded"));
        }
    }
}
