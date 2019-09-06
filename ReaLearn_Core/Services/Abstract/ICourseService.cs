using ReaLearn_Core.Models;
using ReaLearn_Core.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReaLearn_Core.Services.Abstract
{
    public interface ICourseService
    {
        IEnumerable<Course> GetCoursesWithCustomerId(int id);

        Course AddCourse(RegisterCourseViewModel model, int customerId);

        Course GetCourse(int id);

        void DeleteCourse(int id);
        string GetCourseNameWithCourseId(int courseId);
        bool UpdateCourse(int id, string name, string description);
        IEnumerable<Course> GetCourses();
        IEnumerable<Course> GetCoursesWithCourseIds(List<int> courseIds);
    }
}
