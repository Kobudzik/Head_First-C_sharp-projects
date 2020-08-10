using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_binding
{
    class Person
    {
        public string PersonName { get; set; }
        //public List<string> Names;


        //konstruktor
        public Person(string name)
        {
            PersonName = name;
        }

        public override string ToString()
        {
            return PersonName;
        }


    }
}