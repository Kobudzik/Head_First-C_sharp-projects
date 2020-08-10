using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp21_houses2
{
    abstract class Location
    {
        //konstruktor
        public Location(string name)
        {
            Name = name;
        }

        //array of location objects
        public Location[] Exits;

        public string Name
        {
            get;
            private set;
        }

        public virtual string Description
        {
            get
            {
                string description = "You’re standing in the " + Name + ". You see exits to the following places: ";
                for (int i = 0; i < Exits.Length; i++)
                {
                    description += " " + Exits[i].Name;
                    if (i != Exits.Length - 1) description += ",";
                }
                description += ".";
                return description;
            }
        }
    }
}
