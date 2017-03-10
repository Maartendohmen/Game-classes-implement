using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_classes_implement
{
    public static class Random
    {
        private static System.Random random = new System.Random();

        public static int Next()
        {
            return Random.random.Next();
        }
        public static int Next(int maxValue)
        {
            return Random.random.Next(maxValue);
        }
        public static int Next(int minValue, int maxValue)
        {
            return Random.random.Next(minValue, maxValue);
        }
    }
}

