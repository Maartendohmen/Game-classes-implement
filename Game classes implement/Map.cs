using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_classes_implement
{
    class Map
    {
        //fields
        private Size mapSize;
        private Size cellSize;
        private Size cellCount;
        private Point goalPostion;

        //methods
        public void map(Size mapSize, Size cellSize, Size cellcount, Point goalposition)
        {

        }

        public void draw(Graphics g)
        {

        }

        public Size getmapSize
        {
            get { return this.mapSize; }

        }

        public Size getCellsize
        {
            get { return this.cellSize; }

        }

        public Size getCellCount
        {
            get { return this.cellCount; }

        }

        public Point getgoalPosition
        {
            get { return this.goalPostion; }

        }

    }
    }
