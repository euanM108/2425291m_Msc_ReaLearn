using ReaLearn_Core.Models;
using ReaLearn_Core.Models.VRObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReaLearn_Core.Repositories.Abstract
{
    public interface IVRObjectRepository : IRepository<VRObject>
    {
        IEnumerable<VRObject> GetVRObjectsWithSceneId(int id);

        void ReplaceVRImageObject(byte[] p1, int objectId);
        void AddHotSpotObject(VRHotspot hotspotObject);
        IEnumerable<VRHotspot> GetVRHotspotsWithSceneId(int id);
        void AddQuestionObject(VRQuestionCard vrQuestion);
        IEnumerable<VRQuestionCard> GetVRQuestionsWithSceneId(int id);

        void AddResponse(VRQuestionResponse r);
        void UpdateVRObjectAssetName(int id, string assetName);
        VRQuestionResponse getResponse(int responseId);
        void UpdateResponse(int responseId, string responseText);

        IEnumerable<VRQuestionResponse> GetVRQuestionresponsesWithQuestionId(int id);
        void UpdateVRObject(int vrObjectId, VRObject vrObject);
    }
}
