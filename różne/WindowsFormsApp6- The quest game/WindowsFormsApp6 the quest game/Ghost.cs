﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp6_the_quest_game
{
    class Ghost : Enemy
    {
        public Ghost(Game game, Point location) :
            base(game, location, 8)
        {
        }

        public override void Move(Random random)
        {
            if (HitPoints > 0)
            {
                if (random.Next(0, 2) == 0)
                {
                    location=Move(FindPlayerDirection(game.PlayerLocation), game.Boundaries);// move toward the player
                }

                if (NearPlayer())
                {
                    game.HitPlayer(3, random);

                }
            }
        }
    }
}
