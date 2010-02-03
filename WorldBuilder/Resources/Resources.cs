using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorldBuilder
{
    sealed public class Resources
    {
        private static Resources _resources;

        private List<Resource> resources = new List<Resource>();

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

        public void AddResource(Resource r)
        {
            resources.Add(r);
        }

        public Resource GetResource(string filename)
        {
            foreach (Resource r in resources)
            {
                if (r.FileName == filename) return r;
            }
            return null;
        }

        public int GetID(Resource r)
        {
            int id = resources.IndexOf(r);
            if (id == -1)
                throw new Exception("Resource wasn't in manager.");
            return id;
        }

        public void Remove(string filename)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Resource r)
        {
            return resources.Remove(r);
        }


    }

}
