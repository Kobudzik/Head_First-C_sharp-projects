using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice_from_net
{
    // This is a class which describes the event to the class that receives it.
    // An EventArgs class must always derive from System.EventArgs.
    public class MaximumEventArgs : System.EventArgs
    {
        public string eventInfo;

        ////wyświetla podany (jako argument) tekst
        //public MaximumEventArgs(string text)
        //{
        //    EventInfo = text;
        //}

        //public string GetInfo()
        //{
        //    return EventInfo;
        //}
    }
}
