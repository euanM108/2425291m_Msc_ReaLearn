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
using ReaLearn_Core.Models.VRObjectModels;

namespace ReaLearn_XUnitTest
{
    public class VRObjectServiceTest
    {
        private readonly VRObjectService _objectService;
        VRQuestionResponse exepectedResponse = new VRQuestionResponse() { Response = "Expected" };

        VRObject expectedObject = new VRObject();
        IEnumerable<VRQuestionResponse> expectedQuestionResponses = new List<VRQuestionResponse>(new VRQuestionResponse[] { new VRQuestionResponse() {Response = "Response One" }, new VRQuestionResponse() { Response = "Response Two" } });
        IEnumerable<VRQuestionCard> expectedQuestions = new List<VRQuestionCard>(new VRQuestionCard[] { new VRQuestionCard() { AssetName = "Question One" }, new VRQuestionCard() { AssetName = "Question Two" } });

        public VRObjectServiceTest()
        {
            var _objectRepo = new Mock<IVRObjectRepository>();


            _objectService = new VRObjectService(_objectRepo.Object);

            _objectRepo.Setup(x => x.GetVRQuestionresponsesWithQuestionId(0)).Returns(expectedQuestionResponses);
            _objectRepo.Setup(x => x.getResponse(0)).Returns(exepectedResponse);
            _objectRepo.Setup(x => x.Get(0)).Returns(expectedObject);
            _objectRepo.Setup(x => x.GetVRQuestionsWithSceneId(0)).Returns(expectedQuestions);
        }

        /*
          * TESTS GET VR QUESTION RESPONSES WITH QUESTION ID 
          * EXPECTED:  EQUAL - CORRECT ID IS SENT 
          */
        [Fact]
        public void TestGetVRQuestionResponsesWithQuestionId_Success()
        {
            IEnumerable<VRQuestionResponse> result = _objectService.GetVRQuestionresponsesWithQuestionId(0);
            Assert.Equal(expectedQuestionResponses, result);
        }

        /*
           * TESTS GET VR QUESTION RESPONSES WITH QUESTION ID 
           * EXPECTED:  NOT EQUAL - WRONG ID IS SENT 
           */
        [Fact]
        public void TestGetVRQuestionResponsesWithQuestionId_WrongID()
        {
            IEnumerable<VRQuestionResponse> result = _objectService.GetVRQuestionresponsesWithQuestionId(1);
            Assert.NotEqual(expectedQuestionResponses, result);
        }

        /*
       * TESTS GET VR QUESTION RESPONSES WITH QUESTION ID 
       * EXPECTED:  NULL - WRONG ID IS SENT - SHOULD RETURN NULL IF NOT FOUND
       */
        [Fact]
        public void TestGetVRQuestionResponsesWithQuestionId_WrongID_ShouldBeNull()
        {
            IEnumerable<VRQuestionResponse> result = _objectService.GetVRQuestionresponsesWithQuestionId(1);
            Assert.Null(result);
        }


        /*
       * TESTS GET VR OBJECT WITH VR OBJECT ID 
       * EXPECTED:  EQUAL - CORRECT ID IS SENT 
       */
        [Fact]
        public void TestGetVROBject_Success()
        {
            VRObject result = _objectService.GetVROBject(0);
            Assert.Equal(expectedObject, result);
        }

        /*
       * TESTS GET VR OBJECT WITH VR OBJECT ID 
       * EXPECTED:  NOT EQUAL - WRONG ID IS SENT 
       */
        [Fact]
        public void TestGetVROBject_IncorrectID()
        {
            VRObject result = _objectService.GetVROBject(1);
            Assert.NotEqual(expectedObject, result);
        }


        /*
       * TESTS GET VR OBJECT WITH VR OBJECT ID 
       * EXPECTED:  NULL - WRONG ID IS SENT - SHOULD RETURN NULL IF NOT FOUND
       */
        [Fact]
        public void TestGetVROBject_IncorrectID_ShouldBeNull()
        {
            VRObject result = _objectService.GetVROBject(1);
            Assert.Null(result);
        }
    }
}
