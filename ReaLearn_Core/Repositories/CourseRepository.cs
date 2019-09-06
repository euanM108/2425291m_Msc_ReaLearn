using ReaLearn_Core.Data;
using ReaLearn_Core.Models;
using ReaLearn_Core.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReaLearn_Core.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private ApplicationDbContext _context { get; set; }

        public CourseRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Course> GetCoursesWithCustomerId(int id)
        {
            return _context.Set<Course>().Where(c => c.CustomerId == id);
        }

        public string GetCourseNameWithCourseId(int courseId)
        {
            return _context.Set<Course>().Where(c => c.Id == courseId).FirstOrDefault().Name;
        }

        public bool UpdateCourse(Course updatedCourse)
        {
            var result = _context.Set<Course>().Where(c => c.Id == updatedCourse.Id).FirstOrDefault();

            result.Description = updatedCourse.Description;
            result.Name = updatedCourse.Name;
            result.TimeStamp = DateTime.Now;
            _context.SaveChanges();

            return true;
        }
    }
}
