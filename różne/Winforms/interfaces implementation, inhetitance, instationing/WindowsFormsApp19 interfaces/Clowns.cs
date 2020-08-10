using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WindowsFormsApp19_interfaces
{
    interface IClown
    {
        void Honk();
        string FunnyThingIHave { get; }
    }


    interface IScaryClown : IClown
    {
        string ScaryThingIHave { get; }
        void ScareLittleChildren();
    }







    class FunnyClown : IClown
    {
        //konstuktor
        public FunnyClown(string funnyThingIHave)
        {
            this.funnyThingIHave = funnyThingIHave;
        }


        protected string funnyThingIHave;

        public string FunnyThingIHave
        {
            get
            {
                return "Hi kids! I have " + funnyThingIHave;
            }
           
        }


        public void Honk()
        {
            MessageBox.Show(this.FunnyThingIHave);
        } 
    }



        class ScaryClown : FunnyClown, IScaryClown
        {
            //konstuktor
            public ScaryClown(string funnyThingIHave, int numberOfScaryThings)
               : base(funnyThingIHave)
            {
                this.numberOfScaryThings = numberOfScaryThings;
            }



            private int numberOfScaryThings;

            public string ScaryThingIHave
            {
                get
                {
                    return "I have " + numberOfScaryThings + " spiders";
                }
            }




            public void ScareLittleChildren()
            {
               MessageBox.Show("You can’t have my " + base.funnyThingIHave);
            }



        }
    }

