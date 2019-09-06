using ReaLearn_Core.Models;
using ReaLearn_Core.Repositories.Abstract;
using ReaLearn_Core.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReaLearn_Core.Services
{
    public class CourseUserRelationService : ICourseUserRelationService
    {
        private readonly IUserService _userService;
        private readonly ICourseService _courseService;
        private readonly ICourseUserRelationRepository _courseUserRelationRepository;
        public CourseUserRelationService(ICourseService courseService, ICourseUserRelationRepository courseUserRelationRepository, IUserService userService)
        {
            _courseService = courseService;
            _courseUserRelationRepository = courseUserRelationRepository;
            _userService = userService;
        }

        public void AssignCourseToUser(int courseId, string userId, bool isAssigned)
        {
            if (_courseService.GetCourse(courseId) != null)
            {
                if (isAssigned)
                {
                    var i = _courseUserRelationRepository.GetRelationsWithCourseAndUserId(courseId, userId);

                    if (i == null)
                    {
                        // Only add the relation if there isn't already one in the database
                        CourseUserRelation relation = new CourseUserRelation()
                        {
                            CourseId = courseId,
                            UserId = userId,
                        };
                        _courseUserRelationRepository.AssignCourseToUser(relation);
                    }
                }
                else
                {
                    // If user previously had relation and checkbox isn't selected on submission, remove the user
                    var i = _courseUserRelationRepository.GetRelationsWithCourseAndUserId(courseId, userId);

                    if (i != null)
                    {
                        _courseUserRelationRepository.RemoveCourseUserRelation(courseId, userId);
                    }
                }
            }
        }

        public IEnumerable<CourseUserRelation> GetCourseUserRelationsWithCourseId(int courseId)
        {
            if(_courseService.GetCourse(courseId) != null)
            {
                return _courseUserRelationRepository.GetCourseUserRelationsWithCourseId(courseId);
            }

            return null;
        }

        public IEnumerable<CourseUserRelation> GetCourseUserRelationsWithUserId(string userId)
        {
            if (_userService.GetUser(userId) != null)
            {
                return _courseUserRelationRepository.GetCourseUserRelationsWithUserId(userId);
            }

            return null;
        }
    }
}
