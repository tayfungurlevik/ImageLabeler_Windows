using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ImageLabeler.Models
{
    class ImageLabel
    {
        
        public float NormalizedCenterX { get; set; }
        public float NormalizedCenterY { get; set; }
        public float NormalizedWidth { get; set; }
        public float NormalizedHeight { get; set; }
        public ClassLabel Label {get;set;}
    }
}
