using DrawingApp.Drawing;
using DrawingApp.Drawing.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingApp
{
    public partial class Form1 : Form
    {
        bool isDrawing = false;
        public Form1()
        {
            InitializeComponent();
            Project.Canvases.Add(new Canvas());
            selectBtn.LostFocus += Deselect;
            Project
                .Canvases[tabControl.SelectedIndex]
                .Undo();
        }

        private void Deselect(object val, EventArgs e)
        {
            if (GlobalSettings.Instance.SelectedFigure != null)
            {
                GlobalSettings.Instance.SelectedFigure.UnsetControls(tabControl.SelectedIndex);
            }
            Console.WriteLine("Deselected");
            tabControl.SelectedTab.Controls[0].Invalidate();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tp = new TabPage();
            Random rnd = new Random();
            tp.Text = rnd.Next(0, 101) + "";
            tp.UseVisualStyleBackColor = true;
            tp.Size = defaultTab.Size;

            PictureBox pb = new PictureBox();
            pb.Dock = DockStyle.Fill;
            pb.MouseDown += new MouseEventHandler(tpMouseDown);
            pb.MouseMove += new MouseEventHandler(mouseMove);
            pb.Paint += new PaintEventHandler(rePaint);
            pb.MouseUp += new MouseEventHandler(MouseUp);

            Canvas canvas = new Canvas();
            Project.Canvases.Add(canvas);

            tp.Controls.Add(pb);
            this.tabControl.TabPages.Add(tp);
            tabControl.SelectedIndex = tabControl.TabPages.Count - 1;
        }

        private void tpMouseDown(object sender, MouseEventArgs e)
        {
            Point p = new Point(e.X, e.Y);

            if (!selectBtn.Focused)
            {
                isDrawing = true;
                if (GlobalSettings.Instance.SelectedFigure != null)
                {
                    GlobalSettings.Instance.SelectedFigure.StartingPoint = p;
                }
            }
            else 
            {
                Project.
                    Canvases[tabControl.SelectedIndex]
                    .PushToHistory();
                undoToolStripMenuItem.Enabled = true;
                GlobalSettings.Instance.SelectedFigure.Command = new Move(p);
                foreach (Figure f in Project.Canvases[tabControl.SelectedIndex].SelectionFigures)
                {
                    if (f.isPointInside(p))
                    {
                        GlobalSettings.Instance.ManipulationFigure = f;
                        break;
                    }
                    GlobalSettings.Instance.ManipulationFigure = null;
                    GlobalSettings.Instance.SelectedFigure.UnsetControls(tabControl.SelectedIndex);
                }

                foreach (Figure f in Project.Canvases[tabControl.SelectedIndex].Figures)
                {
                    if (f.isPointInside(p))
                    {
                        f.SetControls(tabControl.SelectedIndex);
                        GlobalSettings.Instance.SelectedFigure = f;
                        break;
                    }
                }
                tabControl.SelectedTab.Controls[0].Invalidate();
            }
        }
        private void MouseUp(object sender, MouseEventArgs e)
        {
            Point p = new Point(e.X, e.Y);
            if (GlobalSettings.Instance.SelectedFigure != null)
            {
                if (!selectBtn.Focused)
                {
                    isDrawing = false;
                    Graphics g = tabControl.SelectedTab.CreateGraphics();
                    GlobalSettings.Instance.SelectedFigure.EndingPoint =
                        new Point(p.X, p.Y);
                    Figure fig = (Figure)GlobalSettings.Instance.SelectedFigure.Clone();

                    //swap ncessary cordinates so that the starting point
                    //is at the upper left corner and the ending point is lower right

                    Project.
                        Canvases[tabControl.SelectedIndex]
                        .PushToHistory();
                    undoToolStripMenuItem.Enabled = true;

                    Project.
                        Canvases
                        .ElementAt(tabControl.SelectedIndex)
                        .Figures
                        .Add(fig);
                    fig.Draw(g);
                    perLbl.Text = $"Perimeter: {fig.GetPerimeter():#.##}";
                    areaLbl.Text = $"Area: {fig.GetArea():#.##}";
                    GlobalSettings.Instance.SelectedFigure.StartingPoint = new Point(0, 0);
                    GlobalSettings.Instance.SelectedFigure.EndingPoint = new Point(0, 0);
                }
                else
                {
                    GlobalSettings.Instance.ManipulationFigure = null;
                    GlobalSettings.Instance.SelectedFigure.Command = null;
                }
            }
        }


        private void mouseMove(object sender, MouseEventArgs e)
        {

            Point point = new Point(e.X, e.Y);
            if (isDrawing)
            {
                if (GlobalSettings.Instance.SelectedFigure != null)
                {
                    GlobalSettings.Instance.SelectedFigure.EndingPoint = point;
                }
            }
            else if (GlobalSettings.Instance.SelectedFigure != null)
            {
                if (GlobalSettings.Instance.ManipulationFigure != null)
                {
                    GlobalSettings.Instance.ManipulationFigure.Command.Execute(point);
                    GlobalSettings.Instance.SelectedFigure.fixPoints();
                }
                else if (GlobalSettings.Instance.SelectedFigure != null && GlobalSettings.Instance.SelectedFigure.Command != null)
                {
                    GlobalSettings.Instance.SelectedFigure.Command.Execute(point);
                    GlobalSettings.Instance.SelectedFigure.Command = new Move(point);
                }
                GlobalSettings.Instance.SelectedFigure.UnsetControls(tabControl.TabIndex);
                GlobalSettings.Instance.SelectedFigure.UnsetControls(tabControl.TabIndex);
                GlobalSettings.Instance.SelectedFigure.SetControls(tabControl.TabIndex);
                GlobalSettings.Instance.SelectedFigure.SetControls(tabControl.TabIndex);
            }
            tabControl.SelectedTab.Controls[0].Invalidate();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {

            GlobalSettings.Instance.SelectedFigure = new Drawing.Figures.Rectangle();
            RedrawCanvas(tabControl.SelectedTab.Controls[0].CreateGraphics());
        }

        private void RedrawCanvas(Graphics g)
        {

            var figs = Project.Canvases.ElementAt(tabControl.SelectedIndex).Figures;
            foreach (var f in figs)
            {

                f.Draw(g);
            }


            if (selectBtn.Focused)
            {
                var sFigs = Project.Canvases[tabControl.SelectedIndex].SelectionFigures;
                foreach (var f in sFigs)
                {
                    f.Draw(g);
                }
            }
        }

        private void rePaint(object sender, PaintEventArgs e)
        {
            if (GlobalSettings.Instance.SelectedFigure != null)
            {
                ((Figure)GlobalSettings.Instance.SelectedFigure.Clone()).Draw(e.Graphics);
            }
            RedrawCanvas(e.Graphics);
        }



        private void button3_Click(object sender, EventArgs e)
        {
            var rect = new Drawing.Figures.Square();
            GlobalSettings.Instance.SelectedFigure = rect;
        }

        private void rectangleBtn_Click(object sender, EventArgs e)
        {
            var rect = new Drawing.Figures.Rectangle();
            GlobalSettings.Instance.SelectedFigure = rect;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var circle = new Drawing.Figures.Circle();
            GlobalSettings.Instance.SelectedFigure = circle;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var el = new Drawing.Figures.Ellipse();
            GlobalSettings.Instance.SelectedFigure = el;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var line = new Drawing.Figures.Line();
            GlobalSettings.Instance.SelectedFigure = line;
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Project.Canvases[tabControl.SelectedIndex].Undo();
            redoToolStripMenuItem.Enabled = true;
            if (Project.Canvases[tabControl.SelectedIndex].UndoEmpty())
            {
                undoToolStripMenuItem.Enabled = false;
            }
            tabControl.SelectedTab.Controls[0].Invalidate();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Project.Canvases[tabControl.SelectedIndex].Redo();
            undoToolStripMenuItem.Enabled = true;
            if (Project.Canvases[tabControl.SelectedIndex].RedoEmpty())
            {
                redoToolStripMenuItem.Enabled = false;
            }
            tabControl.SelectedTab.Controls[0].Invalidate();
        }
    }
}
