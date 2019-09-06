using ReaLearn_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReaLearn_Core.Repositories.Abstract
{
    public interface ICourseRepository : IRepository<Course>
    {
        IEnumerable<Course> GetCoursesWithCustomerId(int id);
        string GetCourseNameWithCourseId(int courseId);
        bool UpdateCourse(Course updatedCourse);
    }
}
