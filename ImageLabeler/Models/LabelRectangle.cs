using System;
using System.Collections.Generic;
using System.Text;

namespace ImageLabeler.Models
{
    class LabelRectangle
    {
        private ClassLabel label;
        private float Top, Left, Width, Height;
        public ClassLabel Label { get => label; set => label = value; }
        public void Draw()
        {
            throw new NotImplementedException();
        }
        public void Update(float Top,float Left,float Width,float Height)
        {
            throw new NotImplementedException();
        }
    }
}
