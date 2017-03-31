using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_classes_implement
{
    interface Iitem
    {
        string name { get; set; }
        Point position { get; set; }

        void Draw(Graphics g, Point position, Color color, int width);
        void Action();
    }
}
