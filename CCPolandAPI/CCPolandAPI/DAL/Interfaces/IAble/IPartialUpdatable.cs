using System.Threading.Tasks;

namespace CCPolandAPI.DAL.Interfaces.IAble
{
    public interface IPartialUpdatable<C> where C : class
    {
        Task PartialUpdateAsync(C item);
    }
}
