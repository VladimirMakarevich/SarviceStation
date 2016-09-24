﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceStation.Domain.Model
{
    public enum OrderStatus
    {
        Completed = 0,
        InProgress = 1,
        Canceled = 2
    }

    [Table("Orders", Schema = "service")]
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public DateTime DateStarting { get; set; }
        [Required]
        public DateTime DateFinished { get; set; }
        [Required]
        public decimal OrderAmount { get; set; }
        [Required]
        public OrderStatus Status { get; set; }

        public virtual ClientCard Clients { get; set; }
        public virtual RelatedCars Cars { get; set; }
    }
}
