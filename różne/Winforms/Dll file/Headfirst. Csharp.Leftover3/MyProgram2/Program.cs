using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Headfirst.Csharp.Leftover3;
namespace MyProgram2
{
    class Program
    {
        static void Main(string[] args)
        {
            Guy guy = new Guy();
            HiThereWriter.HiThere(guy.Name);
        }
    }
}
