using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ReaLearn_Core.Models;
using ReaLearn_Core.Models.ViewModels;
using ReaLearn_Core.Services.Abstract;
using System;
using System.Threading.Tasks;

namespace ReaLearn_Core.Services
{
    public class CustomerRegistrationService : ICustomerRegistrationService
    {
        private readonly ICustomerService _customerService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRoleService _roleService;
        public CustomerRegistrationService(ICustomerService customerService, UserManager<ApplicationUser> userManager, IRoleService roleService)
        {
            _customerService = customerService;
            _userManager = userManager;
            _roleService = roleService;
        }

        public async Task<IdentityResult> RegisterCustomerAsync(RegisterCustomerViewModel model)
        {
            Customer customer = new Customer()
            {
                TimeStamp = DateTime.Now,
                Email = model.Email,
                CustomerName = model.CustomerName,
            };
            
            _customerService.AddCustomer(customer);

            ApplicationUser customerUserAccount = new ApplicationUser()
            {
                CustomerId = customer.Id,
                Email = model.Email,
                FirstName = model.CustomerName,
                UserName = model.UserName,
                TimeStamp = DateTime.Now
            };

            var result = await _userManager.CreateAsync(customerUserAccount, model.Password);

            if (result.Succeeded)
            {
                bool doesRoleExist = await _roleService.DoesRoleExistAsync("Admin");
                
                if (!doesRoleExist)
                {
                    await _roleService.CreateRoleAsync("Admin");
                }

                await _userManager.AddToRoleAsync(customerUserAccount, "Admin");
            }
            return result;
        }

        
    }
}
