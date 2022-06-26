using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Geometry_Editor
{
    static class Geometry
    {
        // https://math.stackexchange.com/questions/175896/finding-a-point-along-a-line-https://stackoverflow.com/questions/13302396/given-two-points-find-a-third-point-on-the-line?rq=1a-certain-distance-away-from-another-point/175906
        public static Point SameLinePoint(Point p1, double distanceRatio, Point p2)
        {
            return new Point(
               (int)Math.Round((1 - distanceRatio) * p1.X + distanceRatio * p2.X),
               (int)Math.Round((1 - distanceRatio) * p1.Y + distanceRatio * p2.Y)
            );
        }
        public static Point EdgeMiddle(Edge e)
        {
            return SameLinePoint(e.From.point, 0.5, e.To.point);
        }
    }
}
