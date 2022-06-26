using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry_Editor
{
    public abstract class Relation
    {
        public Vertex v1, v2, v3, v4;
        public Edge e1, e2;
        public int Number { get; protected set; }
        public abstract void PreserveRelation(Edge e, Vertex v);
        public static int Count { get; protected set; } = 0;
        public virtual string Signature { get; } = "R";
        public Relation()
        {
            Count++;
            Number = Count;
        }
        public virtual void Delete()
        {
            e1.Relation = null;
            if(e2 != null) e2.Relation = null;
        }
    }

    public class Parallelity : Relation
    {
        public override string Signature { get; } = "P";
        public Parallelity()
        {
            e1 = null;
            e2 = null;
        }
        public Parallelity(Edge e1, Edge e2)
        {
            this.e1 = e1;
            this.e2 = e2;
            v1 = e1.To;
            v2 = e1.From;
            v3 = e2.To;
            v4 = e2.From;
            PreserveRelation(e1, v1);
        }

        public override void PreserveRelation(Edge e, Vertex v)
        {
            Edge movedEdge;
            Edge otherEdge;
            if (e == e1)
            {
                movedEdge = e1;
                otherEdge = e2;
            }
            else
            {
                movedEdge = e2;
                otherEdge = e1;
            }
            otherEdge.SetSlope2(movedEdge.Slope);
        }
    }

    public class SameLength : Relation
    {
        public override string Signature { get; } = "L";
        public SameLength()
        {
            e1 = null;
            e2 = null;
        }
        public SameLength(Edge e1, Edge e2)
        {
            this.e1 = e1;
            this.e2 = e2;
            v1 = e1.From;
            v2 = e1.To;
            v3 = e2.From;
            v4 = e2.To;
        }

        public override void PreserveRelation(Edge e, Vertex v)
        {
            Edge movedEdge;
            Edge otherEdge;
            if (e == e1)
            {
                movedEdge = e1;
                otherEdge = e2;
            }
            else
            {
                movedEdge = e2;
                otherEdge = e1;
            }
            var movedEdgeLength = Vertex.Distance(movedEdge.From, movedEdge.To);
            var otherEdgeLength = Vertex.Distance(otherEdge.From, otherEdge.To);
            var newPoint = Geometry.SameLinePoint(otherEdge.From.point, movedEdgeLength / otherEdgeLength, otherEdge.To.point);
            otherEdge.To.point = newPoint;
        }
    }

    public class Tangency : Relation
    {
        public override string Signature { get; } = "T";
        public Circle circle;
        public Tangency()
        {
            e1 = null;
            circle = null;
        }
        public Tangency(Edge edge, Circle circle)
        {
            e1 = edge;
            e1.Relation = this;
            circle.point.relation = this;
            circle.relation = this;
            this.circle = circle;
        }
        public override void Delete()
        {
            circle.relation = null;
            circle.point.relation = null;
            e1.Relation = null;
        }

        public override void PreserveRelation(Edge e, Vertex v)
        {
            if (e != null && circle.IsRadiusFixed == false)
            {
                var up = Math.Abs((e1.To.X - e1.From.X) * (e1.From.Y - circle.Y) - (e1.From.X - circle.X) * (e1.To.Y - e1.From.Y));
                var down = Math.Sqrt((e1.To.X - e1.From.X) * (e1.To.X - e1.From.X) + (e1.To.Y - e1.From.Y) * (e1.To.Y - e1.From.Y));
                var dist = up / down;
                circle.Radius = (float)Math.Round(dist);
            }
            else if (e != null && circle.IsRadiusFixed == true)
            {
                var P = Geometry.SameLinePoint(e.From.point, 0.5, e.To.point);
                var a1 = e.Slope;
                var angle = Math.Atan(a1) + Math.PI/2;
                circle.point.point = new System.Drawing.Point(P.X + (int)Math.Round(Math.Cos(angle) * circle.Radius), P.Y + (int)Math.Round(Math.Sin(angle) * circle.Radius));
            }
            else if (e == null && circle.IsRadiusFixed == false)
            {
                var up = Math.Abs((e1.To.X - e1.From.X) * (e1.From.Y - circle.Y) - (e1.From.X - circle.X) * (e1.To.Y - e1.From.Y));
                var down = Math.Sqrt((e1.To.X - e1.From.X) * (e1.To.X - e1.From.X) + (e1.To.Y - e1.From.Y) * (e1.To.Y - e1.From.Y));
                var dist = up / down;
                circle.Radius = (float)Math.Round(dist);
            }
            else if (e == null && circle.IsRadiusFixed == true)
            {
                
            }
        }
    }
}
