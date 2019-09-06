using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReaLearn_Core.Models;
using ReaLearn_Core.Models.ViewModels;
using ReaLearn_Core.Services.Abstract;

namespace ReaLearn_Core.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRegistrationService _customerRegistrationService;
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        private readonly IRoleService _roleService;
        public CustomerController(ICustomerRegistrationService customerRegistrationService, UserManager<ApplicationUser> userManger, IUserService userService, IRoleService roleService)
        {
            _userManager = userManger;
            _userService = userService;
            _customerRegistrationService = customerRegistrationService;
            _roleService = roleService;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ViewUsers()
        {
            // Gets the current user
            var user = await GetCurrentUserAsync();
            
            // The user's customer ID is used to retrieve all other users.
            var users = _userService.GetUsersWithCustomerId(user.CustomerId);

            // populates the view model to be returned to the view
            ViewUsersViewModel ViewModel = new ViewUsersViewModel()
            {
                Users = users,
                AvailableRoles = _roleService.GetRoles()
            };

            return View(ViewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> ViewUsers(ViewUsersViewModel ViewModel) // POST to add new user
        {
            // Gets the current user
            var currentuser = await GetCurrentUserAsync();

            // The user's customer ID is used to retrieve all other users.
            var users = _userService.GetUsersWithCustomerId(currentuser.CustomerId);
            ViewModel.Users = users;
           
            // If the form in the view is valid
            if (ModelState.IsValid)
            {
                var model = ViewModel.RegisterUserViewModel;
                var result = await _userService.AddUserAsync(model, currentuser.CustomerId);
                users = _userService.GetUsersWithCustomerId(currentuser.CustomerId);
                ViewModel.Users = users;
                ViewModel.AvailableRoles = _roleService.GetRoles();

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(ViewModel);
            }
            return View(ViewModel);
        }

        // ADDING
        [AllowAnonymous] 
        public IActionResult Register()
        { 
            // Returns the register view
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterCustomerViewModel customer)
        {
            // If the register form is valid 
            if (ModelState.IsValid)
            {
                var result = await _customerRegistrationService.RegisterCustomerAsync(customer);

                if (result.Succeeded)
                {
                    // If successful, return to log in page
                    return RedirectToAction("index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View();
        }


        // DELETE
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            // if modelstate is valid then continue to delete user
            if (ModelState.IsValid)
            {
                var result = await _userService.DeleteAsync(id);

                if (result.Succeeded)
                { 
                    // if successful, return to view users page
                    return RedirectToAction("ViewUsers", "Customer");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return RedirectToAction("ViewUsers", "Customer");
        }


        // UPDATE 
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult UpdateUser(string Email, string UserName, string FirstName, string LastName)
        {
            // If both username and email are not null, then continue
            if (Email != null && UserName != null)
            {
                // Return the ID of the user with the email - EMAIL'S ARE UNIQUE
                var id = _userService.GetUserWithEmail(Email).Id;

                // Populate the model
                UpdateAccountDetailsViewModel model = new UpdateAccountDetailsViewModel()
                {
                    Email = Email,
                    FirstName = FirstName,
                    LastName = LastName,
                    UserName = UserName,
                };

                _userService.UpdateUser(model, id);
            }
            return RedirectToAction("ViewUsers", "Customer");
        }
    }
}