using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1_DUCKS_generics
{
    class Duck: IComparable<Duck>
    {
        public int Size;
        public KindOfDuck Kind;

        //Compare by size
        public int CompareTo(Duck duckToCompare)
        {
            if (this.Size > duckToCompare.Size)
                return 1; 
            else if (this.Size < duckToCompare.Size)
                return -1;
            else return 0;
        }

        public override string ToString()
        {
            return "A " + Size + " inch " + Kind.ToString();
        }
    }
}
