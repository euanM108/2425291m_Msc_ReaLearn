using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReaLearn_Core.Models;
using ReaLearn_Core.Models.ViewModels;
using ReaLearn_Core.Services.Abstract;

namespace ReaLearn_Core.Controllers
{
    public class AccountController : Controller
    {

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserService _userService;


        public AccountController(UserManager<ApplicationUser> userManager, IUserService userService)
        {
            _userManager = userManager;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            // View Model for updating account details
            UpdateAccountDetailsViewModel viewModel = await GetUpdateAccountDetailsViewModelAsync();
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UpdateAccountDetailsViewModel viewModel)
        {
            // GetCurrentUserAsync() provides more secure access of current users details
            ApplicationUser currentUser = await GetCurrentUserAsync();

            // Update the current users details
            _userService.UpdateUser(viewModel, currentUser.Id);

            return View(viewModel);
        }

        public async Task<UpdateAccountDetailsViewModel> GetUpdateAccountDetailsViewModelAsync()
        {
            // GetCurrentUserAsync() provides more secure access of current users details
            ApplicationUser currentUser = await GetCurrentUserAsync();

            // populate viewModel with current users details 
            UpdateAccountDetailsViewModel viewModel = new UpdateAccountDetailsViewModel()
            {
                Email = currentUser.Email,
                FirstName = currentUser.FirstName,
                LastName = currentUser.LastName,
                PhoneNumber = currentUser.PhoneNumber,
                userId = currentUser.Id,
                UserName = currentUser.UserName
            };

            return viewModel;
        }
    }
}