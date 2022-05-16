using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Robo.Models
{
    public class PostRequestRoboModel
    {
        public int movimento { get; set; }
        public byte tipoMovimento { get; set; }
        public RoboModel roboModel { get; set; }
    }
}