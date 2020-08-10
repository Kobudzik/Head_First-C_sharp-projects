using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using System.Diagnostics;


namespace UniversalApp4_pancakes_redesign
{
    class Lumberjack
    {
        private string name;
        public string Name { get { return name; } }

        private Stack<Flapjack> meal;//stack flapjacków- ENUM
        public Lumberjack(string name)//konstruktor
        {
            this.name = name;
            meal = new Stack<Flapjack>();
        }
        MessageDialog msgbox = new MessageDialog("Sample");
        public int FlapjackCount { get { return meal.Count; } } // return the count

        public  void TakeFlapjacks(Flapjack food, int howMany)//bierze flapjacki na stack
        {
            if(howMany==0)//jeśli nie wybrano ilości naleśników
                msgbox.Content="Would";


            //MessageBox.Show("Select at least one flapjack!");
            if (howMany >= 1)
                for (int i = 0; i < howMany; i++)
                    this.meal.Push(food);// Add  number of flapjacks to the Meal stack          
               
        }
        public void EatFlapjacks()// Write  output to the console
        {
            while (meal.Count > 0)

                Debug.WriteLine("Zdejmuję:" + meal.Pop().ToString().ToLower());        
        }
    }
}
         
