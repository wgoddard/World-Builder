using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.IO;
using System.Xml;

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

            XmlDocument xmlDoc = new XmlDocument();

            try
            {
                xmlDoc.Load(m_filename);
            }
            catch (System.IO.FileNotFoundException)
            {
                //if file is not found, create a new xml file
                XmlTextWriter xmlWriter = new XmlTextWriter(m_filename, System.Text.Encoding.UTF8);
                xmlWriter.Formatting = Formatting.Indented;
                xmlWriter.WriteProcessingInstruction("xml", "version='1.0' encoding='UTF-8'");
                xmlWriter.WriteStartElement("world");
                xmlWriter.Close();
                xmlDoc.Load(m_filename);
            }
            XmlNode root = xmlDoc.DocumentElement;

            foreach (Resource r in Resources.Manager.ResourceList)
            {
                XmlElement resourceElement = xmlDoc.CreateElement("image");
                resourceElement.SetAttribute("File", r.FileName);
                root.AppendChild(resourceElement);
            }
            xmlDoc.Save(m_filename);
                

            foreach (Level l in m_levels)
            {
                l.Save(m_filename);
            }
        }

        public void SetSaveFile(string filename)
        {
            if (filename != null)
            {
                this.m_filename = filename;
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
            AddLevel("New Level");
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

        Level AddLevel(string name)
        {
            TreeNode node = m_tv.Nodes[0].Nodes.Add(name);
            m_selectedLevel = new Level(node);
            m_levels.Add(m_selectedLevel);
            m_tv.Nodes[0].Expand();

            return m_selectedLevel;
        }

        public Level AddLevel(string name, int width, int height)
        {
            TreeNode node = m_tv.Nodes[0].Nodes.Add(name);
            m_selectedLevel = new Level(node);
            m_levels.Add(m_selectedLevel);
            //m_tv.Nodes[0].Expand();

            return m_selectedLevel;
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
