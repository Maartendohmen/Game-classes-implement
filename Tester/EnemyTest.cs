using System;
using System.Drawing;
using System.Windows.Forms;
using Game_classes_implement;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace Tester
{

    [TestClass]
    public class EnemyTest
    {
        private Enemy enemy;

        [TestMethod]
        public void CreateEnemy()
        {
            World.Instance.Create(new Size(100, 100), new Size(10, 10), 0,0);
            this.enemy = new Enemy(new Point());
        }

        [TestMethod]
        public void starthealth()
        {
            enemy = new Enemy(new Point());
            Assert.AreEqual(100, enemy.HitPoints, "Player should start with 100 hitpoints");
        }
    }
    
}
