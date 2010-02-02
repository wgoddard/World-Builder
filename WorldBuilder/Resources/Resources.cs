using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorldBuilder
{
    sealed public class Resources
    {
        private static Resources _resources;

        private List<Image> images = new List<Image>();

        private Resources()
        {
        }

        static public Resources Manager
        {
            get
            {
                if (_resources == null) _resources = new Resources();
                return _resources;
            }
        }

        public void AddImage(Image image)
        {
            images.Add(image);
        }

        public Image GetImage(string filename)
        {
            foreach (Image image in images)
            {
                if (image.FileName == filename) return image;
            }
            return null;
        }

        public void Remove(string filename)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Image i)
        {
            return images.Remove(i);
        }


    }

}
