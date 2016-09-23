using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Domain.Model
{
    [Table("RelatedCars", Schema = "service")]
    public class RelatedCars
    {
        [Key]
        public int CarId { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        public string VIN { get; set; }

        public virtual ICollection<Orders> RelatedOrder { get; set; }
    }
}
