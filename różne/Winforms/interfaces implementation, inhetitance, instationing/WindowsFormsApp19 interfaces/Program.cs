using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp19_interfaces
{   
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ScaryClown fingersTheClown = new ScaryClown("big shoes", 14);

            FunnyClown someFunnyClown = fingersTheClown;


            IScaryClown someOtherScaryClown = someFunnyClown as ScaryClown;

            someOtherScaryClown.Honk(); 
        }
    }
}
