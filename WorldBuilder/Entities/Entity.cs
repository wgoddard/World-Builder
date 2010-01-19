using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WorldBuilder
{
    class Entity
    {
        private static int id = 0;

        string m_name;
        Point m_position;
        float m_rot;
        float m_scalex;
        float m_scaley;
        bool m_flipx;
        bool m_flipy;

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
            set { m_name = value; }
        }

        #endregion
    }
}
