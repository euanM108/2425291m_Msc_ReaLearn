using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReaLearn_Core.Models.ViewModels
{
    public class ViewCoursesViewModel
    {
        public IEnumerable<Course> Courses { get; set; }
        public RegisterCourseViewModel RegisterCourseViewModel { get; set; }
        
        public IEnumerable<ApplicationUser> Users { get; set; }

        [Required]
        public int CourseId { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
