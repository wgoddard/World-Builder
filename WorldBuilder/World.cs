using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.IO;

namespace WorldBuilder
{
    class World
    {
        List<Level> m_levels = null;
        //List<object> m_customs = new List<object>();
        Level m_selectedLevel = null;
        TreeView m_tv;
        string m_name = "";
        ContextMenuStrip m_cms;
        string m_filename;

        public World(TreeView tv, string name)
        {
            tv.Nodes.Clear();
            tv.Nodes.Add(name);
            m_tv = tv;
            m_levels = new List<Level>();
            m_cms = new ContextMenuStrip();
            m_cms.Items.Add("Add Level");
            m_cms.Items[0].Click += new EventHandler(World_Click);
            m_name = name;
            m_tv.Nodes[0].ContextMenuStrip = m_cms;
            m_tv.Nodes[0].Tag = this;
            m_tv.Nodes[0].Checked = true;
            m_tv.Nodes[0].ImageIndex = 44;
            m_tv.Nodes[0].SelectedImageIndex = 44;
        }

        public void Save()
        {

            if (File.Exists(m_filename))
                File.Delete(m_filename);

            foreach (Level l in m_levels)
            {
                l.Save(m_filename);
            }
        }

        public void SaveAs(string filename)
        {
            if (filename != null)
            {
                this.m_filename = filename;
                Save();
            }
            else
                throw new Exception("Invalid filename");
        }

        public void Select(Level level, Layer layer)
        {
            if (level == null) return;

            m_selectedLevel = level;
            if (layer != null)
                m_selectedLevel.SelectLayer(layer);
        }

        public Layer GetLayer()
        {
            if (m_selectedLevel == null) return null;
            return m_selectedLevel.GetCurrentLayer();
        }

        public Level GetLevel()
        {
            return m_selectedLevel;
        }

        void World_Click(object sender, EventArgs e)
        {
            AddLevel();
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
            //MessageBox.Show("Weee");
            TreeNode node = m_tv.Nodes[0].Nodes.Add("New Level");
            m_selectedLevel = new Level(node);
            m_levels.Add(m_selectedLevel);
            m_tv.Nodes[0].Expand();
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

        [CategoryAttribute("General Properties"),
        DescriptionAttribute("Name of the ")]
        public string Name
        {
            get { return m_name; }
            set 
            {
                m_name = value;
                m_tv.Nodes[0].Text = m_name;
            }
        }

        public string Filename
        {
            get { return m_filename; }
        }

    }
}
