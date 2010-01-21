using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorldBuilder
{
    class AnimatedSprite : Entity
    {

        public override void Draw() { }
        public override bool Collide(System.Drawing.Point point)
        {
            throw new NotImplementedException();
        }
        public override bool Collide(System.Drawing.Rectangle rect)
        {
            throw new NotImplementedException();
        }
    }
}
