using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace InvadersGame.Model
{
    class Invader : Ship
    {
        public static readonly Size InvaderSize = new Size(15, 15);
        public InvaderType InvaderType;
        public int Score { get; private set; }
        public const double HorizontalPixelsPerMove = 5;
        public const double VerticalPixelsPerMove = 15;

        public override void  Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    Location = new Point(Location.X - HorizontalPixelsPerMove, Location.Y);
                    break;

                case Direction.Right:
                    Location = new Point(Location.X + HorizontalPixelsPerMove, Location.Y);
                    break;

                case Direction.Down:
                    Location = new Point(Location.X, Location.Y + VerticalPixelsPerMove);
                    break;

                default:
                    break;
            }
        }

        public Invader(InvaderType invaderType,  Point point, int score)
            :base(point, InvaderSize)
        {
            InvaderType = invaderType;
            Score = score;

        }
    }
}
