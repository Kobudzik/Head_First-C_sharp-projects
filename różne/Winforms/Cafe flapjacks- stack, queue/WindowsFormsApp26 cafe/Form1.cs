using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp26_cafe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Queue<Lumberjack> breakfastLine = new Queue<Lumberjack>();


        private void addLumberjackButton_Click(object sender, EventArgs e)//dodaje lumberjacka do kolejki
        {
            if (String.IsNullOrEmpty(nameBox.Text)) return;
            breakfastLine.Enqueue(new Lumberjack(nameBox.Text));
            nameBox.Text = "";
            RedrawList();
        }

        private void addFlapjacksButton_Click(object sender, EventArgs e)//wywołuje branie naleśników
        {
            if (breakfastLine.Count == 0)//jesli wszyscy zjedli to nic nie rob
                return;

            Flapjack selectedFood;
            if (crispy.Checked == true)
                selectedFood = Flapjack.Crispy;
            else if (soggy.Checked == true)
                selectedFood = Flapjack.Soggy;
            else if (browned.Checked == true)
                selectedFood = Flapjack.Browned;
            else selectedFood = Flapjack.Banana;

            Lumberjack currentLumberjack = breakfastLine.Peek();//dla aktualnego klienta

            currentLumberjack.TakeFlapjacks(selectedFood, (int)numOfFlapjacks.Value);//dodaj wybrane nalesniki na stack

            RedrawList();

            Console.WriteLine("Dodano " + selectedFood.ToString().ToLower() +". W ilości: " + (int)numOfFlapjacks.Value);

        }

        private void nextLumberjackButton_Click(object sender, EventArgs e)//aktualny klient zjada, nastepny klient wchodzi
        {
            if (breakfastLine.Count == 0)
                MessageBox.Show("There are no clients here!");
            Lumberjack nextLumberjack = breakfastLine.Dequeue();
            nextLumberjack.EatFlapjacks();
            //breakfastLine.Dequeue().EatFlapjacks();            
            RedrawList();
        }
        public void RedrawList()
        {
            infoBox.Clear();
            if(breakfastLine.Count==0)
            {
                groupBox1.Enabled = false;
            }
            else
                groupBox1.Enabled = true;

            laneList.Items.Clear();

            int number = 1;
            foreach (Lumberjack client in breakfastLine)
            {                
                laneList.Items.Add(number +". "+ client.Name);
                number++;
            }
        }

    }
}
