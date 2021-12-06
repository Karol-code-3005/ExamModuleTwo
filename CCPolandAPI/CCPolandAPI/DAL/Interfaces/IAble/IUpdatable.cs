using System.Threading.Tasks;

namespace CCPolandAPI.DAL.Interfaces.IAble
{
    public interface IUpdatable <C> where C : class
    {
        Task UpdateAsync(int id,C item);
    }
}
