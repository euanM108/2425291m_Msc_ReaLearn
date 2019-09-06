using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReaLearn_Core.Models;
using ReaLearn_Core.Models.ViewModels;
using ReaLearn_Core.Models.VRObjectModels;
using ReaLearn_Core.Services.Abstract;

namespace ReaLearn_Core.Controllers
{
    public class SceneEditorController : Controller
    {
        private readonly ISceneService _sceneService;
        private readonly IVRObjectService _VRObjectService;
        private readonly IVRBackgroundService _VRBackgroundService;

        public SceneEditorController(ISceneService sceneService,IVRObjectService VRObjectService, IVRBackgroundService VRBackgroundService)
        {
            _sceneService = sceneService;
            _VRObjectService = VRObjectService;
            _VRBackgroundService = VRBackgroundService;
        }

       
   

        [Authorize]
        public IActionResult SceneEditor(int courseId, int selectedIndex)
        {
            SceneEditorViewModel viewModel;
            IEnumerable<Scene> scenes = _sceneService.GetScenesWithCourseId(courseId);
            IEnumerable<VRObject> vRObjects = new List<VRObject>();
            IEnumerable<VRHotspot> vRHotspots = new List<VRHotspot>();
            IEnumerable<VRQuestionCard> vRQuestionCards = new List<VRQuestionCard>();
            List<int> sceneIds = new List<int>();

            viewModel = new SceneEditorViewModel()
            {
                CourseId = courseId,
                AddSceneViewModel = new AddSceneViewModel(),
            };

            if (scenes != null) {
                if (scenes.Count() > 0)
                {
                    if (_VRObjectService.GetVROBjectsWithSceneId(scenes.ElementAt(selectedIndex).Id) != null)
                    {
                        // If there are vr objects in the scene, return them
                        vRObjects = _VRObjectService.GetVROBjectsWithSceneId(scenes.ElementAt(selectedIndex).Id);
                    }
                    if (_VRObjectService.GetVRHotspotsWithSceneId(scenes.ElementAt(selectedIndex).Id) != null)
                    {
                        // If there are vrHotSpot objects in the scene, return them
                        vRHotspots = _VRObjectService.GetVRHotspotsWithSceneId(scenes.ElementAt(selectedIndex).Id);
                    }
                    if (_VRObjectService.GetVRQuestionsWithSceneId(scenes.ElementAt(selectedIndex).Id) != null)
                    {
                        // If there are vr Question objects in the scene, return them
                        vRQuestionCards = _VRObjectService.GetVRQuestionsWithSceneId(scenes.ElementAt(selectedIndex).Id);
                    }

                }
                // Return the scenes for the existing scenes component
                foreach (Scene scene in scenes)
                {
                    sceneIds.Add(scene.Id);
                }

                viewModel.Scenes = scenes;
                viewModel.SelectedScene = 0;

                IEnumerable<VRBackground> Backgrounds = _VRBackgroundService.getBackgroundImagesWithSceneIds(sceneIds);

            if (vRObjects != null && vRObjects.Count() != 0)
            {
                viewModel.VRObjects = vRObjects;
            }
            if (vRHotspots !=null && vRHotspots.Count() != 0)
            {
                viewModel.VRHotspots = vRHotspots;
            }
            if (vRQuestionCards != null && vRQuestionCards.Count() != 0)
            {
                var responses = getResponsesWithQuestionCards(vRQuestionCards);
                
                if (responses != null)
                {
                if (responses.Count() > 0)
                {
                    viewModel.Responses = responses;
                }
                }

                viewModel.VRQuestionCards = vRQuestionCards;
            }
            if (selectedIndex > 0)
            {
                viewModel.SelectedScene = selectedIndex;
            }
            if (Backgrounds != null)
            {
                viewModel.Backgrounds = Backgrounds;
            }
            }
            return View(viewModel);
        }

