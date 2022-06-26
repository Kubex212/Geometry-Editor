using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Geometry_Editor
{
    public class Polygon
    {
        public List<Edge> edges { get; set; }
        public List<Vertex> Vertices { get; set; }
        public Polygon(List<Vertex> vertices)
        {
            Vertices = vertices;
            ComputeEdges();
        }
        public Polygon()
        {
            Vertices = new List<Vertex>();
            edges = new List<Edge>();
        }
        public bool DeleteVertex(Vertex v)
        {
            Vertices.Remove(v);
            if (Vertices.Count <= 2)
            {
                Vertices.RemoveAt(1);
                Vertices.RemoveAt(0);
            }
            else
            {
                if (v?.coming?.Relation != null) v.coming.Relation.Delete();
                if (v?.going?.Relation != null) v.going.Relation.Delete();
                var ind = edges.IndexOf(v.coming);
                edges.Remove(v.coming);
                edges.Remove(v.going);
                var newEdge = new Edge(v.coming.From, v.going.To);
                newEdge.PrevEdge = v.coming.From.coming;
                v.coming.From.going = newEdge;
                v.going.To.coming = newEdge;
                edges.Insert(ind%edges.Count, newEdge);
            }
            return Vertices.Count >= 3;
        }
        private void ComputeEdges()
        {
            edges = new List<Edge>();
            Edge prev = null;
            //Edge next = null;
            for (int i = 0; i < Vertices.Count - 1; i++)
            {
                var e = new Edge(Vertices[i], Vertices[i + 1]);
                if(prev != null) e.PrevEdge = prev;
                Vertices[i].going = e;
                Vertices[i + 1].coming = e;
                edges.Add(e);
                prev = e;
            }
            var lastEdge = new Edge(Vertices[Vertices.Count - 1], Vertices[0]);
            Vertices[Vertices.Count - 1].going = lastEdge;
            Vertices[0].coming = lastEdge;
            lastEdge.PrevEdge = prev;
            edges.Add(lastEdge);
            edges[0].PrevEdge = lastEdge;
        }
        // https://stackoverflow.com/a/14998816/6841224
        // The function counts the number of sides of the polygon that:
        //  - intersect the Y coordinate of the point (the first if() condition) 
        //  - are to the left of it (the second if() condition).
        // If the number of such sides is odd, then the point is inside the polygon
        public bool IsPointInsidePolygon(Point p)
        {
            bool result = false;
            int j = Vertices.Count - 1;
            int n = j + 1;
            for (int i = 0; i < n; ++i)
            {
                if ((Vertices[j].Y < p.Y && Vertices[i].Y >= p.Y) ||
                    (Vertices[i].Y < p.Y && Vertices[j].Y >= p.Y))
                {
                    if (Vertices[i].X + (p.Y - Vertices[i].Y) * (Vertices[j].X - Vertices[i].X)
                        / (double)(Vertices[j].Y - Vertices[i].Y) < p.X)
                    {
                        result = !result;
                    }
                }
                j = i;
            }

            return result;
        }
        public void TranslateWhole(Point delta)
        {
            foreach(var e in edges)
            {
                if(e.Relation != null && e.Relation.GetType() == typeof(Tangency))
                {
                    var tang = e.Relation as Tangency;
                    if (tang.circle.IsCenterAnchored && tang.circle.IsRadiusFixed) return;
                    else if (tang.circle.IsCenterAnchored) tang.circle.relation.PreserveRelation(null, tang.circle.point);
                    else tang.circle.point.point = new Point(tang.circle.X + delta.X, tang.circle.Y + delta.Y);
                }
            }
            foreach (var v in Vertices)
            {
                v.point = new Point(v.point.X + delta.X, v.point.Y + delta.Y);
            }
        }
    }





    public class Circle
    {
        public Vertex point { get; private set; }
        public Tangency relation { get; set; }
        public int X { get => point.X; }
        public int Y { get => point.Y; }
        public float Radius { get; set; }
        public bool IsCenterAnchored { get; set; }
        public bool IsRadiusFixed { get; set; }
        public Circle(Point point)
        {
            this.point = new Vertex(point);
            Radius = float.NaN;
        }
        public Circle()
        {
            this.point = new Vertex(new Point(0,0));
            Radius = float.NaN;
        }
        public bool SetRadius(float radius)
        {
            if (relation == null) Radius = radius;
            else
            {
                // coś
                var slope = relation.e1.Slope;
                float slope2 = -1f / relation.e1.Slope;
                var b2 = Y - X * slope2;
                var b1 = relation.e1.To.Y - relation.e1.To.X * slope;
                var x = (b1 - b2) / (slope2 - slope);
                var y = x * slope2 + b2;
                Point PoT = new Point((int)Math.Round(x), (int)Math.Round(y));
                var diff = radius - Radius;
                Point newPoT = Geometry.SameLinePoint(point.point, radius / Radius, PoT);
                relation.e1.To.Translate(new Point(newPoT.X - PoT.X, newPoT.Y - PoT.Y));
                relation.e1.From.Translate(new Point(newPoT.X - PoT.X, newPoT.Y - PoT.Y));
                //Radius = radius;
                //relation.PreserveRelation(null, point);
            }
            return true;
        }
        
    }





    public class Edge
    {
        public Vertex From { get; set; }
        public Vertex To { get; set; }
        public Edge PrevEdge { get; set; }
        public Relation Relation { get; set; }
        public bool IsLengthFixed { get; set; } = false;
        public float Slope
        {
            get 
            {
                if (To.X == From.X) return 100;
                return -(float)(From.Y - To.Y) / (float)(To.X - From.X); 
            }
            //get => (float)Math.Atan2(From.Y - To.Y, To.X - From.X);
        }
        public double SetSlope(float slope)
        {
            //bool below = From.Y < To.Y;
            var r = Vertex.Distance(From, To);
            double angle = slope;
            double x2;
            double y2;
            x2 = From.X - r * Math.Cos(angle);
            //else x2 = From.X - r * Math.Cos(angle);
            y2 = From.Y + r * Math.Sin(angle);
            //else y2 = From.Y + r * Math.Sin(angle);
            var newPoint = new Point((int)x2, (int)y2);
            var delta = new Point(newPoint.X - To.X, newPoint.Y - To.Y);
            //To.point = new Point((int)x2, (int)y2);
            if(delta.X != 0 || delta.Y != 0) To.Translate(delta);
            return 1;
        }
        public double SetSlope2(float slope)
        {
            Edge e = PrevEdge;
            float slope2 = e.Slope;
            var b2 = e.To.Y - e.To.X * slope2;
            var b1 = To.Y - To.X * slope;
            var x = (b1 - b2) / (slope2 - slope);
            var y = x * slope2 + b2;
            From.point = new Point((int)Math.Round(x), (int)Math.Round(y));
            return 1;
        }
        public void Offset(Point delta)
        {
            From.point = new Point(From.X + delta.X, From.Y + delta.Y);
            To.point = new Point(To.X + delta.X, To.Y + delta.Y);
        }
        public Edge(Vertex from, Vertex to)
        {
            From = from; To = to;
        }
        public Edge(Point from, Point to)
        {
            From = new Vertex(from);
            To = new Vertex(to);
        }
        public Edge()
        {
            From = To = new Vertex(new Point(0, 0));
        }
    }







    public class Vertex
    {
        public Point point { get; set; }
        public int X { get => point.X; }
        public int Y { get => point.Y; }
        public Edge coming;
        public Edge going;
        public Relation relation { get; set;  } = null;
        public Vertex(Point point)
        {
            this.point = point;
        }
        public Vertex()
        {
            point = new Point(0, 0);
        }
        public static List<Vertex> ToVertexList(List<Point> points)
        {
            var res = new List<Vertex>();
            foreach(var p in points)
            {
                res.Add(new Vertex(p));
            }
            return res;
        }
        public static double Distance(Vertex v1, Vertex v2)
        {
            float dist2 = (v1.point.X - v2.point.X) * (v1.point.X - v2.point.X) + (v1.point.Y - v2.point.Y) * (v1.point.Y - v2.point.Y);
            return Math.Sqrt(dist2);
        }
        public double DistanceToPoint(Point p)
        {
            float dist2 = (point.X - p.X) * (point.X - p.X) + (point.Y - p.Y) * (point.Y - p.Y);
            return Math.Sqrt(dist2);
        }
        public void Translate(Point delta)
        {
            if(coming?.Relation?.GetType() == typeof(Tangency) && (coming.Relation as Tangency).circle.IsCenterAnchored && (coming.Relation as Tangency).circle.IsRadiusFixed)
            {
                return;
            }
            if (going?.Relation?.GetType() == typeof(Tangency) && (going.Relation as Tangency).circle.IsCenterAnchored && (going.Relation as Tangency).circle.IsRadiusFixed)
            {
                return;
            }
            if(going?.Relation?.GetType() == typeof(SameLength) && going.Relation == coming.Relation && coming.From.coming.IsLengthFixed)
            {
                return;
            }
            point = new Point(point.X + delta.X, point.Y + delta.Y);
            if (going != null && going.IsLengthFixed)
            {
                going.To.TranslateGoing(delta);
            }
            if (coming != null && coming.IsLengthFixed)
            {
                coming.From.TranslateComing(delta);
            }
            if (coming == null && going == null)
            {
                relation?.PreserveRelation(null, this);
                relation?.e1.To.Translate(delta);
                relation?.e1.From.Translate(delta);
            }
            if (coming?.Relation != null)
            {
                coming.Relation.PreserveRelation(coming, this);
            }
            if(going?.Relation != null)
            {
                going.Relation.PreserveRelation(going, this);
            }
        }
        public void TranslateGoing(Point delta)
        {
            point = new Point(point.X + delta.X, point.Y + delta.Y);
            if (going.IsLengthFixed)
            {
                going.To.TranslateGoing(delta);
            }
            else if (going.Relation != null) going.Relation.PreserveRelation(going, this);
            else return;
        }
        public void TranslateComing(Point delta)
        {
            point = new Point(point.X + delta.X, point.Y + delta.Y);
            if (coming.IsLengthFixed)
            {
                coming.From.TranslateComing(delta);
            }
            else if (coming.Relation != null) coming.Relation.PreserveRelation(coming, this);
            else return;
        }
    }
}
