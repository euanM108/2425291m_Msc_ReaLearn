using Microsoft.AspNetCore.Http;
using ReaLearn_Core.Models.VRObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReaLearn_Core.Services.Abstract
{
    public interface IVRBackgroundService
    {
        IEnumerable<VRBackground> getBackgroundImagesWithSceneIds(List<int> sceneIds);
        byte[] getBackgroundImageWithSceneId(int id);
        void UpdateColour(string colour, int sceneId);
        void SaveBackground(IFormFile file, int sceneId);
        void AddImage(VRBackground img);
        VRBackground getBackgroundImageObjectWithSceneId(int id);
    }

}