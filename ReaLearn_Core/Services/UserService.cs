using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ReaLearn_Core.Models;
using ReaLearn_Core.Models.ViewModels;
using ReaLearn_Core.Repositories.Abstract;
using ReaLearn_Core.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReaLearn_Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IServiceProvider _serviceProvider;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(IUserRepository userRepository, UserManager<ApplicationUser> userManager, IServiceProvider serviceProvider)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _serviceProvider = serviceProvider;
        }

        public async Task<IdentityResult> AddUserAsync(RegisterUserViewModel model, int id)
        {
            var user = new ApplicationUser { UserName = model.UserName, Email = model.Email, CustomerId = id, FirstName = model.FirstName, LastName = model.LastName, TimeStamp = DateTime.Now };

            var result = await _userRepository.AddUserAsync(user, model.Password);
            if (result.Succeeded)
            {
                var roleManager = _serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                var roleCheck = await roleManager.RoleExistsAsync("StandardUser");
                if (!roleCheck)
                {
                    IdentityResult roleResult = await roleManager.CreateAsync(new IdentityRole("StandardUser"));

                }

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "StandardUser");
                }
            }
            return result;
        }

        public async Task<IdentityResult> DeleteAsync(string id)
        {
            var user = _userRepository.GetUser(id);
            if (user != null)
            {
                user = await _userManager.FindByIdAsync(id);
                var result = await _userManager.DeleteAsync(user);
                return result;
            }
            return null;          
        }

        public ApplicationUser GetUserWithEmail(string email)
        {
            var user = _userRepository.GetUserWithEmail(email);
            if (user != null)
            {
                return user;
            }
            return null;
        }

        public IEnumerable<ApplicationUser> GetUsersWithCustomerId(int id)
        {
            var users = _userRepository.GetUsersWithCustomerId(id);
            if (users != null)
            {
                return _userRepository.GetUsersWithCustomerId(id);
            }
            return null;
        }

        public ApplicationUser GetUser(string userId)
        {
            var user = _userRepository.GetUser(userId);
            if (user != null)
            {
                return user;
            }
            return null;
        }

        public void UpdateUser(UpdateAccountDetailsViewModel model, string userId)
        {
            var user = _userRepository.GetUser(userId);
            if (user != null)
            {
                ApplicationUser updatedUser = new ApplicationUser()
                {
                    Id = userId,
                    CustomerId = user.CustomerId,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    TimeStamp = DateTime.Now,
                    UserName = model.UserName
                };

                _userRepository.UpdateUser(updatedUser);

                
            }
        }

    }
}
