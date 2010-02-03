using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorldBuilder
{
    class AnimatedSprite : Entity
    {
        AnimatedSprite() { }

        public override int GetIcon()
        {
            return 0;
        }

        protected override string GetName()
        {
            return null;
        }
        public override string GetType()
        {
            return "AnimatedSprite";
            //throw new NotImplementedException();
        }

        public override void Draw() { }
        public override void DrawBox()
        {
            throw new NotImplementedException();
        }
        public override bool Collide(System.Drawing.Point point)
        {
            throw new NotImplementedException();
        }
        public override bool Collide(System.Drawing.Rectangle rect)
        {
            throw new NotImplementedException();
        }
        public override Entity Clone()
        {
            throw new NotImplementedException();
        }
        public override int Height
        {
            get
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override List<Resource> Resources
        {
            get { throw new NotImplementedException(); }
        }
    }
}
