using Microsoft.AspNetCore.Http;
using ReaLearn_Core.Data;
using ReaLearn_Core.Models;
using ReaLearn_Core.Models.VRObjectModels;
using ReaLearn_Core.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ReaLearn_Core.Repositories
{
    public class SceneRepository : Repository<Scene>, ISceneRepository
    {
        private ApplicationDbContext _context { get; set; }

        public SceneRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Scene> GetScenesWithCourseId(int courseId)
        {
            return _context.Set<Scene>().Where(c => c.CourseId == courseId);
        }

        public string GetSceneTitleWithSceneId(int sceneId)
        {
            return _context.Set<Scene>().Where(c => c.Id == sceneId).FirstOrDefault().Title;
        }

        
    }
}
