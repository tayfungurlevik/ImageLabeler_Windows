using System;
using System.Collections.Generic;
using System.Text;

namespace ImageLabeler.Models
{
    class ImageLabelManager
    {
        private List<ImageLabel> imageLabels;
        private string imageFileName;
        public void AddImageLabel(ImageLabel newImageLabel)
        {
            if (!imageLabels.Contains(newImageLabel))
            {
                imageLabels.Add(newImageLabel);
            }
        }
        public void RemoveImageLabel(ImageLabel imageLabel)
        {
            if (imageLabels.Contains(imageLabel))
            {
                imageLabels.Remove(imageLabel);
            }
        }

    }
}
