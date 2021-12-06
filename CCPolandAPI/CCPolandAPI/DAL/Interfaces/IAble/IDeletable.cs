using System.Threading.Tasks;

namespace CCPolandAPI.DAL.Interfaces.IAble
{
    public interface IDeletable
    {
        Task Delete(int id);
    }
}
