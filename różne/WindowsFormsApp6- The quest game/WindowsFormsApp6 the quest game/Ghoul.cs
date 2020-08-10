using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp6_the_quest_game
{
    class Ghoul:Enemy
    { 
        public Ghoul(Game game, Point location) :
            base(game, location, 10)
    {
    }

    public override void Move(Random random)
    {
        if (HitPoints >= 1)
        {
            if (random.Next(0, 3) == 0 || random.Next(0, 3) == 1)//2/3 szansy
            {
                location=Move(FindPlayerDirection(game.PlayerLocation), game.Boundaries);// move toward the playe
            }

            if (NearPlayer())
            {
                game.HitPlayer(4, random);
            }
        }
    }
}
}
