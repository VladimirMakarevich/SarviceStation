using ServiceStation.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServiceStation.Models
{
    #region Car Single View
    public class CarViewModel
    {
        [Required]
        public int CarId { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        public string VIN { get; set; }
    }
    #endregion

    #region Car List
    public class CarListViewModel
    {
        public IEnumerable<RelatedCars> Cars { get; set; }
        public ListView PagingView { get; set; }
    }
    #endregion

    #region Car Checked 
    public class CarCheckedViewModel
    {
        public int CarId { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        public string VIN { get; set; }
        public Orders OrdersDate { get; set; }
    }
    #endregion
}