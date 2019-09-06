using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReaLearn_Core.Models.ViewModels
{
    public class ViewUsersViewModel
    {
       public IEnumerable<ApplicationUser> Users { get; set; }
       public RegisterUserViewModel RegisterUserViewModel { get; set; }

        public EditUserViewModel EditUserViewModel { get; set; }
        public IEnumerable<IdentityRole> AvailableRoles { get; set; }
    }
}
