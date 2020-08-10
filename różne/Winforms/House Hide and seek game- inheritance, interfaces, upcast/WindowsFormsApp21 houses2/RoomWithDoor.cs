using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp21_houses2
{
    class RoomWithDoor : RoomWithHidingPlace, IHasExteriorDoor
    {
        //konstruktor
        public RoomWithDoor(string name, string decoration,string hidingPlaceName, string doorDescription)
            :base(name, decoration,hidingPlaceName)
        {
            DoorDescription = doorDescription;
        }

        public string DoorDescription { get; private set; }
        public Location DoorLocation { get; set; }    
    }
}
