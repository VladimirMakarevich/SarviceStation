using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServiceStation.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "all the fields are required")]
        [StringLength(30, MinimumLength = 5)]
        public string Name { get; set; }
        [Required(ErrorMessage = "all the fields are required")]
        [EmailAddress(ErrorMessage = "the email field is not a valid e - mail addres")]
        public string Email { get; set; }
        [Required(ErrorMessage = "all the fields are required")]
        public string Message { get; set; }
        [IsValidBool]
        public bool Check { get; set; }
    }
}