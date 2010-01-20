using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WorldBuilder
{
    class Layer
    {
        List<Entity> m_entities;
        TreeNode m_node;

        public Layer(TreeNode node)
        {
            m_node = node;
            m_node.Tag = this;
            m_node.TreeView.SelectedNode = m_node;
        }
    }
}
