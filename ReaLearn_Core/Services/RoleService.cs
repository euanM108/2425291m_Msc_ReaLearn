using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ReaLearn_Core.Repositories.Abstract;
using ReaLearn_Core.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReaLearn_Core.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IServiceProvider _serviceProvider;

        public RoleService(IRoleRepository roleRepository, IServiceProvider serviceProvider)
        {
            _roleRepository = roleRepository;
            _serviceProvider = serviceProvider;
        }

        public async Task CreateRoleAsync(string role)
        {
            var roleManager = _serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            await roleManager.CreateAsync(new IdentityRole(role));
        }

        public async Task<bool> DoesRoleExistAsync(string role)
        {
            var roleManager = _serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            return await roleManager.RoleExistsAsync(role);
        }

        public IEnumerable<IdentityRole> GetRoles()
        {
            return _roleRepository.GetAll();
        }
    }
}
