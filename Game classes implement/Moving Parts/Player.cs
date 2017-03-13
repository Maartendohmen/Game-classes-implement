using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_classes_implement
{
    class Player
    {
        public enum Action
        {
            NoAction, MoveUp, MoveRight, MoveDown, MoveLeft, PerformAction
        }
        private const int borderSize = 2;
        private Pen pen = new Pen(Color.Yellow, borderSize);
        private SolidBrush brush = new SolidBrush(Color.Yellow);

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

        private Action CurrentAction
        {
            get
            {
                Action action = this.currentAction;
                this.currentAction = Action.NoAction;
                return action;
            }
            set
            {
                if (value != Action.NoAction)
                {
                    this.currentAction = value;
                }
            }
        }
        private Action currentAction = Action.NoAction;


        private Font font = new Font("Arial", 8);
        
        private StringFormat stringFormat = new StringFormat();

        public Player()
        {
            this.HitPoints = 100;


            this.stringFormat.Alignment = StringAlignment.Center;
            this.stringFormat.LineAlignment = StringAlignment.Center;
        }


        public void Update()
        {
            this.Position = this.UpdatePosition(this.Position, this.CurrentAction);
        }


        public void Draw(Graphics g)
        {
            Rectangle r = new Rectangle(
                this.Position + new Size(borderSize * 2, borderSize * 2),
                World.Instance.Map.getCellsize - new Size(borderSize * 4, borderSize * 4));
            g.FillEllipse(this.brush, r);
            g.DrawEllipse(this.pen, r);
            g.DrawString(System.Convert.ToString(this.HitPoints),
            this.font, Brushes.Black, r, this.stringFormat);
        }


        public void Interaction(Keys key)
        {
            if (key == Keys.Up || key == Keys.W)
            {
                this.CurrentAction = Action.MoveUp;
            }
            else if (key == Keys.Right || key == Keys.D)
            {
                this.CurrentAction = Action.MoveRight;
            }
            else if (key == Keys.Down || key == Keys.S)
            {
                this.CurrentAction = Action.MoveDown;
            }
            else if (key == Keys.Left || key == Keys.A)
            {
                this.CurrentAction = Action.MoveLeft;
            }
            else if (key == Keys.Space)
            {
                this.CurrentAction = Action.PerformAction;
            }
            else
            {
                this.CurrentAction = Action.NoAction;
            }
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
