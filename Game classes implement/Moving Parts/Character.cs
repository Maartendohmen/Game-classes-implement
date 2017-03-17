using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_classes_implement.Moving_Parts
{
    public class Character
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
    }


}
