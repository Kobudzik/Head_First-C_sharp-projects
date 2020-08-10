using System;
using System.Collections.Generic;
using System.Text;

namespace practice_from_net
{
    //my delegate
    //public delegate void MaximumReachedEventHandler(object source, MaximumEventArgs e);









    public class MyClass
    {
        //EVENT- uses the MaximumReachedEventHandler  my delegate to create a signature for the called function.
        //public event MaximumReachedEventHandler MaximumReached; 

        //generic event
        public event EventHandler<MaximumEventArgs> MaximumReached;

        //EVENT PUBLISHER with added parameter
        protected virtual void OnMaximumReached(int number)
        {
            if (MaximumReached != null)
            {
                //just raises the event
                MaximumReached(this, new MaximumEventArgs() {eventInfo = "Event triggered! Currently i is " + number + ", and the maximum is: " +_maximum });
            }
        }




        private int _i;
        private int _maximum = 10;

        public int MyValue
        {
            get { return _i; }
            set
            {
                if (value <= _maximum)
                {
                    _i = value;
                }
                else
                {
                    OnMaximumReached(_i);
                }
            }
        }


    }

    class Program
    {
        //EVENT SUBSCRIBER- This is the actual method that will be assigned to the event handler within the above class
        public void OnMaximumReached(object source, MaximumEventArgs e)    //this method will happen after trigger (jeśli przypiszemy do eventu)- to jest event handler, odpowiada synagurą eventowi
        {
            Console.WriteLine(e.eventInfo);
        }



        static void Main(string[] args)
        {
            MyClass MyObject = new MyClass();

            MyObject.MaximumReached += OnMaximumReached;


            for (int x = 0; x <= 15; x++)
            {
                MyObject.MyValue = x;
            }




            Console.ReadLine();
        }
    }
}