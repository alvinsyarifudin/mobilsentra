using System;
using System.ComponentModel.DataAnnotations;

namespace mobilsentra.Controllers.Resources
{
    public class ContactResource
    {
        [Required]
        [StringLength(255)]
        public String Name { get; set; }
        [Required]
        [StringLength(255)]
        public String Phone { get; set; }
        public String Email { get; set; }
    }
}