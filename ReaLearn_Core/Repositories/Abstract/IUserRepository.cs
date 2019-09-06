using Microsoft.AspNetCore.Identity;
using ReaLearn_Core.Models;
using ReaLearn_Core.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReaLearn_Core.Repositories.Abstract
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        IEnumerable<ApplicationUser> GetUsersWithCustomerId(int id);
        Task<IdentityResult> AddUserAsync(ApplicationUser user, string Password);
        ApplicationUser GetUser(string id);

        ApplicationUser GetUserWithEmail(string email);
        void UpdateUser(ApplicationUser updatedUser);

    }
}
