using DrawingApp.Drawing;
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

        }

        private void Deselect(object val, EventArgs e)
        {
            GlobalSettings.Instance.SelectedFigure.UnsetControls(tabControl.SelectedIndex);
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
            pb.MouseClick += new MouseEventHandler(MouseClick);

            Canvas canvas = new Canvas();
            Project.Canvases.Add(canvas);

            tp.Controls.Add(pb);
            this.tabControl.TabPages.Add(tp);
            tabControl.SelectedIndex = tabControl.TabPages.Count - 1;
        }

        private void tpMouseDown(object sender, MouseEventArgs e)
        {
            Point p = new Point(e.X, e.Y);

            Console.WriteLine(selectBtn.Focused); 
            if (!selectBtn.Focused)
            {
                isDrawing = true;
                GlobalSettings.Instance.SelectedFigure.StartingPoint = p;
            }
            else
            {
                foreach (Figure sf in Project.Canvases[tabControl.SelectedIndex].SelectionFigures)
                {
                    if (sf.isPointInside(p))
                    {
                        GlobalSettings.Instance.ManipulationFigure = sf;
                        break;
                    }
                    GlobalSettings.Instance.ManipulationFigure = null;
                }
            }
        }

        private void SaveSelected(Point p)
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

        private void mouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                GlobalSettings.Instance.SelectedFigure.EndingPoint =
                    new Point(e.X, e.Y);
                tabControl.SelectedTab.Controls[0].Invalidate();
            }
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

        private void MouseClick(object sender, MouseEventArgs e)
        {
            Point p = new Point(e.X, e.Y);
            if (selectBtn.Focused)
            {
                foreach (Figure f in Project.Canvases[tabControl.SelectedIndex].SelectionFigures)
                {
                    if (f.isPointInside(p))
                    {
                        break;
                    }
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
            }
            else if (isDrawing)
            {
                SaveSelected(p);
            }
            tabControl.SelectedTab.Controls[0].Invalidate();
        }

    }
}
