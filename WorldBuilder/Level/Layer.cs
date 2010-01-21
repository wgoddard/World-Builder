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
            m_entities = new List<Entity>();
            m_node = node;
            m_node.Tag = this;
            m_node.TreeView.SelectedNode = m_node;
        }

        public void AddEntity(Entity entity)
        {
            TreeNode node = new TreeNode(entity.Name);
            entity.SetNode(node);
            m_node.Nodes.Add(node);
            m_entities.Add(entity);
            m_node.TreeView.SelectedNode = node;

        }

        public Entity SelectEntity(System.Drawing.Point point)
        {
            //foreach (Entity entity in m_entities)
            for (int i = m_entities.Count - 1; i >= 0; --i)
            {
                Entity entity = m_entities[i];
                if (entity.Collide(point)) return entity;
            }
            return null;
        }

        public List<Entity> SelectEntities(System.Drawing.Rectangle rect)
        {
            List<Entity> entities = new List<Entity>();
            foreach (Entity entity in m_entities)
            {
                if (entity.Collide(rect))
                    entities.Add(entity);
            }
            return entities;
        }


        public void Draw()
        {
            foreach (Entity entity in m_entities)
            {
                entity.Draw();
            }
        }
    }
}
