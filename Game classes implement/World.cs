using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_classes_implement
{
        public class World
    {
        FileContent filecontent = new FileContent();

        List<Items> inventory = new List<Items>();
        int totalweight = 0;
        private bool armorlitepickedup = false;
        private bool armormediumpickup = false;

        //fields
        public Map Map { get; private set; }
        public Player Player { get; private set; }
        public Enemy Enemy { get; private set; }

        Items armorlite = new Items("Lite Armor",new Point(265, 20), 50);
        Items armormedium = new Items("Medium Armor", new Point(33,231), 50);
        Point drawamrmorlite = new Point(265, 0);
        Point drawarmormedium = new Point(34 , 233);

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

        public void load(string loadfile)
        {
            this.Map = filecontent.loadmap(loadfile);
            this.Player = new Player();
            this.Enemy = new Enemy(World.instance.Map.FreePosition());
        }

        public void draw(Graphics g)
        {
            {
                this.Map.draw(g);
                this.Enemy.Draw(g);
                this.armorlite.Draw(g, drawamrmorlite, Color.Blue, 3);
                this.armormedium.Draw(g, drawarmormedium  , Color.Green,3);
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


                if (this.Player.Position.X == 264 && this.Player.Position.Y == 0 && armorlitepickedup == false && totalweight + armorlite.wheight <= 100)
                {
                    armorlitepickedup = true;
                    inventory.Add(armorlite);
                    Console.WriteLine("Added lite armor");

                        totalweight = totalweight + armorlite.wheight;
                }
                if (this.Player.Position.X == 33 && this.Player.Position.Y == 231 && armormediumpickup == false && totalweight + armormedium.wheight <= 100)
                {

                    armormediumpickup = true;
                    inventory.Add(armormedium);
                    Console.WriteLine("Added medium Armor");

                     totalweight = totalweight + armormedium.wheight;
                }
            }
        }
                public void changelabel (Label Weightlabel)
        {
            Weightlabel.Text = "The state of you're inventory =" + totalweight + "/100";
        } 
    }
}
