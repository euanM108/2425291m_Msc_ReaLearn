using Microsoft.AspNetCore.Http;
using ReaLearn_Core.Models;
using ReaLearn_Core.Models.VRObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReaLearn_Core.Repositories.Abstract
{
    public interface ISceneRepository : IRepository<Scene>
    {
        IEnumerable<Scene> GetScenesWithCourseId(int courseId);
        string GetSceneTitleWithSceneId(int sceneId);
       
    }
}
