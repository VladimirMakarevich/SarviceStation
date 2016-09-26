using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceStation.Models
{
    public class ListView
    {
        public int TotalContext { get; set; }
        public int ContextPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalContext / ContextPerPage); }
        }

    }
}