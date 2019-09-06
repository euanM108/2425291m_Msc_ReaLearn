using ReaLearn_Core.Data;
using ReaLearn_Core.Models;
using ReaLearn_Core.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReaLearn_Core.Repositories
{
    public class CourseUserRelationRepository : Repository<CourseUserRelation>, ICourseUserRelationRepository
    {
        private ApplicationDbContext _context { get; set; }

        public CourseUserRelationRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<CourseUserRelation> GetCourseUserRelationsWithCourseId(int courseId)
        {
            return _context.Set<CourseUserRelation>().Where(c => c.CourseId == courseId);
        }

        public void AssignCourseToUser(CourseUserRelation relation)
        {
            _context.Set<CourseUserRelation>().Add(relation);
            _context.SaveChanges();
          
        }

        public CourseUserRelation GetRelationsWithCourseAndUserId(int courseId, string userId)
        {
            return _context.Set<CourseUserRelation>().Where(c => c.CourseId == courseId && c.UserId == userId).FirstOrDefault();
        }

        public void RemoveCourseUserRelation(int courseId, string userId)
        {
            CourseUserRelation r = _context.Set<CourseUserRelation>().Where(c => c.CourseId == courseId && c.UserId == userId).FirstOrDefault();
            _context.Set<CourseUserRelation>().Remove(r);
            _context.SaveChanges();
        }

        public IEnumerable<CourseUserRelation> GetCourseUserRelationsWithUserId(string userId)
        {
            return _context.Set<CourseUserRelation>().Where(c => c.UserId == userId);
        }
    }
}
