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
            //Gl.glPushMatrix();
            //Gl.glScalef(ScaleX, ScaleY, 0);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, m_image.TextureID);
            //Gl.glColor3f(1.0f, 1.0f, 1.0f);
            Gl.glBegin(Gl.GL_QUADS);

            Gl.glTexCoord2i(0, 0);
            Gl.glVertex2i((int)(base.X - (m_image.Width/2 * ScaleX)), (int)(base.Y - (m_image.Height/2 * ScaleY)));

            Gl.glTexCoord2i(1, 0);
            Gl.glVertex2i((int)(base.X + (m_image.Width/2 * ScaleX)), (int)(base.Y - (m_image.Height/2 * ScaleY)));

            Gl.glTexCoord2i(1, 1);
            Gl.glVertex2i((int)(base.X + (m_image.Width/2 * ScaleX)), (int)(base.Y + (m_image.Height/2 * ScaleY)));

            Gl.glTexCoord2i(0, 1);
            Gl.glVertex2i((int)(base.X - (m_image.Width/2 * ScaleX)), (int)(base.Y + (m_image.Height/2 * ScaleY)));

            Gl.glEnd();
            //Gl.glPopMatrix();
        }

        public override void DrawBox()
        {
            //Gl.glPushMatrix();
            //Gl.glScalef(ScaleX, ScaleY, 0);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, 0);
            Gl.glColor3f(1.0f, 0f, 0f);
            Gl.glBegin(Gl.GL_LINE_STRIP);

            Gl.glVertex2i((int)(base.X - (m_image.Width / 2 * ScaleX)), (int)(base.Y - (m_image.Height / 2 * ScaleY)));

            Gl.glVertex2i((int)(base.X + (m_image.Width / 2 * ScaleX)), (int)(base.Y - (m_image.Height / 2 * ScaleY)));

            Gl.glVertex2i((int)(base.X + (m_image.Width / 2 * ScaleX)), (int)(base.Y + (m_image.Height / 2 * ScaleY)));

            Gl.glVertex2i((int)(base.X - (m_image.Width / 2 * ScaleX)), (int)(base.Y + (m_image.Height / 2 * ScaleY)));

            Gl.glVertex2i((int)(base.X - (m_image.Width / 2 * ScaleX)), (int)(base.Y - (m_image.Height / 2 * ScaleY)));

            Gl.glEnd();

            //Gl.glPopMatrix();
        }

        public override bool Collide(System.Drawing.Point point)
        {
            System.Drawing.Rectangle rect =  new System.Drawing.Rectangle(
                (int)(base.X) - (int)(m_image.Width * ScaleX /2),
                (int)(base.Y) - (int)(m_image.Height * ScaleY / 2), (int)(m_image.Width * ScaleX), (int)(m_image.Height * ScaleY));

            if (point.X > rect.Right) return false;
            if (point.Y > rect.Bottom) return false;
            if (point.X < rect.Left) return false;
            if (point.Y < rect.Top) return false;

            return true;
            
        }
        public override bool Collide(System.Drawing.Rectangle rect)
        {
            System.Drawing.Rectangle thisRect = new System.Drawing.Rectangle(
                (int)(base.X) - (int)(m_image.Width * ScaleX / 2),
                (int)(base.Y) - (int)(m_image.Height * ScaleY / 2), (int)(m_image.Width * ScaleX), (int)(m_image.Height * ScaleY));
            //if (rect.Left > thisRect.Right) return false;
            //if (rect.Right < thisRect.Left) return false;
            //if (rect.Top > rect.B

            if (thisRect.IntersectsWith(rect))
                return true;


            return false;
        }

        public override Entity Clone()
        {
            Texture t = new Texture(this.m_image);
            t.FlipHorizontal = this.FlipHorizontal;
            t.FlipVertical = this.FlipVertical;
            //t.Name = this.Name;
            t.X = this.X;
            t.Y = this.Y;
            t.Rotation = this.Rotation;
            t.ScaleX = this.ScaleX;
            t.ScaleY = this.ScaleY;

            return t;
            //throw new NotImplementedException();
        }

        public string TextureFile
        {
            get { return m_image.FileName; }
        }

        public override int Width
        {
            get
            {
                return m_image.Width;
            }
            set
            {
            }
        }

        public override int Height
        {
            get
            {
                return m_image.Height;
            }
            set
            {
               // throw new NotImplementedException();
            }
        }

    }
}
