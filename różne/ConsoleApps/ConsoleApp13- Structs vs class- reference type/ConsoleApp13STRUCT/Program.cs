using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13STRUCT
{
    class Program
    {
        static void Main(string[] args)
        {
            Canine spot = new Canine("Spot", "pug");
            Canine bob = spot;//canine to klasa- referencja na ten sam obiekt

            bob.Name = "Spike";
            bob.Breed = "beagle";
            spot.Speak();
            bob.Speak();
            Console.WriteLine("-----------");

            Dog jake = new Dog("Jake", "poodle");
            Dog betty = jake;

            betty.Name = "Betty";
            betty.Breed = "pit bull";
            jake.Speak();

            Console.ReadKey();
        }
    }
}
