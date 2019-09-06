using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReaLearn_Core.Models.Abstract
{
    public interface IVRObject
    {
        double xPos { get; set; }
        double yPos { get; set; }
        double zPos { get; set; }
        double xScale { get; set; }
        double yScale { get; set; }
        double zScale { get; set; }
        string ObjectType { get; set; }
        string Value { get; set; }
    }
}
