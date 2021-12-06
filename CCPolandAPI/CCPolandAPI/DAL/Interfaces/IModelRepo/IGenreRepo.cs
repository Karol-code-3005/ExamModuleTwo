using CCPolandAPI.DAL.Interfaces.IAble;
using CCPolandAPI.Models.DTOS.Genre;
using CCPolandAPI.Models.EntityModels;

namespace CCPolandAPI.DAL.Repositories.Interfaces
{
    public interface IGenreRepo:
        ICreatable<GenreModifyDto>,
        IReadable<Genre>,
        IUpdatable<GenreModifyDto>,
        IPartialUpdatable<Genre>,
        IDeletable,
        IGetable<GenreLongDto, GenreShortDto>
    {
    }
}
