using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_classes_implement
{
    class Map
    {
        //fields
        private Size mapSize;
        private Size cellSize;
        private Size cellCount;
        private Point goalPostion;
        private Cell[] cells;
        internal static object Cell;

        public Size getmapSize
        { get { return this.mapSize; } }

        public Size getCellsize
        { get { return this.cellSize; } }

        public Size getCellCount
        { get { return this.cellCount; } }

        public Point GoalPosition
        {
            get
            {
                foreach (Cell cell in cells)
                {
                    if (cell.Type == Game_classes_implement.Cell.CelType.Goal)
                    {
                        return cell.Position;
                    }
                }

                return new Point(-1, -1);
            }
        }
        //methods
        public Map(Size mapSize, Size cellcount, int walls)
        {
            this.mapSize = mapSize;
            this.cellSize = new Size(mapSize.Width / cellCount.Width,
                                     mapSize.Height / cellCount.Height);
            this.cellCount = cellcount;

            this.cells = new Cell[cellCount.Width * cellCount.Height];
            for (int i = 0; i < this.cells.Length; ++i)
            {
                Point index = new Point(i % cellCount.Width, i / cellCount.Width);
                this.cells[i] = new Cell(index,
                    this.CellIndexToPosition(index),
                    this.cellSize);

                if (i > 0 && Random.Next(100) <= walls)
                {
                    this.cells[i].Type = Game_classes_implement.Cell.CelType.Wall;
                }
            }
            this.cells[this.cells.Length - 1].Type = Game_classes_implement.Cell.CelType.Goal;
        }


        public void draw(Graphics g)
        {
            foreach (Cell cell in this.cells)
            {
                cell.draw(g);
            }
        }

        public Point FreePosition()
        {
            Point randomPosition = new Point();

            while (randomPosition.Equals(World.Instance.Player.Position) ||
                   this.CellTypeAtPosition(randomPosition) == Game_classes_implement.Cell.CelType.Wall)
            {
                randomPosition = this.CellIndexToPosition(new Point(
                    Random.Next(this.cellCount.Width),
                    Random.Next(this.cellCount.Height)));
            }

            return randomPosition;
        }

        public Cell.CelType CellTypeAtPosition(Point position)
        {
            Point index = this.PositionToCellIndex(position);
            int arrayIndex = (index.Y * this.cellCount.Width) + index.X;
            return this.cells[arrayIndex].Type;
        }

        private Point PositionToCellIndex(Point position)
        {
            Size cs = this.cellSize;
            return new Point((position.X - (position.X % cs.Width)) / cs.Width,
                             (position.Y - (position.Y % cs.Height)) / cs.Height);
        }


        private Point CellIndexToPosition(Point index)
        {
            return new Point(index.X * this.cellSize.Width,
                             index.Y * this.cellSize.Height);
        }

    }
}
