using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tao.OpenGl;

namespace WorldBuilder
{
    class Texture : Entity
    {
        Image m_image;

        public Texture(Image image) : base()
        {
            m_image = image;
        }

        public override void Draw()
        {
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, m_image.TextureID);
            //Gl.glColor3f(1.0f, 1.0f, 1.0f);
            Gl.glBegin(Gl.GL_QUADS);

            Gl.glTexCoord2i(0, 0);
            Gl.glVertex2i(base.Position.X, base.Position.Y);

            Gl.glTexCoord2i(1, 0);
            Gl.glVertex2i(base.Position.X + m_image.Width, base.Position.Y);

            Gl.glTexCoord2i(1, 1);
            Gl.glVertex2i(base.Position.X + m_image.Width, base.Position.Y + m_image.Height);

            Gl.glTexCoord2i(0, 1);
            Gl.glVertex2i(base.Position.X, base.Position.Y + m_image.Height);

            Gl.glEnd();
        }

        public override void DrawBox()
        {
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, 0);
            Gl.glColor3f(1.0f, 0f, 0f);
            Gl.glBegin(Gl.GL_LINE_STRIP);

            Gl.glVertex2i(base.Position.X, base.Position.Y);

            Gl.glVertex2i(base.Position.X + m_image.Width, base.Position.Y);

            Gl.glVertex2i(base.Position.X + m_image.Width, base.Position.Y + m_image.Height);

            Gl.glVertex2i(base.Position.X, base.Position.Y + m_image.Height);

            Gl.glVertex2i(base.Position.X, base.Position.Y);

            Gl.glEnd();
        }

        public override bool Collide(System.Drawing.Point point)
        {
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(base.Position.X, base.Position.Y, m_image.Width, m_image.Height);

            if (point.X > rect.Right) return false;
            if (point.Y > rect.Bottom) return false;
            if (point.X < rect.Left) return false;
            if (point.Y < rect.Top) return false;

            return true;
            
        }
        public override bool Collide(System.Drawing.Rectangle rect)
        {
            System.Drawing.Rectangle thisRect = new System.Drawing.Rectangle(base.Position.X, base.Position.Y, m_image.Width, m_image.Height);

            //if (rect.Left > thisRect.Right) return false;
            //if (rect.Right < thisRect.Left) return false;
            //if (rect.Top > rect.B

            if (thisRect.IntersectsWith(rect))
                return true;


            return false;
        }

        public string TextureFile
        {
            get { return m_image.FileName; }
        }
    }
}
