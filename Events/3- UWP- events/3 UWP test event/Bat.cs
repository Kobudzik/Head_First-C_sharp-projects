using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_UWP_test_event
{
    class Bat
    {
        private BatCallback hitBallCallback;    //delegate reference to store particular OnBallInPlay() method

        public Bat(BatCallback callbackDelegate)    //konstruktor- gets a reference to a particular ball’s OnBallInPlay() method
        {
            this.hitBallCallback = callbackDelegate;
            //this.hitBallCallback = new BatCallback(callbackDelegate);
        }



        public void HitTheBall(BallEventArgs e) // event raiser- simulator will call this every time a ball is hit
                                                //that method uses the hitBallCallback delegate to call the ball’s OnBallInPlay() method
                                                //(or whatever method is passed into its constructor)
        {
            if (hitBallCallback != null)
                hitBallCallback(e); 
        }
    }

    delegate void BatCallback(BallEventArgs e);
    //it will point to a Ball object’s OnBallInPlay() method,
    //(so it needs to match the signature of OnBallInPlay()— BallEventArgs parameter and void return value)


}
