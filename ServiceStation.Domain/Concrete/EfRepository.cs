using ServiceStation.Domain.Abstract;
using ServiceStation.Domain.DAL;

namespace ServiceStation.Domain.Concrete
{
    public partial class EfRepository : IRepository
    {
        private ServiceContext db = new ServiceContext();


    }
}
