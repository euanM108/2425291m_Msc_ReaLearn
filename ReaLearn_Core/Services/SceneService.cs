using ReaLearn_Core.Models;
using ReaLearn_Core.Models.VRObjectModels;
using ReaLearn_Core.Repositories.Abstract;
using ReaLearn_Core.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReaLearn_Core.Services
{
    public class SceneService : ISceneService
    {
        private readonly ISceneRepository _sceneRepository;
        private readonly IVRBackgroundRepository _VRBackgroundService;
        public SceneService(ISceneRepository sceneRepository, IVRBackgroundRepository VRBackgroundService)
        {
            _sceneRepository = sceneRepository;
            _VRBackgroundService = VRBackgroundService;

        }

        public void AddScene(Scene scene)
        {
            _sceneRepository.Add(scene);
            VRBackground image = new VRBackground()
            {
                SceneId = scene.Id,
            };
            _VRBackgroundService.Add(image);
        }

        public void DeleteScene(int sceneId)
        {
            var scene = _sceneRepository.Get(sceneId);
            if (scene != null)
            {
                _sceneRepository.Remove(scene);
            }
        }

        public List<Scene> getFirstScenesWithCourseIds(List<int> courseIds)
        {
            List<Scene> firstScenes = new List<Scene>();
            foreach(int i in courseIds)
            {
                firstScenes.Add(_sceneRepository.GetScenesWithCourseId(i).ElementAt(0));
            }

            if (firstScenes != null)
            {
                return firstScenes;
            }
            return null;
        }

        public Scene GetScene(int sceneId)
        {
            var scene = _sceneRepository.Get(sceneId);
            if (scene != null)
            {
                return scene;
            }
            return null;
        }

        public IEnumerable<Scene> GetScenesWithCourseId(int courseId)
        {
            var scenes = _sceneRepository.GetScenesWithCourseId(courseId); 
            if (scenes.Count() > 0)
            {
                Console.Write(scenes.Count());
                return scenes;
            }
            return null;
        }

        public string GetSceneTitleWithSceneId(int sceneId)
        {
            var title = _sceneRepository.GetSceneTitleWithSceneId(sceneId);
            if (title != null)
            {
                return title;
            }
            return null;
        }

       
    }
}