        // UPLOAD / ADDING METHODS
        [HttpPost]
        public IActionResult UploadBackgroundImage(IFormFile file, int sceneId)
        {
            // If the file isn't null
            if (file != null && file.Length > 0 && file.ContentType.StartsWith("image/"))
            {
                _VRBackgroundService.SaveBackground(file, sceneId);
            }
            // get the scene with sceneId
            var scene = _sceneService.GetScene(sceneId);

            var scenes = _sceneService.GetScenesWithCourseId(scene.CourseId);
            int index = scenes.ToList().IndexOf(scene);
            return RedirectToAction("SceneEditor", "SceneEditor", new { courseId = scene.CourseId, selectedIndex = index });

        }

        [HttpPost]
        public async Task<ActionResult> UploadFile(IFormFile file, int SceneId, string AssetName)
        {
            
            List<string> errors = new List<string>(); 
            if (file != null)
            {    // if the file type is an image store as vrimage object
                if (file.ContentType.StartsWith("image/"))
                {
                    _VRObjectService.AddVRImageObject(file, SceneId, AssetName);
                }

                else if (file.ContentType.StartsWith("audio/") || file.ContentType.StartsWith("video/"))
                {
                    // if it's video or audio, create media file
                    await CreateMediaFileAsync(file, SceneId, AssetName, file.ContentType);
                }
            }
            return Json(errors);
        }

        private async Task CreateMediaFileAsync(IFormFile file, int SceneId, string AssetName, string contentType)
        {
            string fileName = file.FileName;
            string MAKEDIR = null;

            // creates the correct directory name
            if (contentType.StartsWith("video/")){
                MAKEDIR = "VIDEO";
            }
            else if (contentType.StartsWith("audio/"))
            {
                MAKEDIR = "AUDIO";
            }

            // Finds the correct directory with either AUDIO or VIDEO 
            DirectoryInfo DIR = new DirectoryInfo("C:/MEDIA/" + MAKEDIR);

            // if directory doesn't exist, create it
            if (!DIR.Exists)
            {
                Directory.CreateDirectory("C:/MEDIA/" + MAKEDIR);
            }

            // filepath = new directory plus file name
            string filePath = @"" + DIR.ToString() + "/" + fileName;

            // if file name already exists, create new file name
            if (System.IO.File.Exists(filePath))
            {
                fileName = GetNextFileName(file.FileName);
            }

            // create new path with updated filename
            var path = Path.Combine(DIR.ToString(), fileName);

            // Create file in new file path
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Now that content has been added to directory, add the assets
            if (file.ContentType.StartsWith("audio/"))
            {
                _VRObjectService.AddAudio(fileName, SceneId, AssetName);
            }
            else if (file.ContentType.StartsWith("video/"))
            {
                _VRObjectService.AddVideoObject(fileName, SceneId, AssetName);
            }
            
        }
        [HttpPost]
        public void AddTextObject(string Text, int SceneId, string AssetName)
        {
            _VRObjectService.AddVRTextObject(Text, SceneId, AssetName);
        }
        [HttpPost]
        public void AddQuestionObject(int SceneId, string Question, string ResponseOneText, string ResponseTwoText, string ResponseThreeText, string ResponseFourText, string ResponseOneCorrect, string ResponseTwoCorrect, string ResponseThreeCorrect, string ResponseFourCorrect)
        {
            _VRObjectService.AddQuestion(SceneId, Question, ResponseOneText, ResponseTwoText, ResponseThreeText, ResponseFourText, ResponseOneCorrect, ResponseTwoCorrect, ResponseThreeCorrect, ResponseFourCorrect);
        }

        [HttpPost]
        public void AddHotSpotObject(int SceneId, int Linked, string Action, bool onClick, string AssetName)
        {
            // If the hotspot's virtual reality action is to link to another scene, get the scene and find its index within the course. This helps with linking the scenes together during export.
            if (Action == "link")
            {
                Scene scene = _sceneService.GetScene(Linked);
                List<Scene> scenes = _sceneService.GetScenesWithCourseId(scene.CourseId).ToList();
                Linked = scenes.IndexOf(scene);
            }
            _VRObjectService.AddHotSpotObject(SceneId, Linked, Action, onClick, AssetName);
        }

