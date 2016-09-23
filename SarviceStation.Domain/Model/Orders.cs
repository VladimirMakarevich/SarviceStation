using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarviceStation.Domain.Model
{
    class Orders
    {
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public decimal OrderAmount { get; set; }
        public virtual OrderStatus Status { get; set; }
    }
}
