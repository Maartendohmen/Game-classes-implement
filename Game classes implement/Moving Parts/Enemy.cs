using Game_classes_implement.Moving_Parts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_classes_implement
{
    public class Enemy : Character
    {

        //fields
        private int msBetweenMoves = 100;

        private const int borderSize = 2;
        private Pen pen = new Pen(Color.Red, borderSize);
        private SolidBrush brush = new SolidBrush(Color.Red);

        private long previousMoveTime;

        private Font font = new Font("Arial", 8);
        private StringFormat stringFormat = new StringFormat();

        //methods

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


    }
}
