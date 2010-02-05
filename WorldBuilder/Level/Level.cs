using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace WorldBuilder
{
    class Level
    {
        List<Layer> m_layers;
        Layer m_selectedLayer;
        string m_name;
        int m_width = 800*44;
        int m_height = 800*44;
        TreeNode m_node;
        ContextMenuStrip m_cms;

        public Level(TreeNode node)
        {
            m_layers = new List<Layer>();
            m_node = node;
            node.Text = "New Level";
            node.Tag = this;
            m_name = node.Text;

            m_node.TreeView.SelectedNode = m_node;

            m_cms = new ContextMenuStrip();
            m_cms.Items.Add("Add Layer");
            m_cms.Items[0].Name = "AddLayer";
            m_cms.Items[0].Click += new EventHandler(AddLayer_Click);
            m_node.ContextMenuStrip = m_cms;
            m_node.Checked = true;
            m_node.ImageIndex = 26;
            m_node.SelectedImageIndex = 26;
        }

        public void Save(string filename)
        {

            try
            {
                //pick whatever filename with .xml extension

                XmlDocument xmlDoc = new XmlDocument();

                try
                {
                    xmlDoc.Load(filename);
                }
                catch (System.IO.FileNotFoundException)
                {
                    //if file is not found, create a new xml file
                    XmlTextWriter xmlWriter = new XmlTextWriter(filename, System.Text.Encoding.UTF8);
                    xmlWriter.Formatting = Formatting.Indented;
                    xmlWriter.WriteProcessingInstruction("xml", "version='1.0' encoding='UTF-8'");
                    xmlWriter.WriteStartElement("world");
                    xmlWriter.Close();
                    xmlDoc.Load(filename);
                }
                XmlNode root = xmlDoc.DocumentElement;


                //XmlAttribute nameAttrib = xmlDoc.CreateAttribute("Name");

                XmlElement levelElement = xmlDoc.CreateElement("level");
                levelElement.SetAttribute("Name", m_name);
                levelElement.SetAttribute("Width", m_width.ToString());
                levelElement.SetAttribute("Height", m_height.ToString());
                root.AppendChild(levelElement);


                foreach (Layer l in m_layers)
                {
                    XmlElement layerNode = xmlDoc.CreateElement("layer");
                    layerNode.SetAttribute("Name", l.Name);
                    //seqNode.SetAttribute("Frames", seq.FrameCount.ToString());
                    //seqNode.SetAttribute("Return_Loop_Frame", seq.ReturnLoopFrame.ToString());
                   // seqNode.SetAttribute("Loops", (seq.Loops ? 1 : 0).ToString());
                    layerNode.SetAttribute("GridX", l.GridX.ToString());
                    layerNode.SetAttribute("GridY", l.GridY.ToString());


                    foreach (Entity e in l.Entities)
                    {
                        XmlElement entityNode = xmlDoc.CreateElement(e.GetType());
                        entityNode.SetAttribute("Name", e.Name);
                        entityNode.SetAttribute("X", e.X.ToString());
                        entityNode.SetAttribute("Y", e.Y.ToString());
                        entityNode.SetAttribute("Width", e.Width.ToString());
                        entityNode.SetAttribute("Height", e.Height.ToString());
                        entityNode.SetAttribute("ScaleX", e.ScaleX.ToString());
                        entityNode.SetAttribute("ScaleY", e.ScaleY.ToString());
                        entityNode.SetAttribute("Rotation", e.Rotation.ToString());
                        entityNode.SetAttribute("FlipX", e.FlipHorizontal.ToString());
                        entityNode.SetAttribute("FlipY", e.FlipHorizontal.ToString());

                        foreach (Resource r in e.Resources)
                        {
                            XmlElement resourceNode = xmlDoc.CreateElement("resource");
                            resourceNode.SetAttribute("Type", r.Type);
                            resourceNode.SetAttribute("ID", r.ID.ToString());

                            entityNode.AppendChild(resourceNode);
                        }
                        


                        layerNode.AppendChild(entityNode);
                    }

                    levelElement.AppendChild(layerNode);
                }



                xmlDoc.Save(filename);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }


        public void Draw()
        {
            if (m_node.Checked == false) return;
            foreach (Layer layer in m_layers)
            {
                layer.Draw();
            }
        }

        void AddLayer_Click(object sender, EventArgs e)
        {
            AddLayer();
            //throw new NotImplementedException();
        }

        Layer AddLayer()
        {
            TreeNode node = m_node.Nodes.Add("New Layer");
            //m_node.TreeView.Nodes.Add("Test");
            m_selectedLayer = new Layer(node);
            m_layers.Add(m_selectedLayer);
            m_node.Expand();
            return m_selectedLayer;
        }

        public Layer AddLayer(string name, int gridx, int gridy)
        {
            TreeNode node = m_node.Nodes.Add(name);
            //m_node.TreeView.Nodes.Add("Test");
            m_selectedLayer = new Layer(node, name, gridx, gridy);
            m_layers.Add(m_selectedLayer);
            //m_node.Expand();
            return m_selectedLayer;
        }

        public void DeleteNode(TreeNode node)
        {
            if (m_selectedLayer == (Layer)node.Tag)
                m_selectedLayer = null;
            m_layers.Remove((Layer)node.Tag);
            m_node.Nodes.Remove(node);
        }

        public void SortNodes()
        {
            m_layers.Clear();
            foreach (TreeNode child in m_node.Nodes)
            {
                m_layers.Add((Layer)child.Tag);
            }
        }

        public Layer GetCurrentLayer()
        {
            return m_selectedLayer;
        }

        public void SelectLayer(Layer layer)
        {
            if (layer != null)
                m_selectedLayer = layer;
            else
                m_selectedLayer = m_layers[m_layers.Count - 1];
        }

        public string Name
        {
            get { return m_name; }
            set { m_name = value; m_node.Text = value; }
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
