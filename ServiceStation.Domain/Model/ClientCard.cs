using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceStation.Domain.Model
{

    [Table("ClientCard", Schema = "service")]
    public class ClientCard
    {
        [Key]
        public int ClientId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<RelatedCars> ClientCars { get; set; }
        public virtual ICollection<Orders> ClientOrder { get; set; }
    }
}
