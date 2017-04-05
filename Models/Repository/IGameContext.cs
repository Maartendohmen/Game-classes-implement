using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Game_classes_implement
{
    interface IGameContext
    {
        Map LoadMap(string loadfile);
        void SaveMap(Map map ,string savefile);
    }
}
