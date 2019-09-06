using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReaLearn_Core.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string CustomerName { get; set; }
        public string Email { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
