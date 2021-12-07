using CCPolandAPI.DAL.Interfaces.IAble;
using CCPolandAPI.Models.DTOS.Author;
using CCPolandAPI.Models.DTOS.Material;
using CCPolandAPI.Models.EntityModels;

namespace CCPolandAPI.DAL.Repositories.Interfaces
{
    public interface IMaterialRepo :
        ICreatable<MaterialModifyDto>,
        IUpdatable<MaterialModifyDto>,
        IDeletable,
        IGetable<MaterialLongDto, MaterialShortDto>
    {
    }
}
