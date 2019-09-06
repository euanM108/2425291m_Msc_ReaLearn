using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReaLearn_Core.Models.VRObjectModels
{
    public class VRHotspot :VRObject
    {
        public string Action { get; set; }
        public bool OnClick { get; set; }
    }
}
