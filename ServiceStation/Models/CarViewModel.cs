using ServiceStation.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServiceStation.Models
{
    #region Car Single View
    public class CarViewModel
    {
        [HiddenInput]
        public int CarId { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Models { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        public string VIN { get; set; }
        public virtual ICollection<Orders> RelatedOrder { get; set; }
    }
    #endregion

    #region Car List
    public class CarListViewModel
    {
        public IEnumerable<RelatedCars> Cars { get; set; }
        public ListView PagingView { get; set; }
    }
    #endregion

    #region Check Car
    public class CheckCarViewModel
    {
        [Required]
        public string Make { get; set; }
        [Required]
        public string Models { get; set; }
        [Required]
        public string Year { get; set; }
        public DateTime Date { get; set; }
    }
    #endregion
}