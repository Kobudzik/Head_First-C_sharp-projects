using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_UWP_test_event
{
    class Ball
    {
        public event EventHandler<BallEventArgs> BallInPlay; //objects subscribe to THIS event- BallInPlay

        protected void OnBallInPlay(BallEventArgs e)//just raises the BallInPlay event
                                                     //but it has to check to make sure it’s not null
        {
            EventHandler<BallEventArgs> ballInPlay = BallInPlay;
            if (ballInPlay != null) 
                ballInPlay(this, e);    //raising
        }

        public Bat GetNewBat()  // Bat’s constructor gets a reference to a particular ball’s OnBallInPlay() method
        {
            return new Bat(new BatCallback(OnBallInPlay));  //OnBallInPlay will be a method delegate calls
        }
    }
}
