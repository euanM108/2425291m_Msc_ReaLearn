using ReaLearn_Core.Models;
using ReaLearn_Core.Repositories.Abstract;
using ReaLearn_Core.Services;
using System;
using Xunit;
using Moq;
using ReaLearn_Core.Services.Abstract;
using System.Collections.Generic;
using ReaLearn_Core.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace ReaLearn_XUnitTest
{
    public class SceneServiceTest
    {
        private readonly SceneService _sceneService;

        IEnumerable<Scene> scenes = new List<Scene>(new Scene[]{ new Scene(){ Title = "Scene Title One" }, new Scene(){ Title = "Scene Title Two" }});
        Scene scene = new Scene() { Title = "DemoForGetScene" };

        public SceneServiceTest()
        {
            var _sceneRepo = new Mock<ISceneRepository>();
            var _backgroundRepo = new Mock<IVRBackgroundRepository>();
            
            _sceneService = new SceneService(_sceneRepo.Object, _backgroundRepo.Object);
            
            _sceneRepo.Setup(x => x.GetScenesWithCourseId(0)).Returns(scenes);
            _sceneRepo.Setup(x => x.Get(0)).Returns(scene);
            _sceneRepo.Setup(x => x.GetSceneTitleWithSceneId(0)).Returns("Scene Title");
        }


        /*
         * TESTS GET SCENE WITH COURSE ID 
         * EXPECTED: SUCCESSUL AND EQUAL 
         */
        [Fact]
        public void TestGetScenesWithCourseId_Success()
        {
            IEnumerable<Scene> result = _sceneService.GetScenesWithCourseId(0);
            Assert.Equal(scenes, result);
        }

        /*
         * TESTS GET SCENE WITH COURSE ID 
         * EXPECTED: NOT EQUAL - WRONG ID IS SENT
         */
        [Fact]
        public void TestGetScenesWithCourseId_Incorrect_NoMatchingId()
        {
            IEnumerable<Scene> result = _sceneService.GetScenesWithCourseId(1);
            Assert.NotEqual(scenes, result);
        }
         
        /*
         * TESTS GET SCENE WITH COURSE ID 
         * EXPECTED: NULL - WRONG ID IS SENT - SHOULD RETURN NULL IF NOT FOUND
         */
        [Fact]
        public void TestGetScenesWithCourseId_ShouldBeNull()
        {
            IEnumerable<Scene> result = _sceneService.GetScenesWithCourseId(1);
            Assert.Null(result);
        }

        /*
     * TESTS GET SCENE WITH SCENE ID 
     * EXPECTED: EQUAL - CORRECT ID IS SENT
     */
        [Fact]
        public void TestGetScene_Success()
        {
            Scene result = _sceneService.GetScene(0);
            Assert.Equal(scene, result);
        }

        /*
     * TESTS GET SCENE WITH SCENE ID 
         * EXPECTED: NOT EQUAL - WRONG ID IS SENT
         */
        [Fact]
        public void TestGetScene_Incorrect_NoMatchingId()
        {
            Scene result = _sceneService.GetScene(1);
            Assert.NotEqual(scene, result);
        }

        /*
         * TESTS GET SCENE WITH SCENE ID 
         * EXPECTED: NULL - WRONG ID IS SENT - SHOULD RETURN NULL IF NOT FOUND
         */
        [Fact]
        public void TestGetScene_Incorrect_ShouldBeNull()
        {
            Scene result = _sceneService.GetScene(1);
            Assert.Null(result);
        }

        /*
        * TESTS GET SCENE TITLE WITH SCENE ID 
        * EXPECTED: EQUAL - CORRECT ID IS SENT
        */
        [Fact]
        public void TestGetSceneTitleWithSceneId_Success()
        {
            string result = _sceneService.GetSceneTitleWithSceneId(0);
            Assert.Equal("Scene Title", result);
        }

        /*
        * TESTS GET SCENE WITH SCENE ID 
        * EXPECTED: NOT EQUAL - WRONG ID IS SENT
        */

        [Fact]
        public void TestGetSceneTitleWithSceneId_Incorrect_WrongId()
        {
            string result = _sceneService.GetSceneTitleWithSceneId(1);
            Assert.NotEqual("Scene Title", result);
        }

        /*
          * TESTS GET SCENE WITH SCENE ID 
          * EXPECTED: NOT EQUAL - WRONG ID IS SENT - SHOULD RETURN NULL IF NOT FOUND
          */
        [Fact]
        public void TestGetSceneTitleWithSceneId_ShouldBeNull()
        {
            string result = _sceneService.GetSceneTitleWithSceneId(1);
            Assert.Null(result);
        }
    }
}
