using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace WorldBuilder
{
    abstract class Entity
    {
        private static int id = 0;

        string m_name;
        Point m_position;
        float m_rot;
        float m_scalex;
        float m_scaley;
        bool m_flipx;
        bool m_flipy;
        TreeNode m_node = null;

        public Entity()
        {
            m_name = "Unnamed" + id.ToString();
            id++;
            m_position = new Point(0, 0);
            m_rot = 0;
            m_scalex = 1.0f;
            m_scaley = 1.0f;
            m_flipx = false;
            m_flipy = false;
        }

        public void SetNode(TreeNode node)
        {
            m_node = node;
            m_node.Tag = this;
        }

        public void Select()
        {
            m_node.TreeView.SelectedNode = m_node;
            //MessageBox.Show(m_node.IsSelected.ToString());
        }

        public void Translate(int x, int y)
        {
            m_position.X += x;
            m_position.Y += y;
        }


        public abstract Entity Clone();
        public abstract void Draw();
        public abstract void DrawBox();

        public abstract bool Collide(Rectangle rect);

        public abstract bool Collide(Point point);

        #region Public Accessors

        public Point Position
        {
            get { return m_position; }
            set { m_position = value; }
        }

        public float Rotation
        {
            get { return m_rot; }
            set { m_rot = value; }
        }

        public float ScaleX
        {
            get { return m_scalex; }
            set { m_scalex = value; }
        }

        public float ScaleY
        {
            get { return m_scaley; }
            set { m_scaley = value; }
        }

        public bool FlipHorizontal
        {
            get { return m_flipx; }
            set { m_flipx = value; }
        }

        public bool FlipVertical
        {
            get { return m_flipy; }
            set { m_flipy = value; }
        }

        public string Name
        {
            get { return m_name; }
            set { m_name = value; if (m_node != null) m_node.Text = value; }
        }

        #endregion
    }
}
