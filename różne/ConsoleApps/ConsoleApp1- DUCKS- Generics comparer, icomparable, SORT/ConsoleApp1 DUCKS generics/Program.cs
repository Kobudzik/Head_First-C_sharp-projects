using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1_DUCKS_generics
{
    class Program
    {
        public static void PrintDucks(List<Duck> ducks)
        {
            foreach (Duck duck in ducks)
                Console.WriteLine(duck);

            Console.WriteLine("End of ducks!");
        }

        static void Main(string[] args)
        {
            List<Duck> ducks = new List<Duck>() {
                new Duck() { Kind = KindOfDuck.Mallard, Size = 17 },
                new Duck() { Kind = KindOfDuck.Muscovy, Size = 18 },
                new Duck() { Kind = KindOfDuck.Decoy, Size = 14 },
                new Duck() { Kind = KindOfDuck.Muscovy, Size = 11 },
                new Duck() { Kind = KindOfDuck.Mallard, Size = 14 },
                new Duck() { Kind = KindOfDuck.Decoy, Size = 13 },
            };

        Duck[] duckArray = new Duck[6];


        //comparer- musi miec metode compare
        ducks.Sort(new DuckComparerBySize());

        ducks.Sort(new DuckComparerByKind());


        ducks.Sort();//uses duck icomparable- musie miec metode compareTo

        PrintDucks(ducks);

        Console.ReadKey();


        }
    }
}
