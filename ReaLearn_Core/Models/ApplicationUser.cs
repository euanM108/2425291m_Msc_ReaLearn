using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReaLearn_Core.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime TimeStamp { get; set; }

    }
}
