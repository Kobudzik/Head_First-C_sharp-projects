using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2_ienumerable_birds
{
    class Penguin : Bird
    {
        public override void Fly()
        {
            Console.WriteLine("Penguins can’t fly!");
        }

        public override string ToString()
        {
            return "A penguin named " + base.Name;
        }

        public string Hi()
        {
            return "A penguin named Marshall" + base.Name;
        }
    }
}