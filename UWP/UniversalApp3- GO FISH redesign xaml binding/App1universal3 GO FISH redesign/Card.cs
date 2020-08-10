using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1universal3_GO_FISH_redesign

{
    class Card
    {
        public Card(Suits suit, Values value)
        {
            this.Suit = suit;
            this.Value = value;

        }
        public Suits Suit { get; set; }
        public Values Value { get; set; }
        public string Name
        {
            get
           {
               return Value.ToString() + " of "+ Suit.ToString();
           }
            
        }

        public override string ToString()
        {
            return Name;
        }

        public static string Plural(Values value)
        {
            if (value == Values.Six)
                return "Sixes";
            else return value.ToString() + "s";
        }

    }
}
