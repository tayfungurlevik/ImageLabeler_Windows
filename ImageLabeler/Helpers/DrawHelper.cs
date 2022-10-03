using System;
using System.Collections.Generic;
using System.Windows;
using System.Text;
using System.Windows.Controls;

namespace ImageLabeler.Helpers
{
    class DrawHelper
    {
        private bool mouseLeftDown = false;
        private bool mouseLeftUp = false;
        private Point mouseDownPoint;
        private Point mouseUpPoint;
        private double imageWidth, imageHeight;
        public bool MouseLeftDown { get => mouseLeftDown; set => mouseLeftDown = value; }
        public bool MouseLeftUp { get => mouseLeftUp; set => mouseLeftUp = value; }
        public Point MouseDownPoint { get => mouseDownPoint; set => mouseDownPoint = value; }
        public Point MouseUpPoint { get => mouseUpPoint; set => mouseUpPoint = value; }
        public double ImageWidth { get => imageWidth; set => imageWidth = value; }
        public double ImageHeight { get => imageHeight; set => imageHeight = value; }

        public void DrawRectOnCanvas(ref Canvas canvas)
        {

        }
    }
}