        [HttpPost]
        public Scene SaveScene(string title, int courseId)
        {
            Scene scene = new Scene()
            {
                Title = title,
                CourseId = courseId
            };

            _sceneService.AddScene(scene);

            return scene;
        }


        // GETTING METHODS
        private string GetNextFileName(string fileName)
        {
            string extension = Path.GetExtension(fileName);
            string pathName = Path.GetDirectoryName(fileName);
            string fileNameOnly = Path.Combine(pathName, Path.GetFileNameWithoutExtension(fileName));
            int i = 0;
            // If the file exists, keep trying until it doesn't
            while (System.IO.File.Exists(fileName))
            {
                i += 1;
                fileName = string.Format("{0}({1}){2}", fileNameOnly, i, extension);
            }
            return fileName;
        }


        // UPDATE METHODS
        [HttpPost]
        public void UpdateAssetName(int id, string assetName)
        {
            _VRObjectService.UpdateAssetName(id, assetName);
        }

        [HttpPost]
        public void UpdateVRObject(int vrObjectId, double xPos, double yPos, double zPos, double xScale, double yScale, double zScale, double xRot, double yRot, double zRot, string value, string colour, string isResponse, string isCorrect)
        {
            _VRObjectService.UpdateVRObject(vrObjectId, xPos, yPos, zPos, xScale, yScale, zScale, (int)xRot, (int)yRot, (int)zRot, value, colour);
        }

        [HttpPost]
        public void UpdateResponse(int responseId, string responseText)
        {
            _VRObjectService.UpdateResponse(responseId, responseText);
        }

        [HttpPost]
        public void ReplaceImage(IFormFile file, int objectId)
        {
            if (file != null)
            {
                _VRObjectService.ReplaceVRImageObject(file, objectId);
            }
        }
        [HttpPost]
        public void UpdateBackground(string colour, int sceneId)
        {
            _VRBackgroundService.UpdateColour(colour, sceneId);
        }

        public PartialViewResult UpdateScene(int courseId, int selectedIndex)
        {
            SceneEditorViewModel viewModel;

            IEnumerable<Scene> scenes = _sceneService.GetScenesWithCourseId(courseId);
            IEnumerable<VRObject> vRObjects = _VRObjectService.GetVROBjectsWithSceneId(scenes.ElementAt(selectedIndex).Id);
            IEnumerable<VRHotspot> vRHotspots = _VRObjectService.GetVRHotspotsWithSceneId(scenes.ElementAt(selectedIndex).Id);
            IEnumerable<VRQuestionCard> vRQuestionCards = _VRObjectService.GetVRQuestionsWithSceneId(scenes.ElementAt(selectedIndex).Id);

            List<int> sceneIds = new List<int>();
            foreach (Scene scene in scenes)
            {
                sceneIds.Add(scene.Id);
            }

            IEnumerable<VRBackground> BackgroundImages = _VRBackgroundService.getBackgroundImagesWithSceneIds(sceneIds);

            viewModel = new SceneEditorViewModel()
            {
                CourseId = courseId,
                AddSceneViewModel = new AddSceneViewModel(),

            };

            if (BackgroundImages != null)
            {
                viewModel.Backgrounds = BackgroundImages;
            }
            if (scenes.Count() != 0)
            {
                viewModel.Scenes = scenes;
                viewModel.SelectedScene = 0;

            }

            if (vRObjects != null && vRObjects.Count() != 0)
            {
                viewModel.VRObjects = vRObjects;
            }
            if (vRQuestionCards != null && vRQuestionCards.Count() != 0)
            {
                viewModel.VRQuestionCards = vRQuestionCards;
            }
            if (vRHotspots != null && vRHotspots.Count() != 0)
            {
                viewModel.VRHotspots = vRHotspots;
            }

            if (selectedIndex > 0)
            {
                viewModel.SelectedScene = selectedIndex;
            }
            if (viewModel.VRQuestionCards != null && viewModel.VRQuestionCards.Count() != 0)
            {
                var responses = getResponsesWithQuestionCards(viewModel.VRQuestionCards);

                if (responses != null)
                {
                    if (responses.Count() > 0)
                    {
                        viewModel.Responses = responses;
                    }
                }
            }

            return PartialView("_SceneCreation", viewModel);
        }

