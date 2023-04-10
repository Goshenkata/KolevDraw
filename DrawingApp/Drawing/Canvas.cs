using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApp.Drawing
{
    class Canvas
    {
        public List<Figure> Figures { get; set; }
        public List<Figure> SelectionFigures { get; set; }
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
            var list = new List<Figure>(Figures);
            UndoHistory.Push(list);
        }
        public void Undo()
        {
            var list = new List<Figure>(Figures);
            RedoHistory.Push(list);
            if (!UndoEmpty())
            {
                Figures = UndoHistory.Pop();
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
