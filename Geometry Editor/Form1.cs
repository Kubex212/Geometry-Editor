using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Geometry_Editor
{
    public partial class Form1 : Form
    {
        Mode mode;
        List<Point> points;
        List<Point> temppoints;
        List<Polygon> polygons;
        List<Edge> tempedges;
        List<Circle> circles;

        Edge tempedge;
        Color vertexColor = Color.Cyan;
        Color edgeColor = Color.White;
        Color selectedEdgeColor = Color.Yellow;
        Color selectedVertexColor = Color.LightYellow;
        Point prevMousePos = Point.Empty;
        Edge[] relationEdges;

        Vertex selectedVertex = null;
        Edge selectedEdge = null;
        Polygon selectedPolygon = null;
        Circle selectedCircle = null;
        public Form1()
        {
            InitializeComponent();
            points = new List<Point>();
            temppoints = new List<Point>();
            polygons = new List<Polygon>();
            tempedges = new List<Edge>();
            circles = new List<Circle>();
            relationEdges = new Edge[2];

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        enum Mode
        {
            AddVertices,
            MoveVertices,
            AddCircle,
            ChoosingRadius,
            AddingParallelism,
            AddingTangency,
            AddingSL,
            LockingEdge,
            LockingRadius,
            DeletingRelation
        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            var brush = new SolidBrush(vertexColor);
            var blackBrush = new SolidBrush(Color.Black);
            var vertexRadius = vertexBar.Value;
            foreach (var ed in tempedges)
            {
                ed.Draw(e.Graphics, edgeColor, thicknessSlider.Value);
            }
            foreach (var p in polygons)
            {
                foreach(var ed in p.edges)
                {
                    if(selectedEdge != ed)ed.Draw(e.Graphics, edgeColor, thicknessSlider.Value);
                    else ed.Draw(e.Graphics, selectedEdgeColor, thicknessSlider.Value);
                }
                foreach(var v in p.Vertices)
                {
                    e.Graphics.FillEllipse(brush, v.point.X-vertexBar.Value/2, v.point.Y-vertexBar.Value / 2, vertexBar.Value, vertexBar.Value);
                }
            }
            foreach(var c in circles)
            {
                if (c == null) continue;
                c.Draw(edgeColor, e);
            }
            foreach (var ed in relationEdges)
            {
                if(ed != null) ed.Draw(e.Graphics, Color.Blue, thicknessSlider.Value);
            }
            if (mode == Mode.ChoosingRadius && selectedCircle != null)
            {
                selectedCircle.Draw(edgeColor, e);
            }
            if(selectedVertex != null) e.Graphics.FillEllipse(new SolidBrush(selectedVertexColor), selectedVertex.point.X - vertexBar.Value / 2, selectedVertex.point.Y - vertexBar.Value / 2, vertexBar.Value, vertexBar.Value);
            if (mode == Mode.AddVertices && temppoints.Count >=1 && tempedge != null) tempedge.Draw(e.Graphics, edgeColor, thicknessSlider.Value);
        }

        // -------------------------------------------------- MOUSE CLICK --------------------------------------------------
        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            var mousePos = pictureBox.PointToClient(new Point(MousePosition.X, MousePosition.Y));
            Point pos = pictureBox.PointToClient(new Point(MousePosition.X, MousePosition.Y));
            if (mode == Mode.AddVertices && e.Button == MouseButtons.Left)
            {
                if (temppoints.Count > 0) tempedges.Add(new Edge(temppoints[temppoints.Count - 1], pos));
                temppoints.Add(pos);
                pictureBox.Invalidate();
            }
            else if (mode == Mode.AddVertices && e.Button == MouseButtons.Right)
            {
                if (temppoints.Count >= 3) polygons.Add(new Polygon(Vertex.ToVertexList(temppoints)));
                temppoints = new List<Point>();
                tempedges = new List<Edge>();
                pictureBox.Cursor = Cursors.Cross;
                if (mode == Mode.AddVertices) addbutton.BackColor = Color.White;
                movebutton.PerformClick();
                pictureBox.Invalidate();
            }
            else if (mode == Mode.AddCircle)
            {
                selectedCircle = new Circle(pos);
                mode = Mode.ChoosingRadius;
            }
            else if (mode == Mode.ChoosingRadius)
            {
                circles.Add(selectedCircle);
                mode = Mode.MoveVertices;
                movebutton.PerformClick();
                selectedCircle = null;
            }
            else if (mode == Mode.AddingParallelism || mode == Mode.AddingSL || mode == Mode.LockingEdge || mode == Mode.DeletingRelation)
            {
                foreach (var p in polygons)
                {
                    foreach (var ed in p.edges)
                    {
                        //nad krawędzią?
                        double dist = ed.From.DistanceToPoint(mousePos) + ed.To.DistanceToPoint(mousePos) - Vertex.Distance(ed.From, ed.To);
                        if (dist <= thicknessSlider.Value / 2 && mode == Mode.LockingEdge)
                        {
                            bool canAdd = false;
                            foreach (var ed2 in p.edges)
                            {
                                if (!ed2.IsLengthFixed && ed2 != ed)
                                {
                                    canAdd = true;
                                    break;
                                }
                            }
                            if (canAdd)
                            {
                                numericUpDown1.Enabled = true;
                                numericUpDown1.Visible = true;
                                numericUpDown1.Value = (decimal)Vertex.Distance(ed.From, ed.To);
                                okbutton.Visible = true;
                                selectedEdge = ed;
                            }
                            else
                            {
                                MessageBox.Show("It is impossible for all edges to have fixed length", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        else if (dist <= thicknessSlider.Value / 2 && mode == Mode.DeletingRelation)
                        {
                            if(ed.Relation == null)
                            {
                                MessageBox.Show("This edge does not have any relation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                movebutton.PerformClick();
                                return;
                            }
                            ed.Relation.Delete();
                            movebutton.PerformClick();
                        }
                        else if (dist <= thicknessSlider.Value / 2 && ed.Relation != null)
                        {
                            MessageBox.Show("This edge already belongs to a relation. Please delete if first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (dist <= thicknessSlider.Value / 2 && relationEdges[0] == null)
                        {
                            relationEdges[0] = ed;
                        }
                        else if (dist <= thicknessSlider.Value / 2 && relationEdges[0] != null && relationEdges[1] == null && ed != relationEdges[0] && mode == Mode.AddingParallelism)
                        {
                            relationEdges[1] = ed;
                            Parallelity relation;
                            if (relationEdges[0].To != ed.From && ed.To != relationEdges[0].From)
                            {
                                relation = new Parallelity(relationEdges[0], relationEdges[1]);
                                relationEdges[0].Relation = relation;
                                ed.Relation = relation;
                                MessageBox.Show("relation added");
                            }
                            else MessageBox.Show("Impossible operation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            relationEdges = new Edge[2];
                            movebutton.PerformClick();
                        }
                        else if (dist <= thicknessSlider.Value / 2 && relationEdges[0] != null && relationEdges[1] == null && ed != relationEdges[0] && mode == Mode.AddingSL)
                        {
                            relationEdges[1] = ed;
                            SameLength relation;
                            if (relationEdges[0].To != ed.From || ed.To != relationEdges[0].From)
                            {
                                relation = new SameLength(relationEdges[0], relationEdges[1]);
                                relationEdges[0].Relation = relation;
                                ed.Relation = relation;
                                ed.To.Translate(new Point(0, 0));
                                pictureBox.Invalidate();
                            }
                            else MessageBox.Show("Impossible operation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            relationEdges = new Edge[2];
                            movebutton.PerformClick();
                        }
                    }
                }
            }
            else if(mode == Mode.AddingTangency || mode == Mode.LockingRadius || e.Button == MouseButtons.Right)
            {
                if(relationEdges[0] == null && e.Button != MouseButtons.Right && mode != Mode.LockingRadius)
                {
                    foreach (var p in polygons)
                    {
                        foreach (var ed in p.edges)
                        {
                            //nad krawędzią?
                            double dist = ed.From.DistanceToPoint(mousePos) + ed.To.DistanceToPoint(mousePos) - Vertex.Distance(ed.From, ed.To);
                            if (dist <= thicknessSlider.Value / 2 && relationEdges[0] == null)
                            {
                                relationEdges[0] = ed;
                            }
                        }
                    }
                }
                else if ((relationEdges[0] != null && relationEdges[1] == null) || mode == Mode.LockingRadius || e.Button == MouseButtons.Right)
                {
                    foreach (var c in circles)
                    {
                        if(mode == Mode.LockingRadius && e.Button != MouseButtons.Right && c.point.DistanceToPoint(mousePos) < 0.95 * c.Radius)
                        {
                            numericUpDown2.Enabled = true;
                            numericUpDown2.Visible = true;
                            numericUpDown2.Value = (decimal)c.Radius;
                            okbutton2.Visible = true;
                            selectedCircle = c;
                        }
                        else if (c.point.DistanceToPoint(mousePos) < c.Radius)
                        {
                            if (relationEdges[0] != null && relationEdges[1] == null && e.Button != MouseButtons.Right)
                            {
                                relationEdges[0].Relation = new Tangency(relationEdges[0], c);
                                relationEdges[0].Relation.PreserveRelation(relationEdges[0], null);
                                c.relation = (Tangency)relationEdges[0].Relation;
                            }
                            else if (e.Button == MouseButtons.Right)
                            {
                                c.IsCenterAnchored = !c.IsCenterAnchored;
                                pictureBox.Invalidate();
                            }
                        }
                    }
                }
            }
        }

        // -------------------------------------------------- MOUSE MOVE --------------------------------------------------
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            var mousePos = pictureBox.PointToClient(new Point(MousePosition.X, MousePosition.Y));
            var delta = new Point(MousePosition.X - prevMousePos.X, MousePosition.Y  - prevMousePos.Y);
            prevMousePos = MousePosition;
            if (mode == Mode.AddVertices && temppoints.Count > 0)
            {
                tempedge = new Edge(temppoints[temppoints.Count - 1], pictureBox.PointToClient(new Point(MousePosition.X, MousePosition.Y)));
                pictureBox.Invalidate();
            }
            else if (mode == Mode.MoveVertices && selectedVertex != null)
            {
                selectedVertex.Translate(delta);
                pictureBox.Invalidate();
            }
            else if (mode == Mode.MoveVertices && selectedEdge != null && selectedVertex == null)
            {
                selectedEdge.From.Translate(delta);
                if(!selectedEdge.IsLengthFixed)selectedEdge.To.Translate(delta);
                pictureBox.Invalidate();
            }
            else if (mode == Mode.MoveVertices && selectedVertex == null && selectedPolygon != null)
            {
                selectedPolygon.TranslateWhole(delta);
                pictureBox.Invalidate();
            }
            else if (mode == Mode.ChoosingRadius && selectedCircle != null)
            {
                selectedCircle.SetRadius((float)selectedCircle.point.DistanceToPoint(pictureBox.PointToClient(MousePosition)));
                pictureBox.Invalidate();
            }
            else if (mode == Mode.MoveVertices && selectedCircle != null)
            {
                selectedCircle.point.Translate(delta);
                pictureBox.Invalidate();
            }
        }
        // -------------------------------------------------- MOUSE DOWN --------------------------------------------------
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            var mousePos = pictureBox.PointToClient(new Point(MousePosition.X, MousePosition.Y));
            if(mode == Mode.MoveVertices)
            {
                foreach (var p in polygons)
                {
                    foreach (var v in p.Vertices)
                    {
                        var vertex = v.point;
                        //nad wierzchołkiem?
                        if ((vertex.X - mousePos.X) * (vertex.X - mousePos.X) + (vertex.Y - mousePos.Y) * (vertex.Y - mousePos.Y) <= vertexBar.Value * vertexBar.Value)
                        {
                            selectedVertex = v;
                            selectedPolygon = p;
                        }
                        pictureBox.Invalidate();
                    }
                    foreach (var ed in p.edges)
                    {
                        //nad krawędzią?
                        double dist = ed.From.DistanceToPoint(mousePos) + ed.To.DistanceToPoint(mousePos) - Vertex.Distance(ed.From, ed.To);
                        if (dist <= thicknessSlider.Value / 2 && selectedVertex == null)
                        {
                            selectedEdge = ed;
                            selectedPolygon = p;
                        }
                    }
                    //nad wielokątem?
                    if (p.IsPointInsidePolygon(mousePos)) selectedPolygon = p;
                }
                foreach(var c in circles)
                {
                    //nad okręgiem?
                    if (c.point.DistanceToPoint(mousePos) < 0.95*c.Radius && c.IsCenterAnchored == false) selectedCircle = c;
                    else if (c.point.DistanceToPoint(mousePos) >= 0.95 * c.Radius && c.point.DistanceToPoint(mousePos) < 1.05 * c.Radius && c.IsRadiusFixed == false)
                    {
                        selectedCircle = c;
                        mode = Mode.ChoosingRadius;
                    }
                }
            }
        }

        // -------------------------------------------------- MOUSE DOUBLECLICK --------------------------------------------------
        private void pictureBox_DoubleClick(object sender, EventArgs e)
        {
            var mousePos = pictureBox.PointToClient(MousePosition);
            for(int i = 0; i<polygons.Count; i++)
            {
                var p = polygons[i];
                for (int j = 0; j < p.edges.Count; j++)
                {
                    var ed = p.edges[j];
                    //nad krawędzią?
                    double dist = ed.From.DistanceToPoint(mousePos) + ed.To.DistanceToPoint(mousePos) - Vertex.Distance(ed.From, ed.To);
                    if (dist <= thicknessSlider.Value / 2 && mode != Mode.LockingEdge)
                    {
                        ed.Relation?.Delete();
                        var newVertex = new Vertex(mousePos);
                        var index = p.Vertices.IndexOf(ed.To);
                        p.Vertices.Insert(index, newVertex);
                        Vertex v = ed.To;
                        ed.To = newVertex;
                        Edge newEdge = new Edge(newVertex, v);
                        if (index == 0) index = p.edges.Count - 1;
                        newVertex.coming = p.edges[index];
                        newVertex.going = newEdge;
                        p.edges.Insert(index, newEdge);
                        break;
                    }
                    else if (dist <= thicknessSlider.Value / 2)
                    {
                        ed.IsLengthFixed = true;
                        var oldLength = Vertex.Distance(ed.From, ed.To);
                        var newLength = numericUpDown1.Value;
                        var newPoint = Geometry.SameLinePoint(ed.From.point, (double)newLength / oldLength, ed.To.point);
                        var delta = new Point(newPoint.X - ed.To.X, newPoint.Y - ed.To.Y);
                        ed.To.Translate(delta);
                        numericUpDown1.Enabled = false;
                        numericUpDown1.Visible = false;
                        movebutton.PerformClick();
                    }
                }
            }
        }
        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            selectedVertex = null;
            selectedPolygon = null;
            if(mode == Mode.MoveVertices) selectedCircle = null;
            if (mode == Mode.MoveVertices) selectedEdge = null;
            pictureBox.Invalidate();
        }

        private void kolorWierzchołkówToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = false;
            MyDialog.ShowHelp = true;
            MyDialog.Color = vertexColor;

            if (MyDialog.ShowDialog() == DialogResult.OK)
               vertexColor = MyDialog.Color;
            pictureBox.Invalidate();
        }

        private void vertexBar_Scroll(object sender, EventArgs e)
        {
            pictureBox.Invalidate();
        }

        private void thicknessSlider_Scroll(object sender, EventArgs e)
        {
            pictureBox.Invalidate();
        }


        // -------------------------------------------------- BUTTONS --------------------------------------------------
        private void addbutton_Click(object sender, EventArgs e)
        {
            mode = Mode.AddVertices;
            pictureBox.Cursor = Cursors.Default;
            WhiteButtons();
            addbutton.BackColor = Color.Gray;
        }

        private void movebutton_Click(object sender, EventArgs e)
        {
            mode = Mode.MoveVertices;
            pictureBox.Cursor = Cursors.SizeAll;
            WhiteButtons();
            movebutton.BackColor = Color.Gray;
            relationEdges = new Edge[2];
        }
        private void addcirclebutton_Click(object sender, EventArgs e)
        {
            mode = Mode.AddCircle;
            pictureBox.Cursor = Cursors.Default;
            WhiteButtons();
            addcirclebutton.BackColor = Color.Gray;
        }
        private void addrelationbutton_Click(object sender, EventArgs e)
        {
            mode = Mode.AddingParallelism;
            WhiteButtons();
            addrelationbutton.BackColor = Color.Gray;
        }
        private void addtangencybutton_Click(object sender, EventArgs e)
        {
            mode = Mode.AddingTangency;
            WhiteButtons();
            addtangencybutton.BackColor = Color.Gray;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            mode = Mode.AddingSL;
            WhiteButtons();
            addingslbutton.BackColor = Color.Gray;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            mode = Mode.LockingEdge;
            WhiteButtons();
            lockedgebutton.BackColor = Color.Gray;
        }
        private void okbutton_Click(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = false;
            numericUpDown1.Visible = false;
            okbutton.Visible = false;
            if (selectedEdge != null) selectedEdge.IsLengthFixed = !selectedEdge.IsLengthFixed;
            movebutton.PerformClick();
            selectedEdge = null;
            pictureBox.Invalidate();
        }
        private void lockradiusbutton_Click(object sender, EventArgs e)
        {
            mode = Mode.LockingRadius;
            WhiteButtons();
            lockradiusbutton.BackColor = Color.Gray;
        }
        private void okbutton2_Click(object sender, EventArgs e)
        {
            numericUpDown2.Enabled = false;
            numericUpDown2.Visible = false;
            okbutton2.Visible = false;
            selectedCircle.Radius = (float)numericUpDown2.Value;
            if (selectedCircle != null) selectedCircle.IsRadiusFixed = !selectedCircle.IsRadiusFixed;
            movebutton.PerformClick();
            selectedCircle = null;
            pictureBox.Invalidate();
        }
        private void deleterelationbutton_Click(object sender, EventArgs e)
        {
            mode = Mode.DeletingRelation;
            WhiteButtons();
            deleterelationbutton.BackColor = Color.Gray;
        }


        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (selectedVertex != null && e.KeyCode == Keys.Delete) if (!selectedPolygon.DeleteVertex(selectedVertex))
                {
                    polygons.Remove(selectedPolygon);
                    selectedPolygon = null;
                    selectedVertex = null;
                    pictureBox.Invalidate();
                    return;
                }
            if (selectedCircle != null && e.KeyCode == Keys.Delete)
            {
                circles.Remove(selectedCircle);
            }
            if(selectedPolygon != null && selectedVertex == null)
            {
                foreach(var ed in selectedPolygon.edges)
                {
                    if (ed.Relation != null) ed.Relation.Delete();
                    polygons.Remove(selectedPolygon);
                    selectedPolygon = null;
                }
            }
            pictureBox.Invalidate();
        }

        private void kolorKrawędziToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = false;
            MyDialog.ShowHelp = true;
            MyDialog.Color = vertexColor;

            if (MyDialog.ShowDialog() == DialogResult.OK)
                edgeColor = MyDialog.Color;
            pictureBox.Invalidate();
        }

        private void kolorTłaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = false;
            MyDialog.ShowHelp = true;
            MyDialog.Color = vertexColor;

            if (MyDialog.ShowDialog() == DialogResult.OK)
                pictureBox.BackColor = MyDialog.Color;
            pictureBox.Invalidate();
        }

        private void kolorWybranejKrawędziToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = false;
            MyDialog.ShowHelp = true;
            MyDialog.Color = vertexColor;

            if (MyDialog.ShowDialog() == DialogResult.OK)
                selectedEdgeColor = MyDialog.Color;
            pictureBox.Invalidate();
        }
        private void WhiteButtons()
        {
            addingslbutton.BackColor = Color.White;
            addtangencybutton.BackColor = Color.White;
            addrelationbutton.BackColor = Color.White;
            movebutton.BackColor = Color.White;
            addbutton.BackColor = Color.White;
            addcirclebutton.BackColor = Color.White;
            lockedgebutton.BackColor = Color.White;
            lockradiusbutton.BackColor = Color.White;
            deleterelationbutton.BackColor = Color.White;
        }

        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var saveFileDialog = new SaveFileDialog();
            //saveFileDialog.InitialDirectory = "c:\\";
            ////saveFileDialog.Filter = "xml files (*.xml)|*.xml";
            //saveFileDialog.Title = "Save a JSON file";
            //saveFileDialog.FilterIndex = 0;
            //saveFileDialog.RestoreDirectory = true;
            //Save currentSave = new Save(polygons, circles);
            //saveFileDialog.ShowDialog();

            //if (saveFileDialog.FileName != "")
            //{
            //    var options = new JsonSerializerOptions { ReferenceHandler = ReferenceHandler.Preserve };
            //    var settings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Serialize };
            //    string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(currentSave, settings);
            //    File.WriteAllText(saveFileDialog.FileName, jsonString);
            //}
        }

        private void otwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var openFileDialog = new OpenFileDialog();
            //openFileDialog.InitialDirectory = "c:\\";
            ////openFileDialog.Filter = "xml files (*.xml)|*.xml";
            //openFileDialog.Title = "Select an XML file";
            //openFileDialog.FilterIndex = 0;
            //openFileDialog.RestoreDirectory = false;

            //if (openFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    Save newSave;
            //    string jsonString;
                
            //    {
            //        try { jsonString = File.ReadAllText(openFileDialog.FileName); }
            //        catch(FileNotFoundException) { return; }
            //        //try { newSave = (Save)JsonSerializer.Deserialize(jsonString, typeof(Save)); }
            //        //catch (InvalidOperationException)
            //        //{
            //        //    MessageBox.Show("Bad XML file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        //    newSave = null;
            //        //    return;
            //        //}
            //        var options = new JsonSerializerOptions { ReferenceHandler = ReferenceHandler.Preserve };
            //        var settings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Serialize };
            //        newSave = (Save)Newtonsoft.Json.JsonConvert.DeserializeObject<Save>(jsonString, settings);

            //    }
            //    polygons = newSave.polygons;
            //    circles = newSave.circles;
            //    pictureBox.Invalidate();
        }
        private void CreateScene()
        {
            List<Point> points = new List<Point> { new Point(50, 100), new Point(100, 50), new Point(300, 50), new Point(400, 125), new Point(500, 200), new Point(500, 350), new Point(300, 400), new Point(50, 300) };
            polygons.Add(new Polygon(Vertex.ToVertexList(points)));
            polygons[0].edges[0].IsLengthFixed = polygons[0].edges[1].IsLengthFixed = polygons[0].edges[2].IsLengthFixed = true;
            points = new List<Point> { new Point(550, 400), new Point(750, 400), new Point(600, 600), new Point(400, 600) };
            polygons.Add(new Polygon(Vertex.ToVertexList(points)));
            Circle c1 = new Circle(new Point(150, 400));
            c1.Radius = 50;
            Circle c2 = new Circle(new Point(700, 150));
            c2.SetRadius(120);
            circles.Add(c1);
            circles.Add(c2);
            Tangency tang = new Tangency(polygons[0].edges[6], c1);
            c1.point.Translate(new Point(0, 0));
            c1.IsRadiusFixed = true;
            Parallelity par = new Parallelity(polygons[1].edges[0], polygons[1].edges[2]);
            polygons[1].edges[0].Relation = par;
            polygons[1].edges[2].Relation = par;
            Parallelity par2 = new Parallelity(polygons[1].edges[1], polygons[1].edges[3]);
            polygons[1].edges[1].Relation = par2;
            polygons[1].edges[3].Relation = par2;
            SameLength sl = new SameLength(polygons[0].edges[3], polygons[0].edges[4]);
            polygons[0].edges[3].Relation = sl;
            polygons[0].edges[4].Relation = sl;
            //polygons[1].edges[0].Relation = tang;
            //c2.relation = tang;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            movebutton.PerformClick();
            CreateScene();
        }
    }
    public class Save
    {
        public List<Polygon> polygons { get; set; }
        public List<Circle> circles { get; set; }
        public Save(List<Polygon> p, List<Circle> c)
        {
            polygons = p; circles = c;
        }
        public Save() { }
    }
}