        public PartialViewResult UpdateHotspotModal(int sceneId)
        {

            SceneEditorViewModel viewModel = new SceneEditorViewModel()
            {
                VRObjects = _VRObjectService.GetVROBjectsWithSceneId(sceneId),
                VRQuestionCards = _VRObjectService.GetVRQuestionsWithSceneId(sceneId)
            };
            foreach (VRObject v in viewModel.VRObjects)
            {
                Console.WriteLine(v.AssetName);
            }

            return PartialView("_AddHotspotPartialModal", viewModel);
        }


        // DELETION METHODS
        [HttpPost]
        public void DeleteVRObject(int objectId)
        {
            VRObject vrObject = _VRObjectService.GetVROBject(objectId);
           
            _VRObjectService.DeleteVRObject(objectId);
        }

        [HttpPost]
        public void DeleteScene(int sceneId)
        {
            _sceneService.DeleteScene(sceneId);
        }

    
        // GETTING METHODS
        public PartialViewResult GetScenes(int courseId)
        {
            IEnumerable<Scene> scenes = _sceneService.GetScenesWithCourseId(courseId);
            List<int> sceneIds = new List<int>();

            foreach (Scene scene in scenes)
            {
                sceneIds.Add(scene.Id);
            }
            
            IEnumerable<VRBackground> Backgrounds = _VRBackgroundService.getBackgroundImagesWithSceneIds(sceneIds);
            SceneEditorViewModel viewModel = new SceneEditorViewModel()
            {
                CourseId = courseId,
                Scenes = scenes,
                Backgrounds = Backgrounds
            };

            return PartialView("_ExistingScenes", viewModel);
        }

        public PartialViewResult GetObjectsInScene(int sceneId)
        {
            SceneEditorViewModel viewModel = new SceneEditorViewModel()
            {
                VRObjects = _VRObjectService.GetVROBjectsWithSceneId(sceneId),
                VRHotspots = _VRObjectService.GetVRHotspotsWithSceneId(sceneId),
                VRQuestionCards = _VRObjectService.GetVRQuestionsWithSceneId(sceneId)
            };

            if (viewModel.VRQuestionCards != null && viewModel.VRQuestionCards.Count() != 0)
            if (viewModel.VRQuestionCards != null && viewModel.VRQuestionCards.Count() != 0)
            {
                var responses = getResponsesWithQuestionCards(viewModel.VRQuestionCards);

                if (responses != null)
                {
                    if (responses.Count() > 0)
                    {
                        viewModel.Responses = responses;
                    }
                }
            }
            return PartialView("_ObjectEditorCarousel", viewModel);
        }

        private IEnumerable<VRQuestionResponse> getResponsesWithQuestionCards(IEnumerable<VRQuestionCard> vRQuestionCards)
        {
            IEnumerable<VRQuestionResponse> tempResponses = new List<VRQuestionResponse>();
            List<VRQuestionResponse> responses = new List<VRQuestionResponse>();

            if (vRQuestionCards != null && vRQuestionCards.Count() > 0)
            {
                foreach (VRQuestionCard q in vRQuestionCards)
                {
                    tempResponses = _VRObjectService.GetVRQuestionresponsesWithQuestionId(q.Id);

                    foreach (VRQuestionResponse r in tempResponses)
                    {
                        responses.Add(r);
                    }
                }
            }

            if (responses != null && responses.Count() > 0)
            {
                return responses;
            }

            return null;
        }
    }
}
