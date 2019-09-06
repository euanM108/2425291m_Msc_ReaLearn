using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReaLearn_Core.Models.VRObjectModels
{
    public class VRQuestionResponse
    {
        public int id { get; set; }
        public VRQuestionCard VRQuestion { get; set; }
        public int VRQuestionId { get; set; }
        public bool isCorrect { get; set; }
        public string Response { get; set; }
    }
}
