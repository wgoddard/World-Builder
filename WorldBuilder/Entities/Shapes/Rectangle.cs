using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tao.OpenGl;

namespace WorldBuilder
{
    class RectShape : Shape
    {
        float m_w = 1;
        float m_h = 1;

        static int id = 0;

        public RectShape()
            : base()
        {
        }

        protected override string GetName()
        {
            return GetType() + id++.ToString();
        }
        public override string GetType()
        {
            return "Rectangle";
            //throw new NotImplementedException();
        }

        public override Entity Clone()
        {
            RectShape t = new RectShape();
            t.m_w = this.m_w;
            t.m_h = this.m_h;


            t.FlipHorizontal = this.FlipHorizontal;
            t.FlipVertical = this.FlipVertical;
            //t.Name = this.Name;
            t.X = this.X;
            t.Y = this.Y;
            t.Rotation = this.Rotation;
            t.ScaleX = this.ScaleX;
            t.ScaleY = this.ScaleY;

            return t;
        }
        public override bool Collide(System.Drawing.Point point)
        {
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(
                (int)(base.X) - (int)(Width * ScaleX / 2),
                (int)(base.Y) - (int)(Height * ScaleY / 2), (int)(Width * ScaleX), (int)(Height * ScaleY));

            if (point.X > rect.Right) return false;
            if (point.Y > rect.Bottom) return false;
            if (point.X < rect.Left) return false;
            if (point.Y < rect.Top) return false;

            return true;

        }

        public override bool Collide(System.Drawing.Rectangle rect)
        {
            System.Drawing.Rectangle thisRect = new System.Drawing.Rectangle(
                (int)(base.X) - (int)(Width * ScaleX / 2),
                (int)(base.Y) - (int)(Height * ScaleY / 2), (int)(Width * ScaleX), (int)(Height * ScaleY));
            //if (rect.Left > thisRect.Right) return false;
            //if (rect.Right < thisRect.Left) return false;
            //if (rect.Top > rect.B

            if (thisRect.IntersectsWith(rect))
                return true;


            return false;
        }

        public override void Draw()
        {

            Gl.glBindTexture(Gl.GL_TEXTURE_2D, 0);
            Gl.glColor3f(0.0f, 1.0f, 0.0f);

            Gl.glPushMatrix();
            Gl.glTranslatef(base.X, base.Y, 0);
            Gl.glScalef(ScaleX, ScaleY, 0);
            Gl.glRotated(base.Rotation, 0, 0, 1);

            Gl.glBegin(Gl.GL_LINE_LOOP);


            Gl.glVertex2f( -(m_w / 2), - (m_h / 2));

            Gl.glVertex2f((m_w / 2), - (m_h / 2));

            Gl.glVertex2f((m_w / 2), (m_h / 2));

            Gl.glVertex2f( -(m_w / 2), (m_h / 2));

            //Gl.glVertex2i((int)(base.X - (Width / 2 * ScaleX)), (int)(base.Y - (Height / 2 * ScaleY)));

            Gl.glEnd();


            Gl.glColor3f(1.0f, 1.0f, 1.0f);

            Gl.glEnd();


            Gl.glPopMatrix();
        }

        public override void DrawBox()
        {
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, 0);
            Gl.glColor3f(1.0f, 0.0f, 0.0f);

            Gl.glPushMatrix();
            Gl.glTranslatef(base.X, base.Y, 0);
            Gl.glScalef(ScaleX, ScaleY, 0);
            Gl.glRotated(base.Rotation, 0, 0, 1);

            Gl.glBegin(Gl.GL_LINE_LOOP);


            Gl.glVertex2f(-(m_w / 2), -(m_h / 2));

            Gl.glVertex2f((m_w / 2), -(m_h / 2));

            Gl.glVertex2f((m_w / 2), (m_h / 2));

            Gl.glVertex2f(-(m_w / 2), (m_h / 2));

            //Gl.glVertex2i((int)(base.X - (Width / 2 * ScaleX)), (int)(base.Y - (Height / 2 * ScaleY)));

            Gl.glEnd();


            Gl.glColor3f(1.0f, 1.0f, 1.0f);

            Gl.glEnd();


            Gl.glPopMatrix();
        }

        public override void AdjustToPoints(System.Drawing.Point p1, System.Drawing.Point p2)
        {
            X = (p1.X + p2.X + 0.5f) / 2;
            Y = (p1.Y + p2.Y + 0.5f) / 2;
            m_w = Math.Abs(p1.X - p2.X);
            m_h = Math.Abs(p1.Y - p2.Y);
        }

        public override int Height
        {
            get
            {
                return (int)(m_h);
                // throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public override int Width
        {
            get
            {
                return (int)(m_w);
                //throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public override int GetIcon()
        {
            return 35;
            //throw new NotImplementedException();
        }
    }
}
