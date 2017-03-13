using System;
using System.Drawing;
using Game_classes_implement;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tester
{
    [TestClass]
    public class UnitTest1
    {
        private Player player;

        [TestMethod]
        public void TestMethod1()
        {
            World.Instance.Create(new Size(100, 100), new Size(10, 10), 0);
            this.player = new Player();
        }

    }
}
