using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_classes_implement
{
    interface IGameContext
    {
        List<int> GetAllMapIds();
        Map LoadMap(int id);
        void SaveMap(Map grid);
    }
}
