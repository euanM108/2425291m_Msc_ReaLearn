using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.IO;
using ReaLearn_Core.Models;
using ReaLearn_Core.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using ReaLearn_Core.Services.Abstract;
using Microsoft.AspNetCore.Authorization;

namespace ReaLearn_Core.Controllers
{
    public class CourseController : Controller
    {
        private readonly IUserService _userService;
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICourseService _courseService;
        private readonly ICourseUserRelationService _courseUserRelationService;
        public CourseController(ICourseService courseService, UserManager<ApplicationUser> userManger, IUserService userService, ISceneService sceneService, ICourseUserRelationService courseUserRelationService)
        {
            _userManager = userManger;
            _userService = userService;
            _courseService = courseService;
            _courseUserRelationService = courseUserRelationService;
        }

        // VIEWS
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> manage()
        {
            // GetCurrentUserAsync() provides more secure access of current user than passing ID
            var currentuser = await GetCurrentUserAsync();

            // Returning the view model to the view with the courses and users
            ViewCoursesViewModel ViewModel = new ViewCoursesViewModel()
            {
               Courses = _courseService.GetCoursesWithCustomerId(currentuser.CustomerId),
               Users = _userService.GetUsersWithCustomerId(currentuser.CustomerId)
            };
            return View(ViewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> manage(ViewCoursesViewModel ViewModel) // Posting - used to add new courses
        {
            // GetCurrentUserAsync() provides more secure access of current user than passing ID
            var currentuser = await GetCurrentUserAsync();

            // Returns all courses with customer ID
            var courses = _courseService.GetCoursesWithCustomerId(currentuser.CustomerId);

            // If ModelState isn't valid, this ensures courses are still returned
            ViewModel.Courses = courses;

            // Populates the viewModel to be returned to the view
            if (ViewModel.RegisterCourseViewModel.Name != null && ViewModel.RegisterCourseViewModel.Description != null)
            {
                var model = ViewModel.RegisterCourseViewModel;
                _courseService.AddCourse(model, currentuser.CustomerId);
                var users = _userService.GetUsersWithCustomerId(currentuser.CustomerId);
                courses = _courseService.GetCoursesWithCustomerId(currentuser.CustomerId);
                ViewModel.Courses = courses;
                ViewModel.Users = users;
                return View(ViewModel);
            }
            return View(ViewModel);
        }


        // ADDING
        [HttpPost]
        public async Task AddCourse(string CourseName, string CourseDescription) // adds course from the Dashboard page with jQuery
        {
            // Gets the current user
            var currentuser = await GetCurrentUserAsync();

            // Creates the RegisterCourseViewModel to pass to the service layer
            RegisterCourseViewModel m = new RegisterCourseViewModel()
            {
                Description = CourseDescription,
                Name = CourseName,
                CustomerId = currentuser.CustomerId
            };

            _courseService.AddCourse(m, currentuser.CustomerId);
        }


        // DELETION
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeleteCourse(int id)
        {
            // remove course and redirect back to manage page so table updates
            _courseService.DeleteCourse(id);
            return RedirectToAction("Manage", "Course");
        }


        // GETTING
        [HttpGet]
        public Course GetCourseDetails(int id)
        {
            // returns course
            return _courseService.GetCourse(id);
        }

        [HttpGet]
        public IEnumerable<string> GetAssignedUsers(int courseId)
        {
            // Returns the course user relations with the course ID for assign course button on data table
            List<CourseUserRelation> relations = _courseUserRelationService.GetCourseUserRelationsWithCourseId(courseId).ToList(); 

            var userIds = new List<string>();
            foreach (CourseUserRelation r in relations)
            {
                userIds.Add(r.UserId);
            }

            // Returns all users from the returned course userrelation table
            if(userIds != null && userIds.Count() > 0)
            {
                return userIds;
            }
            return null;
        }

        // UPDATING
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult UpdateCourse(int Id, string Name, string Description)
        {
            // Updates the course after selecting submit in edit modal
            _courseService.UpdateCourse(Id, Name, Description);
            return RedirectToAction("Manage", "Course");

        }

        // ASSIGNING COURSE TO USER
        [HttpPost]
        public void AssignCourseToUser(int courseId, string userId, bool isAssigned)
        {
            // Assigns a course to a standard user
            _courseUserRelationService.AssignCourseToUser(courseId, userId, isAssigned);
        }


    }
}