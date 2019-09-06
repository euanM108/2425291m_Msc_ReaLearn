using ReaLearn_Core.Models.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReaLearn_Core.Models
{
    public class VRObject : IVRObject
    {
        public int Id { get; set; }
        public string AssetName { get; set; }
        public double xPos { get; set; }
        public double yPos { get; set; }
        public double zPos { get; set; }
        public double xScale { get; set; }
        public double yScale { get; set; }
        public double zScale { get; set; }
        public int xRot { get; set; }
        public int yRot { get; set; }
        public int zRot { get; set; }
        public string ObjectType { get; set; }
        public string Value { get; set; }
        public int SceneId { get; set; }
        public string Colour { get; set; }
        public Scene Scene { get; set; }

    }
}
