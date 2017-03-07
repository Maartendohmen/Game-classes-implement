using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_classes_implement
{
    class World
    {
        //methods
        public void update()
        {

        }
        public void draw(Graphics g)
        {

        }

        public bool GameWon
        {
            get { return this.GameWon; }
            set { this.GameWon = value; }
        }

        public bool GameOver
        {
            get { return this.GameOver; }
            set { this.GameOver = value; }
        }
    }
}
