using AutoMapper;
using CCPolandAPI.DAL.Data;
using CCPolandAPI.DAL.Repositories.Interfaces;
using CCPolandAPI.Models.DTOS.Material;
using CCPolandAPI.Models.EntityModels;
using CCPolandAPI.Properties;
using CCPolandAPI.Services.ErrorHandling.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCPolandAPI.DAL.Repositories
{
    public class MaterialRepo : IMaterialRepo
    {
        private readonly CCPolandDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<MaterialRepo> _logger;

        public MaterialRepo(CCPolandDbContext context, IMapper mapper, ILogger<MaterialRepo> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> AddAsync(MaterialModifyDto materialModifyDto)
        {
            _logger.LogInformation(Resource.ResourceManager.GetString("creatingMaterial"));
            Material materialeModel = _mapper.Map<Material>(materialModifyDto);
            await _context.Materials.AddAsync(materialeModel);
            await _context.SaveChangesAsync();
            _logger.LogInformation(Resource.ResourceManager.GetString("succeeded"));
            return materialeModel.Id;
        }

        public async Task Delete(int id)
        {
            _logger.LogInformation(Resource.ResourceManager.GetString("deletingMaterial"));
            Material materialModel = await _context.Materials.SingleOrDefaultAsync(x => x.Id == id);
            if (materialModel is null)
            {
                throw new NotFoundException(Resource.ResourceManager.GetString("materialNotFound"));
            }
            _context.Materials.Remove(materialModel);
            await _context.SaveChangesAsync();
            _logger.LogInformation(Resource.ResourceManager.GetString("succeeded"));
        }

        public async Task<IEnumerable<MaterialShortDto>> GetAllAsync()
        {
            _logger.LogInformation(Resource.ResourceManager.GetString("gettingAllMaterials"));
            List<Material> listOfAllGenres = await _context.Materials.ToListAsync();
            var list = _mapper.Map<List<MaterialShortDto>>(listOfAllGenres);
            _logger.LogInformation(Resource.ResourceManager.GetString("succeeded"));
            return list;
        }

        public async Task<MaterialLongDto> GetByIdAsync(int id)
        {
            _logger.LogInformation(Resource.ResourceManager.GetString("gettingMaterial"));
            Material material = await _context.Materials
                .Include(x => x.Author)
                .Include(x => x.Genre)
                .Include(x => x.Reviews)
                .SingleOrDefaultAsync(x => x.Id == id);
            if (material is null)
            {
                throw new NotFoundException(Resource.ResourceManager.GetString("materialNotFound"));
            }
            var genreToReturn = _mapper.Map<MaterialLongDto>(material);
            _logger.LogInformation(Resource.ResourceManager.GetString("succeeded"));
            return genreToReturn;
        }

        public async Task UpdateAsync(int id, MaterialModifyDto materialModifyDto)
        {
            _logger.LogInformation(Resource.ResourceManager.GetString("updatingMaterial"));
            Material materialToUpdate = await _context.Materials.SingleOrDefaultAsync(x => x.Id == id);
            if (materialToUpdate is null)
            {
                throw new NotFoundException(Resource.ResourceManager.GetString("materialNotFound"));
            }
            _mapper.Map(materialModifyDto, materialToUpdate);
            //_context.Update(materialToUpdate);
            await _context.SaveChangesAsync();
            _logger.LogInformation(Resource.ResourceManager.GetString("succeeded"));
        }
    }
}
