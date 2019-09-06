using Microsoft.AspNetCore.Http;
using ReaLearn_Core.Models.VRObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReaLearn_Core.Models.ViewModels
{
    public class SceneEditorViewModel
    {
        public int CourseId { get; set; }
        public IEnumerable<Scene> Scenes { get; set; }
        public int SelectedScene { get; set; }
        public AddSceneViewModel AddSceneViewModel { get; set; }
        public IEnumerable<VRObject> VRObjects { get; set; }
        public IEnumerable<VRHotspot> VRHotspots { get; set; }
        public IEnumerable<VRQuestionCard> VRQuestionCards { get; set; }

        public IEnumerable<VRBackground> Backgrounds { get; set; }
        public IEnumerable<VRQuestionResponse> Responses { get; internal set; }
    }
}
