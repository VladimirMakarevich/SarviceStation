using System.ComponentModel.DataAnnotations;

namespace ServiceStation.Models
{
    public class CheckViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}