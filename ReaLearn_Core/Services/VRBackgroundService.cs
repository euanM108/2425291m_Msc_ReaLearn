using Microsoft.AspNetCore.Http;
using ReaLearn_Core.Models;
using ReaLearn_Core.Models.VRObjectModels;
using ReaLearn_Core.Repositories.Abstract;
using ReaLearn_Core.Services.Abstract;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ReaLearn_Core.Services
{
    public class VRBackgroundService : IVRBackgroundService
    {
        private readonly IVRBackgroundRepository _VRBackgroundRepository;
        private readonly ISceneService _sceneService;

        public VRBackgroundService(IVRBackgroundRepository VRBackgroundRepository, ISceneService SceneService)
        {
            _VRBackgroundRepository = VRBackgroundRepository;
            _sceneService = SceneService;

        }

        public void SaveBackground(IFormFile file, int sceneId)
        {
            Scene scene = _sceneService.GetScene(sceneId);
            if (scene != null)
            {

                if (file.ContentType.StartsWith("image/"))
                {
                    byte[] p1 = null;
                    using (var fs1 = file.OpenReadStream())
                    using (var ms1 = new MemoryStream())
                    {
                        fs1.CopyTo(ms1);
                        p1 = ms1.ToArray();
                    }

                    VRBackground background = new VRBackground()
                    {
                        Img = p1,
                        Colour = "#FFFFFF",
                        SceneId = sceneId,
                    };

                    if (_VRBackgroundRepository.getBackgroundWithSceneId(sceneId) != null)
                    {
                        _VRBackgroundRepository.UpdateBackground(background);
                    }
                    else
                    {
                        _VRBackgroundRepository.AddBackground(background);
                    }
                   
                }

            }
        }

        public byte[] getBackgroundImageWithSceneId(int id)
        {
            var backgroundImage = _VRBackgroundRepository.getBackgroundImageBytesWithSceneId(id);

            if (backgroundImage != null && backgroundImage.Length > 0)
            {
                return backgroundImage;
            }
            return null;
        }

        public IEnumerable<VRBackground> getBackgroundImagesWithSceneIds(List<int> sceneIds)
        {
            List<VRBackground> backgroundImages = new List<VRBackground>();
            foreach(int i in sceneIds)
            {
                backgroundImages.Add(_VRBackgroundRepository.getBackgroundWithSceneId(i));
            }
           
            if (backgroundImages != null && backgroundImages.Count() > 0)
            {
                return backgroundImages;
            }
            return null;
        }

        public void UpdateColour(string colour, int sceneId)
        {
            if (_sceneService.GetScene(sceneId) != null)
            {
                _VRBackgroundRepository.UpdateColour(colour, sceneId);
            }
        }


        public void AddImage(VRBackground img)
        {
            _VRBackgroundRepository.Add(img);
        }

        public VRBackground getBackgroundImageObjectWithSceneId(int id)
        {
            if (_sceneService.GetScene(id) != null)
            {
                return _VRBackgroundRepository.getBackgroundWithSceneId(id);
            }
            return null;
           
        }
    }
}
