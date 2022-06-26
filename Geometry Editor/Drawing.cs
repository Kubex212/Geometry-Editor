using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Geometry_Editor
{
    public static class Drawing
    {
        // http://tech-algorithm.com/articles/drawing-line-using-bresenham-algorithm/
        public static void DrawLine(Edge edge, Color color, Graphics g, int thickness)
        {
            Point A = edge.From.point;
            Point B = edge.To.point;
            int width = B.X - A.X;
            int height = B.Y - A.Y;
            Point d1 = new Point(Math.Sign(width), Math.Sign(height));

            Point d2;
            int longerDim = Math.Abs(width);
            int shorterDim = Math.Abs(height);
            if (longerDim < shorterDim)
            {
                (longerDim, shorterDim) = (shorterDim, longerDim);
                d2 = new Point(0, d1.Y);
            }
            else
                d2 = new Point(d1.X, 0);

            int numerator = longerDim >> 1;

            for (int i = 0; i <= longerDim; ++i)
            {
                g.FillRectangle(new SolidBrush(color), A.X, A.Y, thickness, thickness);


                numerator += shorterDim;
                if (numerator >= longerDim)
                {
                    numerator -= longerDim;
                    A.Offset(d1);
                }
                else
                {
                    A.Offset(d2);
                }
            }
        }
        public static void Draw(this Circle circle, Color color, PaintEventArgs e)
        {
            if (float.IsNaN(circle.Radius)) return;
            if (circle.IsRadiusFixed) color = Color.Red;
            if (circle.IsCenterAnchored) color = Color.DarkRed;
            if (circle.IsCenterAnchored && circle.IsRadiusFixed) color = Color.Purple;
            var pen = new Pen(color);
            e.Graphics.DrawEllipse(pen, circle.X - circle.Radius, circle.Y - circle.Radius, circle.Radius * 2, circle.Radius * 2);
            if(circle.relation != null)
            {
                var size = e.Graphics.MeasureString($"{circle.relation.Signature}{circle.relation.Number}", new Font("Arial", 16));
                Point where = circle.point.point;
                where.Offset((int)(size.Width / 2), 0);
                e.Graphics.DrawString($"{circle.relation.Signature}{circle.relation.Number}", new Font("Arial", 16), new SolidBrush(Color.Orange), where);
            }
        }

        public static void Draw(this Edge e, Graphics g, Color edgeColor, int thickness)
        {
            if(!e.IsLengthFixed) DrawLine(e, edgeColor, g, thickness);
            else DrawLine(e, Color.Red, g, thickness);
            if (e.Relation != null)
            {
                var midpoint = Geometry.EdgeMiddle(e);
                g.DrawString($"{e.Relation.Signature}{e.Relation.Number}", new Font("Arial", 16), new SolidBrush(Color.Orange), midpoint);
                //g.DrawString($"test {e.To.relation.Number}", new Font("Arial", 16), new SolidBrush(edgeColor), e.From.point);
                //MessageBox.Show($"jest {e.To.X}");
            }
        }
    }
}