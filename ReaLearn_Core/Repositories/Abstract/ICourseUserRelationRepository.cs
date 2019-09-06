using ReaLearn_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReaLearn_Core.Repositories.Abstract
{
    public interface ICourseUserRelationRepository : IRepository<CourseUserRelation>
    {
        IEnumerable<CourseUserRelation> GetCourseUserRelationsWithCourseId(int courseId);
        void AssignCourseToUser(CourseUserRelation relation);
        CourseUserRelation GetRelationsWithCourseAndUserId(int courseId, string userId);
        void RemoveCourseUserRelation(int courseId, string userId);
        IEnumerable<CourseUserRelation> GetCourseUserRelationsWithUserId(string userId);
    }
}
