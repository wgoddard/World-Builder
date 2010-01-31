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
        //private static int id = 0;
        protected abstract string GetName();

        string m_name;
        float m_x;
        float m_y;
        float m_rot;
        float m_scalex;
        float m_scaley;
        bool m_flipx;
        bool m_flipy;
        TreeNode m_node = null;
        ContextMenuStrip m_cms;
        

        public Entity()
        {
            m_name = GetName();
            //m_name = "Unnamed" + id.ToString();
            //id++;
            m_x = 0;
            m_y = 0;
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
            m_cms = new ContextMenuStrip();
            m_cms.Items.Add("Delete");
            m_cms.Items[0].Name = "Delete";
            m_cms.Items[0].Click += new EventHandler(Delete_Click);
            m_cms.Items.Add("Duplicate");
            m_cms.Items[1].Name = "Duplicate";
            m_cms.Items[1].Click += new EventHandler(Duplicate_Click);
            //m_cms.MouseDown += new MouseEventHandler(m_cms_MouseDown);
            m_cms.Opened += new EventHandler(m_cms_Opened);
            m_node.ContextMenuStrip = m_cms;
            m_node.ImageIndex = GetIcon();
            m_node.SelectedImageIndex = GetIcon();
        }

        void m_cms_Opened(object sender, EventArgs e)
        {
            m_node.TreeView.SelectedNode = m_node;
            //throw new NotImplementedException();
        }

        void m_cms_MouseDown(object sender, MouseEventArgs e)
        {
            m_node.TreeView.SelectedNode = m_node;
            //throw new NotImplementedException();
        }

        void Duplicate_Click(object sender, EventArgs e)
        {
            Entity clone = this.Clone();
            clone.Name = this.Name + "_copy";
            ((Layer)m_node.Parent.Tag).AddEntity(clone);
            //throw new NotImplementedException();
        }

        void Delete_Click(object sender, EventArgs e)
        {
            Delete();
            //throw new NotImplementedException();
        }

        public void Select()
        {
            m_node.TreeView.SelectedNode = m_node;
            m_node.TreeView.Focus();
            //MessageBox.Show(m_node.IsSelected.ToString());
        }

        public void Translate(float x, float y)
        {
            m_x += x;
            m_y += y;
        }

        public void Delete()
        {
            ((Layer)m_node.Parent.Tag).DeleteNode(m_node);
        }


        public abstract Entity Clone();
        public abstract void Draw();
        public abstract void DrawBox();

        public abstract bool Collide(System.Drawing.Rectangle rect);
        public abstract bool Collide(Point point);

        public abstract int GetIcon();

        #region Public Accessors

        public float X
        {
            get { return m_x; }
            set { m_x = value; }
        }

        public float Y
        {
            get { return m_y; }
            set { m_y = value; }
        }

        public Point Position
        {
            set { m_x = value.X; m_y = value.Y; }
        }

        public float Rotation
        {
            get { return m_rot; }
            set { m_rot = value; }
        }

        public float ScaleX
        {
            get { return m_scalex; }
            set { if (value > 0) m_scalex = value; }
        }

        public float ScaleY
        {
            get { return m_scaley; }
            set { if (value > 0) m_scaley = value; }
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


        public abstract int Width { get; set; }
        public abstract int Height { get; set; }

        #endregion
    }
}
