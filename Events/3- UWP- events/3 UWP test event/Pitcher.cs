using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_UWP_test_event
{
    class Pitcher
    {
        public Pitcher(Ball ball)
        {
            ball.BallInPlay += ball_BallInPlay;//constructor chains its event handler onto the BallInPlay event
        }

        private void ball_BallInPlay(object sender, EventArgs e)//BallInPlay event handler. It looks for any low balls.
        {
            if (e is BallEventArgs)
            {
                BallEventArgs ballEventArgs = e as BallEventArgs;
                if ((ballEventArgs.Distance < 95) && (ballEventArgs.Trajectory < 60))
                    CatchBall();
                else
                    CoverFirstBase();
            }
        }

        public ObservableCollection<string> PitcherSays= new ObservableCollection<string>();
        private int pitchNumber = 0;
        void CatchBall()
        {
            PitcherSays.Add("Pitch #" + pitchNumber + ": I caught the ball");
        }
            
        void CoverFirstBase()
        {
            PitcherSays.Add("Pitch #" + pitchNumber + ": I covered first base");
        }
    }
}
