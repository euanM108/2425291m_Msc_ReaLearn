using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReaLearn_Core.Models.ViewModels
{
    public class RegisterCourseViewModel
    {

        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Description { get; set; }

        public int CustomerId { get; set; }
    }
}
