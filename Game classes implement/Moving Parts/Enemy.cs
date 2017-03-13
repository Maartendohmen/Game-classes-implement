using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_classes_implement
{
    class Enemy
    {
        public enum Action
        {
            NoAction, MoveUp, MoveRight, MoveDown, MoveLeft, PerformAction
        }

        private int msBetweenMoves = 100;

        private const int borderSize = 2;
        private Pen pen = new Pen(Color.Red, borderSize);
        private SolidBrush brush = new SolidBrush(Color.Red);

        private long previousMoveTime;
        public Point Position { get; private set; }


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


        private Font font = new Font("Arial", 8);
        private StringFormat stringFormat = new StringFormat();

        public Enemy(Point position)
        {
            this.Position = position;
            this.HitPoints = 100;


            this.stringFormat.Alignment = StringAlignment.Center;
            this.stringFormat.LineAlignment = StringAlignment.Center;
        }


        public void Update()
        {
            if (World.Instance.Time - this.previousMoveTime >= this.msBetweenMoves)
            {
                Action[] moves = new Action[5]
                {
                    Action.MoveUp, Action.MoveRight, Action.MoveDown, Action.MoveLeft,
                    Action.NoAction
                };
                Action action = moves[Random.Next(moves.Length)];

                this.Position = this.UpdatePosition(this.Position, action);
                this.previousMoveTime = World.Instance.Time;
            }
        }

        public void Draw(Graphics g)
        {
            Rectangle r = new Rectangle(
                this.Position + new Size(borderSize * 2, borderSize * 2),
                World.Instance.Map.getCellsize - new Size(borderSize * 4, borderSize * 4));
            g.FillEllipse(this.brush, r);
            g.DrawEllipse(this.pen, r);
            g.DrawString(System.Convert.ToString(this.HitPoints),
                this.font, Brushes.White, r, this.stringFormat);
        }


        private Point UpdatePosition(Point position, Action direction)
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
                Game_classes_implement.Cell.CelType.Wall)
            {
                return position;
            }


            return newPos;
        }
    }
}
