using ReaLearn_Core.Models;
using ReaLearn_Core.Repositories.Abstract;
using ReaLearn_Core.Services;
using System;
using Xunit;
using Moq;
using ReaLearn_Core.Services.Abstract;
using System.Collections.Generic;
using ReaLearn_Core.Models.ViewModels;
using ReaLearn_Core.Models.VRObjectModels;

namespace ReaLearn_XUnitTest
{
    public class BackgroundImageServiceTest
    {
        private readonly VRBackgroundService _backgroundService;

        byte[] returnedImage = new byte[] { 0, 1, 3, 6, 21, 6, 13, 2 };
        VRBackground expectedBackground = new VRBackground() { Colour = "#FFFFFF" };
    
        public BackgroundImageServiceTest()
        {

            var _backgroundRepo = new Mock<IVRBackgroundRepository>();
            var _sceneService = new Mock<ISceneService>();

            _backgroundService = new VRBackgroundService(_backgroundRepo.Object, _sceneService.Object);

            _backgroundRepo.Setup(x => x.getBackgroundImageBytesWithSceneId(0)).Returns(returnedImage);
            _backgroundRepo.Setup(x => x.getBackgroundWithSceneId(0)).Returns(expectedBackground);
        }

        /*
         * TESTS GET BACKGROUND IMAGES WITH SCENE ID
         * EXPECTED: SUCCESSFUL - PASSING CORRECT ID
         */
        [Fact]
        public void TestGetBackgroundImageWithSceneId_Success()
        {
            byte[] backgroundImageResult = _backgroundService.getBackgroundImageWithSceneId(0);
            Assert.Equal(returnedImage, backgroundImageResult);
        }

        /*
     * TESTS GET BACKGROUND IMAGE WITH SCENE ID
     * EXPECTED: NOT EQUAL - PASSING WRONG ID
     */
        [Fact]
        public void TestGetBackgroundImageWithSceneId_IncorrectID()
        {
            byte[] backgroundImageResult = _backgroundService.getBackgroundImageWithSceneId(1);
            Assert.NotEqual(returnedImage, backgroundImageResult);
        }

        /*
    * TESTS GET BACKGROUND IMAGE WITH SCENE ID
    * EXPECTED: NULL - PASSING WRONG ID
    */
        [Fact]
        public void TestGetBackgroundImageWithSceneId_ShouldBeNull()
        {
            byte[] backgroundImageResult = _backgroundService.getBackgroundImageWithSceneId(1);
            Assert.Null(backgroundImageResult);
        }

        /*
    * TESTS GET BACKGROUND IMAGES WITH SCENE IDS
    * EXPECTED: EQUAL + SUCCESSFUL: ALL IDS ARE CORRECT
    */
        [Fact]
        public void TestGetBackgroundImagesWithSceneIds_Success()
        {
            List<int> ids = new List<int>(new int[] { 0, 0, 0 });

            IEnumerable<VRBackground> expected = new List<VRBackground>(new VRBackground[] { expectedBackground, expectedBackground, expectedBackground });
            var result = _backgroundService.getBackgroundImagesWithSceneIds(ids);
            Assert.Equal(expected, result);
        }

        /*
         * TESTS GET BACKGROUND IMAGES WITH SCENE IDS 
         * EXPECTED: EQUAL - AN LIST OF VRBACKGROUND IMAGES WHERE ONE IS NULL, TWO ARE NOT
         */
        [Fact]
        public void TestGetBackgroundImagesWithSceneIds_IncorrectId1()
        {
            List<int> ids = new List<int>(new int[] { 1, 0, 0 });

            List<VRBackground> expected = new List<VRBackground>(new VRBackground[] { null, expectedBackground, expectedBackground });
            var result = _backgroundService.getBackgroundImagesWithSceneIds(ids);
            Assert.Equal(expected, result);
        }

        /*
         * TESTS GET BACKGROUND IMAGES WITH SCENE IDS 
         * EXPECTED: EQUAL - AN LIST OF VRBACKGROUND IMAGES WHERE ONE IS NULL, TWO ARE NOT
         */
        [Fact]
        public void TestGetBackgroundImagesWithSceneIds_IncorrectId2()
        {
            List<int> ids = new List<int>(new int[] { 0, 1, 0 });
            List<VRBackground> expected = new List<VRBackground>(new VRBackground[] { expectedBackground, null, expectedBackground });
            var result = _backgroundService.getBackgroundImagesWithSceneIds(ids);
            Assert.Equal(expected, result);
        }

        /*
         * TESTS GET BACKGROUND IMAGES WITH SCENE IDS 
         * EXPECTED: EQUAL - AN LIST OF VRBACKGROUND IMAGES WHERE ONE IS NULL, TWO ARE NOT
         */
        [Fact]
        public void TestGetBackgroundImagesWithSceneIds_IncorrectId3()
        {
            List<int> ids = new List<int>(new int[] { 0, 0, 1 });
            List<VRBackground> expected = new List<VRBackground>(new VRBackground[] { expectedBackground, expectedBackground, null });
            var result = _backgroundService.getBackgroundImagesWithSceneIds(ids);
            Assert.Equal(expected, result);
        }

        /*
         * TESTS GET BACKGROUND IMAGES WITH SCENE IDS 
         * EXPECTED: EQUAL - AN LIST OF VRBACKGROUND IMAGES WHERE TWO ARE NULL, ONE IS NOT
         */
        [Fact]
        public void TestGetBackgroundImagesWithSceneIds_TwoCorrect()
        {
            List<int> ids = new List<int>(new int[] { 0, 1, 1 });
            List<VRBackground> expected = new List<VRBackground>(new VRBackground[] { expectedBackground, null, null });
            var result = _backgroundService.getBackgroundImagesWithSceneIds(ids);
            
            Assert.Equal(expected, result);
        }


        /*
         * TESTS GET BACKGROUND IMAGES WITH SCENE IDS 
         * EXPECTED: EQUAL - AN LIST OF VRBACKGROUND IMAGES WHERE ALL ARE NULL AS THE WRONG IDS ARE SENT
         */
        [Fact]
        public void TestGetBackgroundImagesWithSceneIds_ShouldBeListOfNulls()
        {
            List<int> ids = new List<int>(new int[] { 1, 1, 1 });
            List<VRBackground> expected = new List<VRBackground>(new VRBackground[] { null, null, null });
            var result = _backgroundService.getBackgroundImagesWithSceneIds(ids);

            Assert.Equal(expected, result);
        }
    }
}
