using Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class Character
    {
        public enum Action
        {
            NoAction, MoveUp, MoveRight, MoveDown, MoveLeft, PerformAction
        }

        public Point Position { get; set; }

        public int HitPoints
        {
            get
            {
                return this.hitPoints;
            }
            set
            {
                if (value >= 0)
                {
                    this.hitPoints = value;
                }
            }
        }
        private int hitPoints;

        public Point UpdatePosition(Point position, Action direction)
        {
            Size ms = World.Instance.Map.getmapSize;
            Size cs = World.Instance.Map.getCellsize;
            Point newPos = position;

            if (direction == Action.MoveUp)
            {
                newPos.Offset(0, cs.Height * -1);
            }
            else if (direction == Action.MoveRight)
            {
                newPos.Offset(cs.Width, 0);
            }
            else if (direction == Action.MoveDown)
            {
                newPos.Offset(0, cs.Height);
            }
            else if (direction == Action.MoveLeft)
            {
                newPos.Offset(cs.Width * -1, 0);
            }


            if (newPos.X < 0 || newPos.X > ms.Width - cs.Width ||
                newPos.Y < 0 || newPos.Y > ms.Height - cs.Height)
            {
                return position;
            }


            if (World.Instance.Map.CellTypeAtPosition(newPos) ==
                Models.Cell.CelType.Wall)
            {
                return position;
            }

            return newPos;
        }

    }
}
