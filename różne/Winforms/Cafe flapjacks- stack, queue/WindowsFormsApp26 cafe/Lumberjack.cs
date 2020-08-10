using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp26_cafe
{
    class Lumberjack
    {
        private string _name;
        public string Name { get { return _name; } }

        private Stack<Flapjack> meal;//stack flapjacków- ENUM

        public Lumberjack(string name)//konstruktor
        {
            this._name = name;
            meal = new Stack<Flapjack>();
        }


        public int FlapjackCount { get { return meal.Count; } } // return the count

        public void TakeFlapjacks(Flapjack food, int howMany)//bierze flapjacki na stack
        {
            if(howMany==0)//jeśli nie wybrano ilości naleśników
                MessageBox.Show("Select at least one flapjack!");
            if (howMany >= 1)
                for (int i = 0; i < howMany; i++)
                    this.meal.Push(food);// Add  number of flapjacks to the Meal stack          
               
        }


        public void EatFlapjacks()// Write  output to the console
        {
            while (meal.Count > 0)
                Console.WriteLine("Zdejmuję:" + meal.Pop().ToString().ToLower());        
        }
    }
}
         
