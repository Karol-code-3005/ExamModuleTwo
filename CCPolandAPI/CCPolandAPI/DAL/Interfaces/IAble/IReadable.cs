using System.Threading.Tasks;

namespace CCPolandAPI.DAL.Interfaces.IAble
{
    public interface IReadable<C> where C : class  
    {
        Task<C> ReadModelAsync(int id);
    }
}
