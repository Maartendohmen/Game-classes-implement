using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_classes_implement
{
        public class World
    {

        //fields
        public Map Map { get; private set; }
        public Player Player { get; private set; }
        public Enemy Enemy { get; private set; }

        public bool GameWon
        {
            get
            {
                return this.Player.Position.Equals(this.Map.GoalPosition);
            }
        }
        public bool GameOver
        {
            get
            {
                return this.Player.HitPoints == 0;
            }
        }

        //methods
        public static World Instance
        {
            get
            {
                if (World.instance == null)
                {
                    World.instance = new World();
                }
                return World.instance;
            }
        }
        private static World instance;

        public long Time { get { return this.stopwatch.ElapsedMilliseconds; } }
        private Stopwatch stopwatch = new Stopwatch();


        public void Create(Size mapSize, Size cellCount, int walls, int health)
        {
            this.Map = new Map(mapSize, cellCount, walls, health);
            this.Player = new Player();
            this.Enemy = new Enemy(World.Instance.Map.FreePosition());
            this.stopwatch.Start();
        }

        public void draw(Graphics g)
        {
            {
                this.Map.draw(g);
                this.Enemy.Draw(g);
                this.Player.Draw(g);
            }
        }

        public void update()
        {
            {
                this.Player.Update();
                this.Enemy.Update();

                if (this.Player.Position.Equals(this.Enemy.Position))
                {
                    this.Player.HitPoints -= 10;
                }

                if (this.Player.Position.Equals(this.Map.Healthposition) && Player.HitPoints < 100)
                {
                    this.Player.HitPoints += 5;
                }
            }
        }

    }
}
