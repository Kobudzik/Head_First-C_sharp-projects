using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _14_WindowsFormsApp_out_ref
{
    public partial class Form1 : Form
    {
        Random random = new Random();

        public int ReturnThreeValues(out double half, out int twice)
        {
            int value = random.Next(1000);
            half = ((double)value) / 2;
            twice = value * 2;
            return value;
        }

        public void ModifyAnIntAndButton(ref int value, ref Button button)
        { 
            int i = value;
            i *= 5; 
            value = i - 3;
            button = button1;
        }

        public int Out2args1return(out int one, out int two)
        {
            int value = 17;
            one=3;
            two = 9;
            Console.WriteLine("One=" + one + "two=" + two);

            return value;
        }

       
        public Form1()
        {
            InitializeComponent();
            
        }




        private void button1_Click(object sender, EventArgs e)
        {
            double b;
            int c;
            int a = ReturnThreeValues(out b, out c);
            Console.WriteLine("value = {0}, half = {1}, double = {2}", a, b, c);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            int q = 100;
            Button b = button2;
            ModifyAnIntAndButton(ref q, ref b);
            Console.WriteLine("q = {0}, b.Text = {1}", q, b.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
           Console.WriteLine(Out2args1return(out int a, out int b).ToString());
           Console.WriteLine(a + b);
        }
    }
}
