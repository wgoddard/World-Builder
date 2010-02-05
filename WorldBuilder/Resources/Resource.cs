using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorldBuilder
{
    public abstract class Resource
    {
        protected string filename;


        public Resource(string file_name) 
        {
            filename = file_name;
        }

        public abstract string Type { get; set; }
        public int ID
        {
            get { return Resources.Manager.GetID(this); }
        }
        public string FileName
        {
            get { return filename; }
        }

    }
}
