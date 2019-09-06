using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReaLearn_Core.Models.ViewModels
{
    public class HomepageViewModel
    {
        public IEnumerable<Course> courses { get; set; }
        public IEnumerable<Scene> scenes { get; set; }

        public LoginViewModel LoginViewModel { get; set; }

    }
}
