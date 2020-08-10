using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp21_houses2
{
    class Opponent
    {
        private Location _opponentLocation;
        private Random random;

        //konstruktor
        public Opponent(Location startingLocation)
        {
            _opponentLocation = startingLocation;
            random = new Random();
        }

       public void Move()
        {
            bool hidden = false;
            while (!hidden)
            {
                if (_opponentLocation is IHasExteriorDoor)
                {
                    IHasExteriorDoor locationWithDoor = _opponentLocation as IHasExteriorDoor;
                    if (random.Next(2) == 1)
                        _opponentLocation = locationWithDoor.DoorLocation;
                }

                int rand = random.Next(_opponentLocation.Exits.Length);
                _opponentLocation = _opponentLocation.Exits[rand];


                if (_opponentLocation is IHidingPlace)
                    hidden = true;
            }
        }


        public bool Check(Location locationToCheck)
        {
            if (locationToCheck != _opponentLocation)
                return false;
            else 
                return true;
        }
    }
}