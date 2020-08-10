using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp6_the_quest_game
{
    class RedPotion:Weapon,IPotion
    {
        public bool Used { get; set; }

        public override string Name { get { return "Red Potion"; } }

        public RedPotion(Game game, Point location)
         : base(game, location)
        {
            Used = false;
        }


        public override void Attack(Direction direction, Random random)
        {
            game.IncreasePlayerHealth(5, random);
            Used= true;
        }
    }
}
