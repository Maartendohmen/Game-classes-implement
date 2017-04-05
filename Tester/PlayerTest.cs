using System;
using System.Drawing;
using System.Windows.Forms;
using Game_classes_implement;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace Tester
{
    [TestClass]
    public class PlayerTest
    {
        private Player player;

        [TestMethod]
        public void createplayer()
        {
            World.Instance.Create(new Size(100, 100), new Size(10, 10), 0,0);
            this.player = new Player();
        }

        [TestMethod]
        public void starthealth()
        {
            player = new Player();
            Assert.AreEqual(100, player.HitPoints,"Player should start with 100 hitpoints");
        }

        [TestMethod]
        public void startposition()
        {
            player = new Player();
            Point a = new Point(0, 0);
            Assert.AreEqual(a, player.Position, "Player should start at pos 0,0");
        }
        [TestMethod]
        public void moving()
        {
            Point down = new Point(0, 10);
            Point right = new Point(10, 10);
            Point up = new Point(10, 0);
            Point left = new Point(0, 0);
            player = new Player();

            //naar onderen
            player.Interaction(Keys.Down);
            player.Update();
            Assert.AreEqual(down, player.Position, "Player should go 10 down");

            //naar rechts
            player.Interaction(Keys.Right);
            player.Update();
            Assert.AreEqual(right, player.Position, "Player should go 10 right");

            //naar boven
            player.Interaction(Keys.Up);
            player.Update();
            Assert.AreEqual(up, player.Position, "Player should go 10 up");

            //naar links
            player.Interaction(Keys.Left);
            player.Update();
            Assert.AreEqual(left, player.Position, "Player Should go 10 left");
        }
    }
}
