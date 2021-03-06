﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Models
{
    public class Map
    {
        //fields
        private Size mapSize;
        private Size cellSize;
        private Size cellCount;
        public Cell[] cells;
        bool healthexist = false;

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
                    if (cell.Type == Models.Cell.CelType.Goal)
                    {
                        return cell.Position;
                    }
                }

                return new Point(-1, -1);
            }
        }

        public Point Healthposition
        {
            get
            {
                foreach (Cell cell in cells)
                {
                    if (cell.Type == Models.Cell.CelType.health)
                    {
                        return cell.Position;
                    }
                }

                return new Point(-1, -1);
            }
        }
        //methods
        public Map(Size mapSize, Size cellcount, int walls , int health)
        {
            this.mapSize = mapSize;
            this.cellCount = cellcount;
            this.cellSize = new Size(mapSize.Width / cellCount.Width,
                                     mapSize.Height / cellCount.Height);
            

            this.cells = new Cell[cellCount.Width * cellCount.Height];
            for (int i = 0; i < this.cells.Length; ++i)
            {
                Point index = new Point(i % cellCount.Width, i / cellCount.Width);
                this.cells[i] = new Cell(index,
                    this.CellIndexToPosition(index),
                    this.cellSize);

                if (i > 0 && Random.Next(100) <= walls)
                {
                    this.cells[i].Type = Models.Cell.CelType.Wall;
                }

                if (i > 0 && Random.Next(100) <= health && healthexist == false)
                {
                    this.cells[i].Type = Cell.CelType.health;
                    healthexist = true;
                }
            }
            this.cells[this.cells.Length - 1].Type = Models.Cell.CelType.Goal;
        }

        public Map(Size mapsize, Size cellCount, Cell[] cells)
        {
            this.mapSize = mapsize;
            this.cellSize = new Size(mapsize.Width / cellCount.Width,
                                     mapsize.Height / cellCount.Height);
            this.cellCount = cellCount;
            this.cells = cells;
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
                   this.CellTypeAtPosition(randomPosition) == Models.Cell.CelType.Wall)
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
