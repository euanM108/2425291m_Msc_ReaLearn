using ReaLearn_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReaLearn_Core.Services.Abstract
{
    public interface ICourseUserRelationService
    {
        IEnumerable<CourseUserRelation> GetCourseUserRelationsWithCourseId(int courseId);
        void AssignCourseToUser(int courseId, string userId, bool isAssigned);
        IEnumerable<CourseUserRelation> GetCourseUserRelationsWithUserId(string userId);
    }
}
