using ServiceStation.Domain.Model;
using System.Linq;

namespace ServiceStation.Domain.Concrete
{
    public partial class EfRepository
    {
        public IQueryable<ClientCard> ClientCard
        {
            get
            {
                return db.ClientCardsi;
            }
        }
    }
}
