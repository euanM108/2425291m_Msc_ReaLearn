using ReaLearn_Core.Models.VRObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReaLearn_Core.Models
{
    public class ExportModel
    {
        public VRBackground backgroundImage;
        public IEnumerable<VRObject> VRObjects;
        public IEnumerable<VRHotspot> VRHotSpots;
        public IEnumerable<VRQuestionCard> VRQuestionCards;
        public IEnumerable<VRQuestionResponse> VRQuestionResponses;
    }
}
