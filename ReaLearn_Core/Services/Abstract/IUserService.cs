using Microsoft.AspNetCore.Identity;
using ReaLearn_Core.Models;
using ReaLearn_Core.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReaLearn_Core.Services.Abstract
{
    public interface IUserService
    {
        IEnumerable<ApplicationUser> GetUsersWithCustomerId(int id);
        Task<IdentityResult> AddUserAsync(RegisterUserViewModel model, int customerId);
        Task<IdentityResult> DeleteAsync(string id);
        ApplicationUser GetUserWithEmail(string email);
        ApplicationUser GetUser(string userId);
        void UpdateUser(UpdateAccountDetailsViewModel model, string userId);

    }
}
