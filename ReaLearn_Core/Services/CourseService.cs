using ReaLearn_Core.Models;
using ReaLearn_Core.Models.ViewModels;
using ReaLearn_Core.Models.VRObjectModels;
using ReaLearn_Core.Repositories.Abstract;
using ReaLearn_Core.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReaLearn_Core.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ISceneService _sceneService;
        private readonly IVRBackgroundService _backgroundService;
        public CourseService(ICourseRepository courseRepository, ISceneService sceneService, IVRBackgroundService backgroundService)
        {
            _courseRepository = courseRepository;
            _sceneService = sceneService;
            _backgroundService = backgroundService;
        }

        public IEnumerable<Course> GetCoursesWithCustomerId(int id)
        {
            return _courseRepository.GetCoursesWithCustomerId(id);
        }

        public Course AddCourse(RegisterCourseViewModel model, int customerId)
        {
            Course course = new Course()
            {
                CustomerId = customerId,
                Description = model.Description,
                Name = model.Name,
                TimeStamp = DateTime.Now,
            };
            _courseRepository.Add(course); 

            Scene scene = new Scene()
            {
                CourseId = course.Id
            };

            _sceneService.AddScene(scene);

            VRBackground background = new VRBackground()
            {
                SceneId = scene.Id
            };

            _backgroundService.AddImage(background);

            return course;
        }

        public Course GetCourse(int id)
        {
            var course = _courseRepository.Get(id);
            if (course != null)
            {
                return course;
            }
            return null;
        }

        public void DeleteCourse(int id)
        {
            Course course = _courseRepository.Get(id);
            if (course != null)
            {
                _courseRepository.Remove(course);
            }
        }

        public string GetCourseNameWithCourseId(int courseId)
        {
            var name = _courseRepository.GetCourseNameWithCourseId(courseId);
            if (name != null)
            {
                return name;
            }
            return null;
        }

        public bool UpdateCourse(int id, string name, string description)
        {
            var course = _courseRepository.Get(id);
            if (course != null)
            {
                Course updatedCourse = new Course()
                {
                    Id=id,
                    Name = name,
                    Description = description
                };

               return _courseRepository.UpdateCourse(updatedCourse);
            }
            return false;
        }

        public IEnumerable<Course> GetCourses()
        {
            return _courseRepository.GetAll();
        }

        public IEnumerable<Course> GetCoursesWithCourseIds(List<int> courseIds)
        {
            List<Course> courses = new List<Course>();
            if (courseIds != null)
            {
                foreach (int id in courseIds)
                {
                    if (_courseRepository.Get(id) != null)
                    {
                        courses.Add(_courseRepository.Get(id));
                    }
                }
            }
            if (courses.Count() > 0)
            {
                return courses;
            }
            else
            {
                return null;
            }
          
        }
    }
}
