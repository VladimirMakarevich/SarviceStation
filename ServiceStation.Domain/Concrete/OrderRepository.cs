using ServiceStation.Domain.Model;
using System.Linq;

namespace ServiceStation.Domain.Concrete
{
    public partial class EfRepository
    {
        public IQueryable<Orders> Order
        {
            get
            {
                return db.Ordersi;
            }
        }
    }
}
