using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReaLearn_Core.Models.VRObjectModels
{
    public class VRBackground
    {
        public int Id { get; set; }
        public Byte[] Img { get; set; }
        public string Colour { get; set; }
        public Scene Scene { get; set; }
        public int SceneId { get; set; }
    }
}
