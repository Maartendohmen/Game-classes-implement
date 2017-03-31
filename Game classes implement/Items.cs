using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_classes_implement
{
    class Items: Iitem, ICarryable
    {
        public string name { get; set; }
        public Point position { get; set; }
        public int wheight { get; set; }

        public Items (string _name, Point _position, int _wheight)
        {
            name = _name;
            position = _position;
            wheight = _wheight;
        }

        public void Draw(Graphics g,Point position, Color color, int Width)
        {
            Pen p = new Pen(color, Width);
            g.DrawEllipse(p, position.X, position.Y ,30, 30);
        }
        public void Action()
        {
           
        }

    }
}
