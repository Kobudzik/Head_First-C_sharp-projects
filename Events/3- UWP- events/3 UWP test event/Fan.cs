using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_UWP_test_event
{
    class Fan
    {
        public ObservableCollection<string> FanSays= new ObservableCollection<string>();
        private int pitchNumber = 0;

        public Fan (Ball ball)//constructor chains its event handler onto the BallInPlay event
        {
            ball.BallInPlay += new EventHandler<BallEventArgs>(ball_BallInPlay);//The Fan object’s constructor chains its event handler onto the BallInPlay event
        }

        private void ball_BallInPlay(object sender, EventArgs e)//BallInPlay event handler. It looks for any low balls.
        {
            if (e is BallEventArgs)
            {
                BallEventArgs ballEventArgs = e as BallEventArgs;

                if ((ballEventArgs.Distance > 400) && (ballEventArgs.Trajectory > 30))
                {
                    FanSays.Add("Pitch #" + pitchNumber + ": Home run! I'm going for the ball!");
                }
                else
                {
                    FanSays.Add("Pitch #" + pitchNumber + ": Woo-hoo! Yeah!");
                }
                    
            }
        }
    }
}
