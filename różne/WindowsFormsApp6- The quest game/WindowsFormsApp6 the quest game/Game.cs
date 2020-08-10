using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace WindowsFormsApp6_the_quest_game
{
    class Game
    {    
        public IEnumerable<Enemy> Enemies { get; private set; }//leniwa kolekcja- tylko foearch
        public Weapon WeaponInRoom { get; private set; }//property

        private Player player;//property


        public Point PlayerLocation { get { return player.Location; } }//property z playera
        public int PlayerHitPoints { get { return player.HitPoints; } }//property z playera
        public IEnumerable<string> PlayerWeapons { get { return player.Weapons; } }//leniwa kolekcja- tylko foearch //property z playera

        private int level = 0; //zaczynamy od poziomu 0
        public int Level { get { return level; } } //property do wyświetlania levelu

        private Rectangle boundaries;//zmienna
        public Rectangle Boundaries { get { return boundaries; } }//property do wyświetlania 


        public Game(Rectangle boundaries)//konstruktor GAME
        {
            this.boundaries = boundaries;//ustawia granice
            player = new Player(this, new Point(boundaries.Left + 10, boundaries.Top + 70));//tworzy gracza na tych koordynatach
        }


        public void Move(Direction direction, Random random)
        {
            player.Move(direction);

            foreach (Enemy enemy in Enemies)
                enemy.Move(random);
        }

        public void Equip(string weaponName)
        {
            player.Equip(weaponName);
        }

        public bool CheckPlayerInventory(string weaponName)
        {
            return player.Weapons.Contains(weaponName);
        }

        public void HitPlayer(int maxDamage, Random random)
        {
            player.Hit(maxDamage, random);
        }

        public void IncreasePlayerHealth(int health, Random random)
        {
            player.IncreaseHealth(health, random);
        }

        public void Attack(Direction direction, Random random)
        {
            player.Attack(direction, random);

            foreach (Enemy enemy in Enemies)
                enemy.Move(random);
        }
        
        private Point GetRandomLocation(Random random)
        {
            return new Point(boundaries.Left +                  //X= lewa granica +
                random.Next(boundaries.Right / 10 - boundaries.Left / 10) * 10,//max randoma to prawa granica/10 -lewa granica/10 *10
                boundaries.Top +//Y to gorna granica+
                random.Next(boundaries.Bottom / 10 - boundaries.Top / 10) * 10); //dolna na 10 - gorna/10 *10
        }


        public void NewLevel(Random random)
        {
            level++;
            switch (level)
            {
                case 1:
                    Enemies = new List<Enemy>() {
                        new Bat(this, GetRandomLocation(random)),
                    };
                    WeaponInRoom = new Sword(this, GetRandomLocation(random));
                    break;

                case 2:
                    Enemies = new List<Enemy>() {
                        new Ghost(this, GetRandomLocation(random)),
                    };
                    WeaponInRoom = new BluePotion(this, GetRandomLocation(random));
                    break;

                case 3:
                    Enemies = new List<Enemy>() {
                        new Ghoul(this, GetRandomLocation(random)),
                    };
                    WeaponInRoom = new Bow(this, GetRandomLocation(random));
                    break;


                case 4:
                    Enemies = new List<Enemy>() {
                        new Bat(this, GetRandomLocation(random)),
                        new Ghost(this, GetRandomLocation(random))
                    };
                    /* if(CheckPlayerInventory("Bow"))
                    {

                    }
                    else
                    {
                        WeaponInRoom = new BluePotion(this, GetRandomLocation(random));

                    }*/
                    WeaponInRoom = new Bow(this, GetRandomLocation(random));
                    break;

                case 5:
                    Enemies = new List<Enemy>() {
                    new Bat(this, GetRandomLocation(random)),
                    new Ghoul(this, GetRandomLocation(random))
                    };
                    WeaponInRoom = new RedPotion(this, GetRandomLocation(random));

                    break;

                case 6:
                    Enemies = new List<Enemy>() {
                    new Ghoul(this, GetRandomLocation(random)),
                    new Ghoul(this, GetRandomLocation(random))
                    };
                    WeaponInRoom = new Mace(this, GetRandomLocation(random));

                    break;

                case 7:
                    Enemies = new List<Enemy>() {
                    new Bat(this, GetRandomLocation(random)),
                    new Ghoul(this, GetRandomLocation(random)),
                    new Ghost(this, GetRandomLocation(random))
                    };
                    break;

                case 8:
                   // Application.Exit();
                    break;

                    //ADD REST
            }
        }
    }
}