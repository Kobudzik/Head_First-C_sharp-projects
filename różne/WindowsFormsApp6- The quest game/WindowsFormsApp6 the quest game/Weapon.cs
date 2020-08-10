using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp6_the_quest_game
{
    abstract class Weapon : Mover
    {
        private const int MoveInterval = 10;
        public bool PickedUp { get; private set; }

        public Weapon(Game game, Point location)
          : base(game, location)
        {
            PickedUp = false;
        }
        public void PickUpWeapon()
        {
            PickedUp = true;
        }

        public abstract string Name { get; }
        public abstract void Attack(Direction direction, Random random);



        protected bool DamageEnemy(Direction direction, int radius, int damage, Random random)//próbuje bić przeciwnika
        {
            Point target = game.PlayerLocation;//target to lokacja od której się sprawdza

            for (int distance = 0; distance <= radius; distance++)//sprawdza coraz dalej//najpierw sprawdza czy nie jest na
            {
                foreach (Enemy enemy in game.Enemies)//sprawdza kazdego przeciwnika
                {
                    if (Nearby(enemy.Location, target, distance))//jesli w odleglosci distance od target
                    {
                        enemy.Hit(damage, random);//uderz go
                        return true;
                    }
                }

                target = Move(direction, target, game.Boundaries);//target to lokacja gracza przesunięta direction
            }
            return false;
        }


        //compares two points and returns true if they’re within the specified distance of each other.

        public bool Nearby(Point firstLocationToCheck, Point secondLocationToCheck, int distance)
        {
            if (
                Math.Abs(firstLocationToCheck.X- secondLocationToCheck.X)
                < distance
                && (Math.Abs(firstLocationToCheck.Y - secondLocationToCheck.Y)
                < distance))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //move a Point in a direction and return the new Point


        public Point Move(Direction direction, Point pointToMove, Rectangle boundaries)
        {
            Point newLocation = game.PlayerLocation;

            switch (direction)
            {
                case Direction.Up:
                    if (pointToMove.Y - MoveInterval >= boundaries.Top)
                        newLocation.Y=pointToMove.Y- MoveInterval;
                    break;

                case Direction.Down:
                    if (pointToMove.Y + MoveInterval <= boundaries.Bottom)
                        newLocation.Y= pointToMove.Y +MoveInterval;
                    break;

                case Direction.Left:
                    if (pointToMove.X- MoveInterval >= boundaries.Left)
                        newLocation.X= pointToMove.X -MoveInterval;
                    break;

                case Direction.Right:
                    if (pointToMove.X + MoveInterval <= boundaries.Right)
                        newLocation.X= pointToMove.X + MoveInterval;
                    break;

                default:
                    break;
            }
            return newLocation;
        }

    }

}
