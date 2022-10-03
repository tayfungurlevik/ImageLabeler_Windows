using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Media;

namespace ImageLabeler.Models
{
    class ImageLabel : System.Windows.Shapes.Shape
    {
        
        public float NormalizedCenterX { get; set; }
        public float NormalizedCenterY { get; set; }
        public float NormalizedWidth { get; set; }
        public float NormalizedHeight { get; set; }
        public ClassLabel Label {get;set;}

        protected override Geometry DefiningGeometry
        {
            get
            {

                RectangleGeometry rect = new RectangleGeometry();
                
                return rect;
            }
        }
    }
}
