using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MimeKit;
using ReaLearn_Core.Areas.Identity.Pages.Account;
using ReaLearn_Core.Models;
using ReaLearn_Core.Models.ViewModels;
using ReaLearn_Core.Models.VRObjectModels;
using ReaLearn_Core.Services.Abstract;

namespace ReaLearn_Core.Controllers
{
    public class HomeController : Controller
    {

        private readonly SignInManager<ApplicationUser> _signInManager;
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        private readonly ILogger<LoginModel> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICourseService _courseService;
        private readonly ISceneService _sceneService;
        private readonly IUserService _userService;
        private readonly IVRBackgroundService _VRBackgroundService;
        private readonly ICourseUserRelationService _courseUserRelationService;

        public HomeController(ISceneService sceneService, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, ILogger<LoginModel> logger, ICourseService courseService, IUserService userService, IVRBackgroundService VRBackgroundService, ICourseUserRelationService courseUserRelationService)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
            _courseService = courseService;
            _userService = userService;
            _VRBackgroundService = VRBackgroundService;
            _courseUserRelationService = courseUserRelationService;
            _sceneService = sceneService;
        }

        // RETURNING VIEWS
        [AllowAnonymous]
        public IActionResult Index()
        {
            // If user is logged in, return to the dashboard
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Dashboard", "Home");
            }
            // if not, return back to the log in page
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(HomepageViewModel HPViewModel) // POST called when user logs in
        {
            string returnUrl = null;
            returnUrl = returnUrl ?? Url.Content("~/");
            LoginViewModel model = HPViewModel.LoginViewModel;

            // If log in form is valid
            if (ModelState.IsValid)
            {
                // Sign in
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return RedirectToAction("Dashboard","Home");
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View();
                }
            }

            return View();
        }

        [Authorize]
        public async Task<IActionResult> Dashboard()
        {
            // Get current user
            var currentuser = await GetCurrentUserAsync();

            bool isUserAdmin = await _userManager.IsInRoleAsync(currentuser, "Admin");
            List<int> courseIds = new List<int>();
            IEnumerable<Course> courses = new List<Course>();

            // If user isn't admin, return only courses assigned the them
            if (!isUserAdmin)
            {
                IEnumerable<CourseUserRelation> courseUserRelations = _courseUserRelationService.GetCourseUserRelationsWithUserId(currentuser.Id);
       
                foreach (CourseUserRelation r in courseUserRelations)
                {
                    courseIds.Add(r.CourseId);
                }
                courses = _courseService.GetCoursesWithCourseIds(courseIds);
            }
            else
            {// If user is admin, return all courses under their account
                courses = _courseService.GetCoursesWithCustomerId(currentuser.CustomerId);
                foreach (Course c in courses)
                {
                    courseIds.Add(c.Id);
                }
            }

            List<VRBackground> tempBackgrounds = new List<VRBackground>();

            // get first scene of each course
            // get image from each scene
            List<Scene> firstScenes = new List<Scene>();
            foreach(int i in courseIds)
            {
                firstScenes.Add(_sceneService.GetScenesWithCourseId(i).ElementAt(0));
            }
            foreach(Scene s in firstScenes)
            {
                // for each scene, store the background in tempBackgrounds
                tempBackgrounds.Add(_VRBackgroundService.getBackgroundImageObjectWithSceneId(s.Id));
            }

            IEnumerable<VRBackground> BackgroundImages = tempBackgrounds;

            DashboardViewModel viewModel = new DashboardViewModel()
            {
                Courses = courses,
                Images = BackgroundImages,
            };

            return View(viewModel);
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactFormModel model)
        {
            return View();
        }
        public IActionResult Help()
        {
            return View();
        }

        // POSTS MAIL
        [HttpPost]
        public IActionResult OnPost(ContactFormModel model)
        {
            SendMail(model);
            return Redirect("/contact");
        }

        // Values for contact us page - sends mail to my ReaLearn@gmail.com account
        string username { get; set; } = "ReaLearnVR@gmail.com";
        string emailprivate{get;set; } = "ReaLearnVR@gmail.com";
        string w { get; set; } = "o78!789971B"; 

        // SENDS MAIL TO EMAIL
        [HttpPost]
        public void SendMail(ContactFormModel model)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(model.Name, model.Email));
            message.To.Add(new MailboxAddress("Euan", emailprivate));
            message.Subject = "Contact Form Submission";
            message.Body = new TextPart("plain")
            {
                Text = model.Message
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate(username, w);
                client.Send(message);
                client.Disconnect(true);
            }
        }

  
    }
   
}
