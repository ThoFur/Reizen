using Model.Entities;

namespace Reizen2.Models
{
    public interface IWerelddelenRepository
    {
        
        IEnumerable<Werelddeel> GetAll();
    }
}
