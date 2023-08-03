using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApp.Drawing
{
    class Canvas
    {
        public List<Figure> Figures { get; set; }
        public List<Figure> SelectionFigures { get; set; }
        public string Name { get; set; } = "Untitled";
        private Stack<List<Figure>> UndoHistory { get; set; }
        private Stack<List<Figure>> RedoHistory { get; set; }
        public Canvas()
        {
            this.Figures = new List<Figure>();
            this.SelectionFigures = new List<Figure>();
            this.UndoHistory = new Stack<List<Figure>>();
            this.RedoHistory = new Stack<List<Figure>>();
        }
        public bool UndoEmpty()
        {
            return this.UndoHistory.Count == 0;
        }
        public bool RedoEmpty()
        {
            return this.RedoHistory.Count == 0;
        }
        public void PushToHistory()
        {

            var list = new List<Figure>();
            foreach (Figure fig in this.Figures)
            {
                list.Add((Figure)fig.Clone());
            }

            string print = $"PUSHED {list.Count} elements to history\n";
            for (int i = 0; i < list.Count; i++)
            {
                var figure = list[i];
                print += $"Figure {i}: X:{figure.StartingPoint.X} Y:{figure.StartingPoint.Y}\n";
            }

            UndoHistory.Push(list);
            Console.WriteLine(print);
        }
        public void Undo()
        {
            if (!UndoEmpty())
            {
                RedoHistory.Push(new List<Figure>(Figures));
                List<Figure> list = new List<Figure> ();
                List<Figure> figures = UndoHistory.Pop();
                foreach (var f in figures)
                {
                    list.Add((Figure)f.Clone());
                }

                string print = $"POPPED {list.Count} elements to history\n";
                for (int i = 0; i < list.Count; i++)
                {
                    var figure = list[i];
                    print += $"Figure {i}: X:{figure.StartingPoint.X} Y:{figure.StartingPoint.Y}\n";
                }
                Figures = list;
                Console.WriteLine(print);
            }
        }
        public void Redo()
        {
            if (!RedoEmpty())
            {
                UndoHistory.Push(new List<Figure>(Figures));
                Figures = RedoHistory.Pop();
            }
        }
    }
}
