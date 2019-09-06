using ReaLearn_Core.Data;
using ReaLearn_Core.Models;
using ReaLearn_Core.Models.VRObjectModels;
using ReaLearn_Core.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReaLearn_Core.Repositories
{
    public class VRObjectRepository : Repository<VRObject>, IVRObjectRepository
    {
        private ApplicationDbContext _context { get; set; }
        public VRObjectRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
         
        }

        public IEnumerable<VRObject> GetVRObjectsWithSceneId(int id)
        {
            return _context.Set<VRObject>().Where(c => c.SceneId == id);
        }


        public void ReplaceVRImageObject(byte[] p1, int objectId)
        {
            var VrImageObject = _context.Set<VRObject>().Where(c => c.Id == objectId).FirstOrDefault();
            if (VrImageObject != null)
            {
                VrImageObject.Value = System.Convert.ToBase64String(p1);
            }
            _context.SaveChanges();
        }

        public void AddHotSpotObject(VRHotspot hotspotObject)
        {
            _context.Add(hotspotObject);
            _context.SaveChanges();
        }

        public IEnumerable<VRHotspot> GetVRHotspotsWithSceneId(int id)
        {
            return _context.Set<VRHotspot>().Where(c => c.SceneId == id);
        }

        public void AddQuestionObject(VRQuestionCard vrQuestion)
        {
            _context.Add(vrQuestion);
            _context.SaveChanges();
        }

        public IEnumerable<VRQuestionCard> GetVRQuestionsWithSceneId(int id)
        {
            return _context.Set<VRQuestionCard>().Where(c => c.SceneId == id);
        }

        public void AddResponse(VRQuestionResponse r)
        {
            _context.Set<VRQuestionResponse>().Add(r);
            _context.SaveChanges();
        }

        public void UpdateVRObjectAssetName(int id, string assetName)
        {
            _context.Set<VRObject>().Where(c => c.Id == id).FirstOrDefault().AssetName = assetName;
            _context.SaveChanges();
        }

        public VRQuestionResponse getResponse(int responseId)
        {
            return _context.Set<VRQuestionResponse>().Where(c => c.id == responseId).FirstOrDefault();
        }

        public void UpdateResponse(int responseId, string responseText)
        {
            _context.Set<VRQuestionResponse>().Where(c => c.id == responseId).FirstOrDefault().Response = responseText;
            _context.SaveChanges();
        }

        public IEnumerable<VRQuestionResponse> GetVRQuestionresponsesWithQuestionId(int id)
        {
           return _context.Set<VRQuestionResponse>().Where(c => c.VRQuestionId == id);
        }

        public void UpdateVRObject(int vrObjectId, VRObject vrObject)
        {
            var result =  _context.Set<VRObject>().Where(c => c.Id == vrObjectId).FirstOrDefault();
            if (result.ObjectType == "QuestionObject")
            {
                result.xScale = 2;
                result.yScale = 2;
                result.zScale = 0.1;
            }

            result.xPos = vrObject.xPos; result.yPos = vrObject.yPos; result.zPos = vrObject.zPos;
            result.xScale = vrObject.xScale; result.yScale = vrObject.yScale; result.zScale = vrObject.zScale;
            result.xRot = vrObject.xRot; result.yRot = vrObject.yRot; result.zRot = vrObject.zRot;
            result.Colour = vrObject.Colour;

            if (result.ObjectType == "TextObject" || result.ObjectType == "HotSpotObject" || result.ObjectType == "QuestionObject")
            {
                result.Value = vrObject.Value;
            }

            _context.SaveChanges();
        }
    }
}
