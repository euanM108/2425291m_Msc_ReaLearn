using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ReaLearn_Core.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string Description { get; set; }
        public DateTime TimeStamp { get; set; }

 
    }
}
