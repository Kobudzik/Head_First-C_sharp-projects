using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp6_the_quest_game
{
    class Bat : Enemy
    {
        public Bat(Game game, Point location) :
            base(game, location, 6)
        {
        }

        public override void Move(Random random)
        {
            if (HitPoints > 0)// jesli zyje
            {
                if (NearPlayer())//jesli obok gracza
                {
                    game.HitPlayer(2, random);
                }

                if (random.Next(0, 2) == 1)//jesli wylosuje 0- idzie w strone gracza
                {
                   location = Move(FindPlayerDirection(game.PlayerLocation), game.Boundaries);                    
                }
                else //move in a random direction
                {
                    location = Move((Direction)random.Next(0, 4), game.Boundaries);                    
                }
            }
        }



        //check if it’s near the player
        // it is, then it attacks the player with up to two hit points of damage
    }
}