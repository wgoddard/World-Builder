using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace WorldBuilder
{
    class World
    {
        List<Level> m_levels = null;
        Level m_selectedLevel = null;
        string m_name = "";

        public World(TreeView tv, string name)
        {
            tv.Nodes.Clear();
            tv.Nodes.Add(name);
            m_levels = new List<Level>();
            m_name = name;
        }

        void AddEntity(Entity entity)
        {
        }
        void DeleteSelected()
        {
        }
        void TranslateSelected()
        {
        }
        void RotateSelected()
        {
        }
        void ScaleSelected()
        {
        }
        void SelectRange(Rectangle rect)
        {
        }

        void AddLevel()
        {
        }
        void DeleteLevel()
        {
        }
        void AddLayer()
        {
        }
        void DeleteLayer()
        {
        }
    }
}
