using ServiceStation.Domain.Model;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceStation.Domain.Abstract
{
    public interface IRepository
    {
        #region Properies
        IQueryable<Orders> Order { get; }
        IQueryable<RelatedCars> RelatedCars { get; }
        IQueryable<ClientCard> ClientCard { get; }
        #endregion

        #region Add 
        Task<string> AddClientCardAsync(ClientCard model);
        Task<string> AddCarAsync(RelatedCars model);
        Task<string> AddOrderAsync(Orders model);
        #endregion

        #region Modified
        Task<string> ModifeidClientCardAsync(ClientCard model);
        Task<string> ModifeidCarAsync(RelatedCars model);
        Task<string> ModifeidOrderAsync(Orders model);
        #endregion

        #region Delete
        Task<string> DeleteClientCardAsync(ClientCard model);
        Task<string> DeleteCarAsync(RelatedCars model);
        Task<string> DeleteOrderAsync(Orders model);
        #endregion

        #region Check
        Task<ClientCard> CheckClientCardAsync(ClientCard model);
        Task<RelatedCars> CheckFreeCarAsync(RelatedCars model);
        Task<Orders> CheckOrderAsync(Orders model);
        #endregion
    }
}
