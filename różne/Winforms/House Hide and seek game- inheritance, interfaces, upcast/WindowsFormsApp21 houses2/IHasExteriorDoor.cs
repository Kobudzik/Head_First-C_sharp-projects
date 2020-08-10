using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp21_houses2
{
    interface IHasExteriorDoor
    {
        string DoorDescription{ get;}
        Location DoorLocation { get; set; }
    }
}
