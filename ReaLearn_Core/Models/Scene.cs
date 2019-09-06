using ReaLearn_Core.Models.Abstract;
using ReaLearn_Core.Models.VRObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ReaLearn_Core.Models
{
    public class Scene
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }

    }
}
