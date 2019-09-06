using Microsoft.AspNetCore.Http;
using ReaLearn_Core.Models;
using ReaLearn_Core.Models.VRObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReaLearn_Core.Services.Abstract
{
    public interface IVRObjectService
    {
        void AddVRTextObject(string text, int sceneId, string assetName);

        IEnumerable<VRObject> GetVROBjectsWithSceneId(int id);
        VRObject GetVROBject(int vrObjectId);
        void UpdateVRObject(int vrObjectId, double xPos, double yPos, double zPos, double xScale, double yScale, double zScale, int xRot, int yRot, int zRot, string value, string colour);
        void AddVRImageObject(IFormFile file, int sceneId, string assetName);
        void DeleteVRObject(int objectId);
        IEnumerable<VRQuestionCard> GetVRQuestionsWithSceneId(int sceneId);
        void AddVideoObject(string videoUrl, int sceneId, string assetName);
        void AddHotSpotObject(int SceneId, int Linked, string Action, bool onClick, string assetName);
        void ReplaceVRImageObject(IFormFile file, int objectId);
        void AddVRObject(VRObject backgroundObject);
        IEnumerable<VRHotspot> GetVRHotspotsWithSceneId(int id); 
        void AddAudio(string fileName, int sceneId, string assetName);
        void AddQuestion(int sceneId, string question, string responseOneText, string responseTwoText, string responseThreeText, string responseFourText, string responseOneCorrect, string responseTwoCorrect, string responseThreeCorrect, string responseFourCorrect);
        void UpdateAssetName(int id, string assetName);
        void UpdateResponse(int responseId, string responseText);
        IEnumerable<VRQuestionResponse> GetVRQuestionresponsesWithQuestionId(int id);
    }
}
