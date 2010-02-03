using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorldBuilder
{
    abstract class Shape : Entity
    {
        public abstract void AdjustToPoints(System.Drawing.Point p1, System.Drawing.Point p2);

        public override List<Resource> Resources
        {
            get { return new List<Resource>(); }
           // get { throw new NotImplementedException(); }
        }
    }
}
