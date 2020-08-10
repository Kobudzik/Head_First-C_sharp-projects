using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_UWP_test_event
{
    class BallEventArgs: EventArgs //purpose is to allow your event arguments object to be passed to the event handlers that use it
    {
        public int Trajectory { get; private set; }
        public int Distance { get; private set; }


        public BallEventArgs(int trajectory, int distance)// konstruktor
        {
            this.Trajectory = trajectory;
            this.Distance = distance;
        }
    }
}
