using ServiceStation.Domain.Model;
using System.Linq;

namespace ServiceStation.Domain.Abstract
{
    public interface IRepository
    {
        IQueryable<Orders> Order { get; }
        IQueryable<RelatedCars> RelatedCars { get; }
        IQueryable<ClientCard> ClientCard { get; }



    }
}
