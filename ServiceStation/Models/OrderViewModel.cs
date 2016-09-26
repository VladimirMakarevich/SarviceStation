using ServiceStation.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceStation.Models
{
    #region New Order
    public class NewOrderViewModel
    {
        public Orders Order { get; set; }
        public ClientCard ClientCard { get; set; }
        public RelatedCars RelatedCar { get; set; }
    }
    #endregion

    #region Order View Model
    public class OrderViewModel
    {

    }
    #endregion

    #region Order List
    public class OrderListViewModel
    {
        public IEnumerable<Orders> Orders { get; set; }
        public ListView PagingView { get; set; }
    }
    #endregion
}