using AutoMapper;
using CCPolandAPI.DAL.Data;
using CCPolandAPI.DAL.Repositories.Interfaces;
using CCPolandAPI.Models.DTOS.Material;
using CCPolandAPI.Models.EntityModels;
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

        public Task<int> AddAsync(MaterialModifyDto item)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<MaterialShortDto>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<MaterialLongDto> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Material> ReadModelAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(int id, MaterialModifyDto item)
        {
            throw new System.NotImplementedException();
        }
    }
}
