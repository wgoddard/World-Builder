using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorldBuilder
{
    class Level
    {
        List<Layer> m_layers;
        string m_name;
        int m_width;
        int m_height;

        public Level()
        {
        }

        public string Name
        {
            get { return m_name; }
        }
        public int Width
        {
            get { return m_width; }
        }
        public int Height
        {
            get { return m_height; }
        }
    }
}
