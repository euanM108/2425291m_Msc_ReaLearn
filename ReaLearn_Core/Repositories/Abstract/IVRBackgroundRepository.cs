using Microsoft.AspNetCore.Http;
using ReaLearn_Core.Models.VRObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReaLearn_Core.Repositories.Abstract
{
    public interface IVRBackgroundRepository : IRepository<VRBackground>
    {
        byte[] getBackgroundImageBytesWithSceneId(int id);
        void UpdateColour(string colour, int sceneId);
        VRBackground getBackgroundWithSceneId(int sceneId);

        void UpdateBackground(VRBackground background);
        void AddBackground(VRBackground background);
    }
}
