using System;
using System.Collections.Generic;
using System.Text;

namespace ImageLabeler.Models
{
    class LabelManager
    {
        private List<ClassLabel> classLabels;

        public List<ClassLabel> ClassLabels { get => classLabels; set => classLabels = value; }
        public LabelManager()
        {
            classLabels = new List<ClassLabel>();
        }

        public bool AddLabel(ClassLabel newLabel)
        {
            try
            {
                if (!classLabels.Contains(newLabel))
                {
                    classLabels.Add(newLabel);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool RemoveLabel(ClassLabel label)
        {
            try
            {
                if (classLabels.Contains(label))
                {
                    classLabels.Remove(label);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
