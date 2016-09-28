using ServiceStation.Domain.Abstract;
using ServiceStation.Domain.DAL;
using System;
using ServiceStation.Domain.Model;
using System.Threading.Tasks;

namespace ServiceStation.Domain.Concrete
{
    public partial class EfRepository : IRepository
    {
        private ServiceContext db = new ServiceContext();
    }
}
