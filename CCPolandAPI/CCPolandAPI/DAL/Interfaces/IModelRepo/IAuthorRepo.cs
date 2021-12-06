using CCPolandAPI.DAL.Interfaces.IAble;
using CCPolandAPI.Models.DTOS.Author;
using CCPolandAPI.Models.EntityModels;

namespace CCPolandAPI.DAL.Repositories.Interfaces
{
    public interface IAuthorRepo : 
        ICreatable<AuthorModifyDto>,
        IReadable<Author>,
        IUpdatable<AuthorModifyDto>,
        IPartialUpdatable<Author>,
        IDeletable,
        IGetable<AuthorLongDto, AuthorShortDto>
    {

    }
}
