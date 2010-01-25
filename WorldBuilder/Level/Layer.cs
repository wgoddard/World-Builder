﻿using System;
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
        string m_name;

        int m_gridX = 0;
        int m_gridY = 0;

        public Layer(TreeNode node)
        {
            m_entities = new List<Entity>();
            m_node = node;
            m_node.Tag = this;
            m_node.TreeView.SelectedNode = m_node;
            m_name = m_node.Text;
            m_node.Checked = true;
        }

        public void AddEntity(Entity entity)
        {
            TreeNode node = new TreeNode(entity.Name);
            entity.SetNode(node);
            m_node.Nodes.Add(node);
            m_entities.Add(entity);
            //m_node.TreeView.SelectedNode = node;

        }

        public void SortNodes()
        {
            m_entities.Clear();
            foreach (TreeNode child in m_node.Nodes)
            {
                m_entities.Add((Entity)child.Tag);
            }
        }

        public void DeleteNode(TreeNode node)
        {
            m_entities.Remove((Entity)node.Tag);
            m_node.Nodes.Remove(node);
        }

        public Entity SelectEntity(System.Drawing.Point point)
        {
            if (m_node.Checked == false) return null;
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
            if (m_node.Checked == false) return null;
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
            if (m_node.Checked == false) return;
            foreach (Entity entity in m_entities)
            {
                entity.Draw();
            }
        }

        public string Name
        {
            get { return m_name; }
            set { m_name = value; m_node.Text = value; }
        }

        public int GridX
        {
            get { return m_gridX; }
            set { m_gridX = value; }
        }
        public int GridY
        {
            get { return m_gridY; }
            set { m_gridY = value; }
        }
    }
}
