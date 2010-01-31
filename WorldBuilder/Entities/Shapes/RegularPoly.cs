using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tao.OpenGl;

namespace WorldBuilder
{
    class RegularPoly : Shape
    {
        UInt16 m_sides = 3;
        float m_size = 20;

        static int id = 0;

        public RegularPoly() : base()
        {
        }

        protected override string GetName()
        {
            return "RegularPoly" + id++.ToString();
        }

        public override Entity Clone()
        {
            RegularPoly t = new RegularPoly();
            t.Sides = m_sides;
            t.Size = m_size;


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
                (int)(base.X) - (int)(Size * ScaleX / 2),
                (int)(base.Y) - (int)(Size * ScaleY / 2), (int)(Size * ScaleX), (int)(Size * ScaleY));

            if (point.X > rect.Right) return false;
            if (point.Y > rect.Bottom) return false;
            if (point.X < rect.Left) return false;
            if (point.Y < rect.Top) return false;

            return true;
        }
        public override bool Collide(System.Drawing.Rectangle rect)
        {
            System.Drawing.Rectangle thisRect = new System.Drawing.Rectangle(
                (int)(base.X) - (int)(Size * ScaleX / 2),
                (int)(base.Y) - (int)(Size * ScaleY / 2), (int)(Size * ScaleX), (int)(Size * ScaleY));


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



            for (int i = 0; i < m_sides; ++i)
            {
                Gl.glVertex2d(
                    Math.Sin((Math.PI * 2) * i / m_sides) * m_size,
                    Math.Cos((Math.PI * 2) * i / m_sides) * m_size);
            }
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



            for (int i = 0; i < m_sides; ++i)
            {
                Gl.glVertex2d(
                    Math.Sin((Math.PI * 2) * i / m_sides) * m_size,
                    Math.Cos((Math.PI * 2) * i / m_sides) * m_size);
            }
            Gl.glColor3f(1.0f, 1.0f, 1.0f);

            Gl.glEnd();


            Gl.glPopMatrix();
        }

        public override void AdjustToPoints(System.Drawing.Point p1, System.Drawing.Point p2)
        {
            X = (p1.X + p2.X) / 2;
            Y = (p1.Y + p2.Y) / 2;
            ScaleX = Math.Abs(p1.X - p2.X) / 10.0f;
            ScaleY = Math.Abs(p1.Y - p2.Y) / 10.0f;
        }

       // private override 

        public override int Height
        {
            get
            {
                return (int)(m_size * 2);
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
                return (int)(m_size * 2);
                //throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public UInt16 Sides
        {
            get
            {
                return m_sides;
            }
            set
            {
                if (value >= 3 && value <= 100)
                    m_sides = value;
            }
        }

        public float Size
        {
            get
            {
                return m_size;
            }
            set
            {
                if (value > 0)
                    m_size = value;
            }
        }

        public override int GetIcon()
        {
            return 35;
            //throw new NotImplementedException();
        }
    }
}
