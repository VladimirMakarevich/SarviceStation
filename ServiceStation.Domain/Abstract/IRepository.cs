using ServiceStation.Domain.Model;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceStation.Domain.Abstract
{
    public interface IRepository
    {
        IQueryable<Orders> Order { get; }
        IQueryable<RelatedCars> RelatedCars { get; }
        IQueryable<ClientCard> ClientCard { get; }

        Task<string> AddClientCardAsync(ClientCard model);
        Task<string> AddCarAsync(RelatedCars model);
        Task<string> AddOrderAsync(Orders model);

    }
}
