using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReaLearn_Core.Services.Abstract
{
    public interface IRoleService
    {
        IEnumerable<IdentityRole> GetRoles();
        Task<bool> DoesRoleExistAsync(string role);
        Task CreateRoleAsync(string role);
    }
}
