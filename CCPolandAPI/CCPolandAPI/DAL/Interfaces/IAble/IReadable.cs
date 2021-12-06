using System.Threading.Tasks;

namespace CCPolandAPI.DAL.Interfaces.IAble
{
    public interface IReadable<C> where C : class  
    {
        Task<C> Read(int id);
    }
}
