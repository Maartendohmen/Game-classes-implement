using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_classes_implement
{
    class Cell
    {
        //enums
        public enum CelType
        {
            Normal, Goal, Wall
        }

        //pen declaretion
        private static Pen pNormal = new Pen(Color.Gray, 1);
        private static Pen pGoal = new Pen(Color.Black, 2);
        private static Pen pWall = new Pen(Color.Black, 2);
        private static SolidBrush bNormal = new SolidBrush(Color.FromArgb(255, 255, 255));
        private static SolidBrush bGoal = new SolidBrush(Color.FromArgb(86, 178, 14));
        private static SolidBrush bWall = new SolidBrush(Color.FromArgb(0, 0, 0));

        private Size cellSize;

        public Point Index { get; set; }

        public Point Position { get; set; }

        public CelType Type { get; set; }
        public static object CellType { get; internal set; }



        //methods
        public Cell(Point index, Point position, Size cellsize)
        {
            this.Index = index;
            this.Position = position;
            this.cellSize = cellsize;
            this.Type = CelType.Normal;
        }

        public void draw(Graphics g)
        {
            Pen pen;
            Brush brush;

            switch (this.Type)
            {
                case CelType.Goal:
                    pen = Cell.pGoal;
                    brush = Cell.bGoal;
                    break;
                case CelType.Wall:
                    pen = Cell.pWall;
                    brush = Cell.bWall;
                    break;
                default:
                    pen = Cell.pNormal;
                    brush = Cell.bNormal;
                    break;
            }

            int borderOffset = Convert.ToInt32(pen.Width / 2);
            Rectangle r = new Rectangle(
                this.cellSize.Width * this.Index.X + borderOffset,
                this.cellSize.Height * this.Index.Y + borderOffset,
                this.cellSize.Width - borderOffset,
                this.cellSize.Height - borderOffset);
            g.FillRectangle(brush, r);
            g.DrawRectangle(pen, r);
        }
    }
}
