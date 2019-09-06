using Microsoft.AspNetCore.Http;
using ReaLearn_Core.Models;
using ReaLearn_Core.Models.VRObjectModels;
using ReaLearn_Core.Repositories.Abstract;
using ReaLearn_Core.Services.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaLearn_Core.Services
{
    public class VRObjectService : IVRObjectService
    {
        private readonly IVRObjectRepository _VRObjectRepository;
        public VRObjectService(IVRObjectRepository VRObjectRepository)
        {
            _VRObjectRepository = VRObjectRepository;
        }

        public void AddAudio(string fileName, int sceneId, string assetName)
        {
            VRObject audioObject = new VRObject()
            {
                AssetName = assetName,
                ObjectType = "AudioObject",
                Value = fileName,
                SceneId = sceneId,
                Colour = "#FFFFFF",
                xPos = 0,
                yPos = 0.5,
                zPos = -1,
                xScale = 1,
                yScale = 1,
                zScale = 1,
            };

            _VRObjectRepository.Add(audioObject);
        }

        public void AddHotSpotObject(int SceneId, int Linked, string Action, bool onClick, string assetName)
        {
            VRHotspot hotSpotObject = new VRHotspot()
            {
                AssetName = assetName,
                ObjectType = "HotSpotObject",
                Value = Linked.ToString(),
                SceneId = SceneId,
                Colour = "#FFFFFF",
                xPos = 0,
                yPos = 0.5,
                zPos = -1,
                xScale = 2,
                yScale = 2,
                zScale = 2,
                Action = Action,
                OnClick = onClick
            };

            _VRObjectRepository.AddHotSpotObject(hotSpotObject);
        }

        public void AddQuestion(int sceneId, string question, string responseOneText, string responseTwoText, string responseThreeText, string responseFourText, string responseOneCorrect, string responseTwoCorrect, string responseThreeCorrect, string responseFourCorrect)
        {
            bool ROne = false;
            bool RTwo = false;
            bool RThree = false;
            bool RFour = false;
            if (responseOneCorrect.Equals("true"))
            {
                ROne = true;
            }
            else if (responseTwoCorrect.Equals("true"))
            {
                RTwo = true;
            }
            else if (responseThreeCorrect.Equals("true"))
            {
                RThree = true;
            }
            else if (responseFourCorrect.Equals("true"))
            {
                RFour = true;
            }

            VRQuestionCard vrQuestion = new VRQuestionCard()
            {
                AssetName = "Question Card",
                ObjectType = "QuestionObject",
                SceneId = sceneId,
                Colour = "#FFFFFF",
                xPos = 0,
                yPos = 0.5,
                zPos = -1,
                xScale = 2,
                yScale = 2,
                zScale = 2,
                Value = question,

            };

            _VRObjectRepository.AddQuestionObject(vrQuestion);

            List<VRQuestionResponse> responses = new List<VRQuestionResponse>();
            if (responseOneText != null)
            {
                responses.Add(new VRQuestionResponse()
                {
                    VRQuestionId = vrQuestion.Id,
                    Response = responseOneText,
                    isCorrect = ROne
                }
                );
            }
            if (responseTwoText != null)
            {
                responses.Add(new VRQuestionResponse()
                {
                    VRQuestionId = vrQuestion.Id,
                    Response = responseTwoText,
                    isCorrect = RTwo

                });
                
            }
            if (responseThreeText != null)
            {
                responses.Add(new VRQuestionResponse()
                {
                    VRQuestionId = vrQuestion.Id,
                    Response = responseThreeText,
                    isCorrect = RThree
                });
            }
        
            if (responseThreeText != null)
            {
                responses.Add(new VRQuestionResponse()
                {
                    VRQuestionId = vrQuestion.Id,
                    Response = responseFourText,
                    isCorrect = RFour
                });
            }

            foreach(VRQuestionResponse r in responses)
            {
                _VRObjectRepository.AddResponse(r);
            }
        }

        public void AddVideoObject(string filePath, int sceneId, string assetName)
        {
            VRObject videoObject = new VRObject()
            {
                AssetName = assetName,
                ObjectType = "VideoObject",
                Value = filePath,
                SceneId = sceneId,
                Colour = "#FFFFFF",
                xPos = 0,
                yPos = 0.5,
                zPos = -1,
                xScale = 2,
                yScale = 2,
                zScale = 2
            };

            _VRObjectRepository.Add(videoObject);
        }

        public void AddVRImageObject(IFormFile file, int sceneId, string assetName)
        {
            byte[] p1 = null;
            using (var fs1 = file.OpenReadStream())
            using (var ms1 = new MemoryStream())
            {
                fs1.CopyTo(ms1);
                p1 = ms1.ToArray();
            }

            VRObject imageObject = new VRObject()
            {
                AssetName = assetName,
                ObjectType = "ImageObject",
                Value = System.Convert.ToBase64String(p1),
                SceneId = sceneId,
                Colour = "#FFFFFF",
                xPos = 0,
                yPos = 0.5,
                zPos = -1,
                xScale = 2,
                yScale = 2,
                zScale = 2
            };

            _VRObjectRepository.Add(imageObject);
        }

        public void AddVRObject(VRObject backgroundObject)
        {
            _VRObjectRepository.Add(backgroundObject);
        }

        public void AddVRTextObject(string Text, int SceneId, string assetName)
        {
            VRObject textObject = new VRObject()
            {
                AssetName = assetName,
                ObjectType = "TextObject",
                Value = Text,
                SceneId = SceneId,
                Colour = "#000000",
                xPos = 0,
                yPos = 0.5,
                zPos = -1,
                xScale = 4,
                yScale = 4,
                zScale = 4,
                xRot = 0,
                yRot = 0,
                zRot = 0
            };
            _VRObjectRepository.Add(textObject);
        }

        public void DeleteVRObject(int objectId)
        {
            
            VRObject vrObject = _VRObjectRepository.Get(objectId);
            if (vrObject != null)
            {
                _VRObjectRepository.Remove(vrObject);
            }
        }

        public IEnumerable<VRHotspot> GetVRHotspotsWithSceneId(int id)
        {
            IEnumerable<VRHotspot> vrHotspots = _VRObjectRepository.GetVRHotspotsWithSceneId(id);
            if (vrHotspots != null)
            {
                return vrHotspots;
            }
            return null;
        }
        public IEnumerable<VRQuestionCard> GetVRQuestionsWithSceneId(int id)
        {
            IEnumerable<VRQuestionCard> vrQuestions = _VRObjectRepository.GetVRQuestionsWithSceneId(id);
            if (vrQuestions != null)
            {
                return vrQuestions;
            }
            return null;
        }
        public VRObject GetVROBject(int vrObjectId)
        {
            VRObject vrObject = _VRObjectRepository.Get(vrObjectId);
            if (vrObject != null)
            {
                return vrObject;
            }
            else { return null; }
        }

        public IEnumerable<VRObject> GetVROBjectsWithSceneId(int id)
        {
            IEnumerable<VRObject> vrObjects = _VRObjectRepository.GetVRObjectsWithSceneId(id);
            if (vrObjects != null)
            {
                return vrObjects;
            }
            return null;
        }

        public void ReplaceVRImageObject(IFormFile file, int objectId)
        {
            if (file != null) {
                byte[] p1 = null;
                using (var fs1 = file.OpenReadStream())
                using (var ms1 = new MemoryStream())
                {
                    fs1.CopyTo(ms1);
                    p1 = ms1.ToArray();
                }

                VRObject vrObject = _VRObjectRepository.Get(objectId);
                if (vrObject != null)
                {
                    _VRObjectRepository.ReplaceVRImageObject(p1, objectId);
                }
            }
        }

        public void UpdateVRObject(int vrObjectId, double xPos, double yPos, double zPos, double xScale, double yScale, double zScale, int xRot, int yRot, int zRot, string value, string colour)
        {
            VRObject vrObject = _VRObjectRepository.Get(vrObjectId);
            if (vrObject != null)
            {
                if (vrObject.ObjectType == "QuestionObject")
                {
                    xScale = 2;
                    yScale = 2;
                    zScale = 0.1;
                }

                vrObject.xPos = xPos; vrObject.yPos = yPos; vrObject.zPos = zPos;
                vrObject.xScale = xScale; vrObject.yScale = yScale; vrObject.zScale = zScale;
                vrObject.xRot = xRot; vrObject.yRot = yRot; vrObject.zRot = zRot;
                vrObject.Colour = colour;

                if (vrObject.ObjectType == "TextObject" || vrObject.ObjectType == "HotSpotObject" || vrObject.ObjectType == "QuestionObject")
                {
                    vrObject.Value = value;
                }

                _VRObjectRepository.UpdateVRObject(vrObjectId, vrObject);

            }
        }

        public void UpdateAssetName(int id, string assetName)
        {
            if(_VRObjectRepository.Get(id) != null){
                _VRObjectRepository.UpdateVRObjectAssetName(id, assetName);
            }
        }

        public void UpdateResponse(int responseId, string responseText)
        {
           if ( _VRObjectRepository.getResponse(responseId) != null)
            {
                _VRObjectRepository.UpdateResponse(responseId, responseText);
            }
        }

        public IEnumerable<VRQuestionResponse> GetVRQuestionresponsesWithQuestionId(int id)
        {
            if(_VRObjectRepository.Get(id) != null)
            {
                return _VRObjectRepository.GetVRQuestionresponsesWithQuestionId(id);
            }
            else
            {
                return null;
            }
        }

    }
}
