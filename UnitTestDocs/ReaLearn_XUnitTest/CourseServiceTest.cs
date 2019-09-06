using ReaLearn_Core.Models;
using ReaLearn_Core.Repositories.Abstract;
using ReaLearn_Core.Services;
using System;
using Xunit;
using Moq;
using ReaLearn_Core.Services.Abstract;
using System.Collections.Generic;
using ReaLearn_Core.Models.ViewModels;

namespace ReaLearn_XUnitTest
{
    public class CourseServiceTest
    {
        private readonly CourseService _courseService;

        Course expectedCourse = new Course() { Name = "Added Course" , Id=0};

        public CourseServiceTest()
        {
            var _courseRepository = new Mock<ICourseRepository>();
            var _sceneService = new Mock<ISceneService>();
            var _backgroundService = new Mock<IVRBackgroundService>();


            _courseService = new CourseService(_courseRepository.Object, _sceneService.Object, _backgroundService.Object);

            _courseRepository.Setup(x => x.GetCourseNameWithCourseId(0)).Returns("Course Name");
            _courseRepository.Setup(x => x.Get(0)).Returns(expectedCourse);
        }

        /*
         * TESTS GET COURSE NAME WITH COURSE ID
         * EXPECTED TO RETURN EQUAL 
         */
        [Fact]
        public void TestGetCourseNameWithCourseId_Success()
        {
            string courseName = _courseService.GetCourseNameWithCourseId(0);
            Assert.Equal("Course Name", courseName);
        }


        /*
        * TESTS GET COURSE NAME WITH COURSE ID WITH THE WRONG VALUE
        * EXPECTED TO RETURN NOT EQUAL 
        */
        [Fact]
        public void TestGetCourseNameWithCourseId_TooHigh()
        {
            string courseName = _courseService.GetCourseNameWithCourseId(2);
            Assert.NotEqual("Course Name", courseName);
        }

        /*
        * TESTS GET COURSE NAME WITH COURSE ID WITH A NEGATIVE VALUE
        * EXPECTED TO RETURN NOT EQUAL 
        */
        [Fact]
        public void TestGetCourseNameWithCourseId_TooLow()
        {
            string courseName = _courseService.GetCourseNameWithCourseId(-999999999);
            Assert.NotEqual("Course Name", courseName);
        }

        /*
      * TESTS GET COURSE NAME WITH COURSE ID WITH A NEGATIVE VALUE
      * EXPECTED TO RETURN Null
      */
        [Fact]
        public void TestGetCourseNameWithCourseId_Null()
        {
            string courseName = _courseService.GetCourseNameWithCourseId(-999999999);
            Assert.Null(courseName);
        }


        /*
        * TESTS GET COURSES NAME WITH COURSE IDs
        * EXPECTED TO RETURN EQUAL
        */
        [Fact]
        public void TestGetCoursesWithCourseIds_Success()
        {
            List<int> ids = new List<int>(new int[] { 0,0,0 });

            IEnumerable<Course> expected = new List<Course>(new Course[] { expectedCourse, expectedCourse, expectedCourse });
            var result = _courseService.GetCoursesWithCourseIds(ids);
            Assert.Equal(expected, result);
        }

        /*
          * TESTS GET COURSES WITH COURSE IDS WITH FIRST ID BEING INCORRECT
          * EXPECTED TO RETURN TWO COURSES WTIHIN IENUMERABLE
          * EXPECTED EQUAL
          */
        [Fact]
        public void TestGetCoursesWithCourseIds_WrongId1()
        {
            List<int> ids = new List<int>(new int[] { 1, 0, 0 });
            IEnumerable<Course> expected = new List<Course>(new Course[] { expectedCourse, expectedCourse });
            var result = _courseService.GetCoursesWithCourseIds(ids);
            Assert.Equal(expected, result);
        }

        /*
          * TESTS GET COURSES WITH COURSE IDS WITH SECOND ID BEING INCORRECT
          * EXPECTED TO RETURN TWO COURSES WTIHIN IENUMERABLE
          * EXPECTED EQUAL
          */
        [Fact]
        public void TestGetCoursesWithCourseIds_WrongId2()
        {
            List<int> ids = new List<int>(new int[] { 0, 1, 0 });
            List<Course> expected = new List<Course>(new Course[] { expectedCourse, expectedCourse });
            var result = _courseService.GetCoursesWithCourseIds(ids);
            Assert.Equal(expected, result);
        }

        /*
          * TESTS GET COURSES WITH COURSE IDS WITH THIRD ID BEING INCORRECT
          * EXPECTED TO RETURN TWO COURSES WTIHIN IENUMERABLE
          * EXPECTED EQUAL
          */
        [Fact]
        public void TestGetCoursesWithCourseIds_WrongId3()
        {
            List<int> ids = new List<int>(new int[] { 0, 0, 1 });
            List<Course> expected = new List<Course>(new Course[] { expectedCourse, expectedCourse });
            var result = _courseService.GetCoursesWithCourseIds(ids);
            Assert.Equal(expected, result);
        }

        /*
          * TESTS GET COURSES WITH COURSE IDS WITH NO CORRECT IDS
          * EXPECTED TO RETURN TWO COURSES WTIHIN IENUMERABLE
          * EXPECTED EQUAL
          */
        [Fact]
        public void TestGetCoursesWithCourseIds_WrongIds_ShouldNull()
        {
            List<int> ids = new List<int>(new int[] { 1, 1, 1 });
            var result = _courseService.GetCoursesWithCourseIds(ids);
            Assert.Null(result);
        }

        /*
         * TESTS GET COURSES WITH COURSE IDS WITH NO CORRECT IDS
         * EXPECTED TO RETURN TWO COURSES WTIHIN IENUMERABLE
         * EXPECTED EQUAL
         */
        [Fact]
        public void TestGetCoursesWithCourseIds_NoInput_ShouldNull()
        {
            var result = _courseService.GetCoursesWithCourseIds(new List<int>());
            Assert.Null(result);
        }


        /*
         * TESTS ADD COURSE EXPECTED SUCCESSFUL
         */
        [Fact]
        public void TestAddCourse_Success()
        {
            RegisterCourseViewModel m = new RegisterCourseViewModel()
            {
                Name = "New Course Name",
                Description = "New Course Description"
            };

            Course c = _courseService.AddCourse(m, 5);

            // Tests that the newly added RegisterCourseViewModel name is correctly returned after adding
            Assert.Equal("New Course Name", c.Name);
        }

        /*
          * TESTS ADD COURSE EXPECTED NOT EQUAL
          * PASSING EMPTY REGISTER VIEW MODEL SHOULD RETURN NULL
          */
        [Fact]
        public void TestAddCourse_EmptyRegisterCourseViewModel_NotEqual()
        {
            RegisterCourseViewModel m = new RegisterCourseViewModel()
            {

            };

            Course c = _courseService.AddCourse(m, 5);

            // Tests that the newly added RegisterCourseViewModel name is correctly returned after adding
            Assert.NotEqual("New Course Name", c.Name);
        }

        /*
        * TESTS ADD COURSE EXPECTED NULL AS REGISTER COURSE VIEW MODEL IS EMPTY
        */
        [Fact]
        public void TestAddCourse_EmptyRegisterCourseViewModel_Null()
        {
            RegisterCourseViewModel m = new RegisterCourseViewModel()
            {

            };

            Course c = _courseService.AddCourse(m, 5);

            // Tests that the newly added RegisterCourseViewModel name is correctly returned after adding
            Assert.Null(c.Name);
        }
    }
}
