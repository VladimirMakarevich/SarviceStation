using ServiceStation.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServiceStation.Models
{
    #region New Order
    public class NewOrderViewModel
    {
        public Orders Order { get; set; }
        public ClientCard ClientCard { get; set; }
        //public RelatedCars RelatedCar { get; set; }
    }
    #endregion

    #region Order View Model
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public decimal OrderAmount { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
        public int ClientId { get; set; }
        public int CarId { get; set; }

        public virtual ClientCard Clients { get; set; }
        public virtual RelatedCars Cars { get; set; }
    }
    #endregion

    #region Order List
    public class OrderListViewModel
    {
        public IEnumerable<Orders> Orders { get; set; }
        public ListView PagingView { get; set; }
    }
    #endregion

    #region CheckOrderViewModel
    public class CheckOrderViewModel
    {
        [HiddenInput]
        public int OrderId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:mm.dd.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public decimal OrderAmount { get; set; }
        public OrderStatus Status { get; set; }
        public int ClientId { get; set; }
        public int CarId { get; set; }

        public virtual ClientCard Clients { get; set; }
        public virtual RelatedCars Cars { get; set; }
    }
    #endregion
}
