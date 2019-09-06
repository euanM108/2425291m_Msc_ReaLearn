using ReaLearn_Core.Models.VRObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReaLearn_Core.Models.ViewModels
{
    public class DashboardViewModel
    {
       public IEnumerable<Course> Courses { get; set; }
       public IEnumerable<VRBackground> Images { get; set; }
       
    }
}
