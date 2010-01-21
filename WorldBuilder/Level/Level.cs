using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
        }

        public void Draw()
        {
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

        void AddLayer()
        {
            TreeNode node = m_node.Nodes.Add("New Layer");
            //m_node.TreeView.Nodes.Add("Test");
            m_selectedLayer = new Layer(node);
            m_layers.Add(m_selectedLayer);
            m_node.Expand();
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
