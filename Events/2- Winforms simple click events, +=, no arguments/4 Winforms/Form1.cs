using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4_Winforms
{
    public partial class Form1 : Form
    {
        //funckja odpowiada sygnaturą EventHandlerowi
        private void SaySomething(object sender, EventArgs e)
        {
            MessageBox.Show("Something");
        }

        //funckja odpowiada sygnaturą EventHandlerowi
        private void SaySomethingElse(object sender, EventArgs e)
        {
            MessageBox.Show("Something else");
        }


        public Form1()
        {
            InitializeComponent();
        }




        private void Form1_Click(object sender, EventArgs e)//click event handler
        {
            MessageBox.Show("You just clicked on the form");
        }



        private void button1_Click(object sender, EventArgs e)
        {
            //rożne metody wywołania
            this.Click += new EventHandler(SaySomething);   //this== form1
            this.Click += SaySomething;   //this== form1

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //rożne metody wywołania
            this.Click += new EventHandler(SaySomethingElse);
            this.Click += SaySomethingElse;

        }
    }
}
