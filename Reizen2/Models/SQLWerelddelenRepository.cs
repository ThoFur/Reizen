using Model.Entities;
using Model.Repositories;

namespace Reizen2.Models
{
    public class SQLWerelddelenRepository : IWerelddelenRepository
    {
        private readonly ReizenContext context;
        public SQLWerelddelenRepository(ReizenContext context)
        {
            this.context = context;
        }

        public IEnumerable<Werelddeel> GetAll()
        {
            return context.Werelddelen;
        }
    }
}
