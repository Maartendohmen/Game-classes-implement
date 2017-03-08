using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_classes_implement
{
    class Player
    {
        //fields
        private Point position;
        private bool powerUp;
        private int hitPoints;

        //methods
        public void player(Point position, bool powerup, int hitPoints)
        {

        }
        public void update()
        {

        }
        public void draw(Graphics g)
        {

        }
        public void interaction (int keyCode)
        {

        }
        public void attack (int damage)
        {

        }

        public Point getPosition
        {
            get { return this.position; }
        }

        public int gethitPoints
        {
            get { return this.hitPoints; }
        }
        public void givePowerUp()
        {

        }

    }
    }
