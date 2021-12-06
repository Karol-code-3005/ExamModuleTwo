using System.Threading.Tasks;

namespace CCPolandAPI.DAL.Interfaces.IAble
{
    public interface ICreatable<M> where M : class
    {
        Task<int> Add(M item);
    }
}
