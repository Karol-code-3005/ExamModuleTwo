using System.Threading.Tasks;

namespace CCPolandAPI.DAL.Interfaces.IAble
{
    public interface IUpdatable <C> where C : class
    {
        Task Update(C item);
    }
}
