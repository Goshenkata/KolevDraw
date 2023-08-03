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
using System.Xml;

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

        private void CreateTab(string name)
        {
            var tp = new TabPage();
            tp.Text = name;
            tp.UseVisualStyleBackColor = true;
            tp.Size = defaultTab.Size;

            PictureBox pb = new PictureBox();
            pb.Dock = DockStyle.Fill;
            pb.MouseDown += new MouseEventHandler(tpMouseDown);
            pb.MouseMove += new MouseEventHandler(mouseMove);
            pb.Paint += new PaintEventHandler(rePaint);
            pb.MouseUp += new MouseEventHandler(MouseUp);

            Canvas canvas = new Canvas();
            canvas.Name = name;
            Project.Canvases.Add(canvas);

            tp.Controls.Add(pb);
            this.tabControl.TabPages.Add(tp);
            tabControl.SelectedIndex = tabControl.TabPages.Count - 1;
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabName tabName = new TabName();
            tabName.ShowDialog();
            if (tabName.Create)
            {
                CreateTab(tabName.PrName);
            }
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
                        colorDialog1.Color = f.Settings.FillColor;
                        colorDialog2.Color = f.Settings.FillColor;
                        pictureBox2.BackColor = f.Settings.FillColor;
                        pictureBox3.BackColor = f.Settings.BorderColor;
                        numericUpDown1.Value = f.Settings.StrokeWidth;
                        delBtn.Enabled = true;
                        break;
                    }

                }
                tabControl.SelectedTab.Controls[0].Invalidate();

            }
        }
        private void MouseUp(object sender, MouseEventArgs e)
        {
            Point p = new Point(e.X, e.Y);
            if (!selectBtn.Focused && isDrawing)
            {
                isDrawing = false;
                Graphics g = tabControl.SelectedTab.CreateGraphics();
                GlobalSettings.Instance.SelectedFigure.EndingPoint =
                    new Point(p.X, p.Y);
                Figure fig = (Figure)GlobalSettings.Instance.SelectedFigure.Clone();
                fig.Settings = (FigureSettings)GlobalSettings.Instance.Settings.Clone();

                //swap ncessary cordinates so that the starting point
                //is at the upper left corner and the ending point is lower right


                fig.Draw(g);

                Project.
                    Canvases[tabControl.SelectedIndex]
                    .PushToHistory();

                Project.
                    Canvases
                    .ElementAt(tabControl.SelectedIndex)
                    .Figures
                    .Add(fig);

                undoToolStripMenuItem.Enabled = true;
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


        private void mouseMove(object sender, MouseEventArgs e)
        {

            Point point = new Point(e.X, e.Y);
            if (isDrawing)
            {
                GlobalSettings.Instance.SelectedFigure.EndingPoint = point;
                GlobalSettings.Instance.SelectedFigure.Settings = (FigureSettings)GlobalSettings.Instance.Settings.Clone();
            }
            else
            {
                if (GlobalSettings.Instance.ManipulationFigure != null)
                {
                    GlobalSettings.Instance.ManipulationFigure.Command.Execute(point);
                    GlobalSettings.Instance.SelectedFigure.fixPoints();
                }
                else if (GlobalSettings.Instance.SelectedFigure.Command != null)
                {
                    GlobalSettings.Instance.SelectedFigure.Command.Execute(point);
                    GlobalSettings.Instance.SelectedFigure.Command = new Move(point);
                }
                GlobalSettings.Instance.SelectedFigure.UnsetControls(tabControl.SelectedIndex);
                GlobalSettings.Instance.SelectedFigure.UnsetControls(tabControl.SelectedIndex);
                GlobalSettings.Instance.SelectedFigure.SetControls(tabControl.SelectedIndex);
                GlobalSettings.Instance.SelectedFigure.SetControls(tabControl.SelectedIndex);
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
            if (isDrawing)
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
            Deselect(sender, e);
            GlobalSettings.Instance.SelectedFigure = new Drawing.Figures.Rectangle();
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
            Deselect(sender, e);
            GlobalSettings.Instance.SelectedFigure = new Drawing.Figures.Rectangle();
            tabControl.SelectedTab.Controls[0].Invalidate();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = colorDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                pictureBox2.BackColor = colorDialog1.Color;
                GlobalSettings.Instance.Settings.FillColor = colorDialog1.Color;
                GlobalSettings.Instance.SelectedFigure.Settings.FillColor = colorDialog1.Color;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = colorDialog2.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                pictureBox3.BackColor = colorDialog2.Color;
                GlobalSettings.Instance.Settings.BorderColor = colorDialog2.Color;
                GlobalSettings.Instance.SelectedFigure.Settings.BorderColor = colorDialog2.Color;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            GlobalSettings.Instance.Settings.StrokeWidth = ((int)numericUpDown1.Value);
            GlobalSettings.Instance.SelectedFigure.Settings.StrokeWidth = ((int)numericUpDown1.Value);
            tabControl.SelectedTab.Controls[0].Invalidate();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "SVG files (*.svg)|*.svg";
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FileName = Project.Canvases[tabControl.SelectedIndex].Name;
            DialogResult dialogResult = saveFileDialog1.ShowDialog();
            if (dialogResult.Equals(DialogResult.OK))
            {
                Deselect(sender, e);
                Save(saveFileDialog1.FileName);
            }
        }
        private void Save(string path)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement svgElement = xmlDoc.CreateElement("svg");


            svgElement.SetAttribute("xmlns", "http://www.w3.org/2000/svg");
            svgElement.SetAttribute("xml:space", "preserve");
            svgElement.SetAttribute("width", "1366");
            svgElement.SetAttribute("height", "768");
            xmlDoc.AppendChild(svgElement);

            Project
                .Canvases[tabControl.SelectedIndex]
                .Figures
                .ForEach(s => s.SeriliazeToSvg(ref xmlDoc));


            xmlDoc.Save(path);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "SVG files (*.svg)|*.svg";
            openFileDialog1.RestoreDirectory = true;
            isDrawing = false;
            DialogResult dialogResult = openFileDialog1.ShowDialog();
            if (dialogResult.Equals(DialogResult.OK))
            {
                Deselect(sender, e);
                List<Figure> figures = Open(openFileDialog1.FileName);
                string[] fileNameSplit = openFileDialog1.FileName.Split('\\');
                CreateTab(fileNameSplit[fileNameSplit.Length - 1].Replace(".svg", ""));
                Project.Canvases[tabControl.SelectedIndex].Figures = figures;
                tabControl.SelectedTab.Controls[0].Invalidate();
            }
        }

        private List<Figure> Open(string fileName)
        {
            List<Figure> output = new List<Figure>();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            XmlNodeList childNodes = xmlDoc.GetElementsByTagName("svg")[0].ChildNodes;
            foreach (XmlNode childNode in childNodes)
            {
                switch (childNode.Name)
                {
                    case "rect":

                        int width = int.Parse(childNode.Attributes["width"].Value);
                        int height = int.Parse(childNode.Attributes["height"].Value);
                        if (width == height)
                        {
                            output.Add(new Drawing.Figures.Square(childNode));
                        }
                        else
                        {
                            output.Add(new Drawing.Figures.Rectangle(childNode));
                        }
                        break;
                    case "circle":
                        output.Add(new Drawing.Figures.Circle(childNode));
                        break;

                    case "ellipse":
                        output.Add(new Drawing.Figures.Ellipse(childNode));
                        break;
                    case "line":
                        output.Add(new Drawing.Figures.Line(childNode));
                        break;

                }
            }

            return output;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Project.Canvases[tabControl.SelectedIndex].PushToHistory();
            Project.Canvases[tabControl.SelectedIndex]
                .Figures
                .Remove(GlobalSettings.Instance.SelectedFigure);
            GlobalSettings.Instance.SelectedFigure = new Drawing.Figures.Rectangle();
            tabControl.SelectedTab.Controls[0].Invalidate();
        }


        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Project.Canvases.RemoveAt(tabControl.SelectedIndex);
            tabControl.TabPages.RemoveAt(tabControl.SelectedIndex);
            tabControl.SelectedTab.Controls[0].Invalidate();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Info info = new Info(
                    Project.Canvases[tabControl.SelectedIndex].Figures,
                    tabControl.SelectedTab.Text
                );
            info.Show();
        }
    }
}
