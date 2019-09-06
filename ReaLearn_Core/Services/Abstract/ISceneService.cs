using Microsoft.AspNetCore.Http;
using ReaLearn_Core.Models;
using ReaLearn_Core.Models.VRObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReaLearn_Core.Services.Abstract
{
    public interface ISceneService
    {
        void AddScene(Scene scene);

        IEnumerable<Scene> GetScenesWithCourseId(int courseId);
        Scene GetScene(int sceneId);
        string GetSceneTitleWithSceneId(int sceneId);
        void DeleteScene(int sceneId);
        List<Scene> getFirstScenesWithCourseIds(List<int> courseIds);
    }
}
