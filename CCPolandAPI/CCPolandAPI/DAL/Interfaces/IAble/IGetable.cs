using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCPolandAPI.DAL.Interfaces.IAble
{
    public interface IGetable<L,S> 
        where L : class
        where S : class
    {
        Task<L> GetById(int id);
        Task<IEnumerable<S>> GetAll();
    }
}
