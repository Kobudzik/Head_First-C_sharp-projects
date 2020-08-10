using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp12__typing_game
{
    public partial class Form1 : Form        
    {
        Random losowe = new Random();
        Stats statystyki = new Stats();

        public Form1()
        {
            InitializeComponent();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            // Add a random key to the ListBox via timer
            listBox1.Items.Add( (Keys)losowe.Next(65, 90)   );
          
            if (listBox1.Items.Count > 6)
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("Game over");
                timer1.Stop();
            } 
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // If the user pressed a key that's in the ListBox, remove it    // and then make the game a little faster
            //keycode to litera
            if (listBox1.Items.Contains(e.KeyCode))
            {
                listBox1.Items.Remove(e.KeyCode);
                listBox1.Refresh();

                //zwiekszanie poziomu trudnosci
                if (timer1.Interval > 400)
                    timer1.Interval -= 10;
                if (timer1.Interval > 250)
                    timer1.Interval -= 7;
                if (timer1.Interval > 100)
                    timer1.Interval -= 2;
                difficultyProgressBar.Value = 800 - timer1.Interval;

                // The user pressed a correct key, so update the Stats object 
                // by calling its Update() method with the argument true
                statystyki.Update(true);
            }
            else
            {   // The user pressed an incorrect key, so update the Stats object
                // by calling its Update() method with the argument false
                statystyki.Update(false);
            }



            // Update the labels on the StatusStrip 
            correctLabel.Text = "Correct: " + statystyki.Correct;
            missedLabel.Text = "Missed: " + statystyki.Missed;
            totalLabel.Text = "Total: " + statystyki.Total;
            accuracyLabel.Text = "Accuracy: " + statystyki.Accuracy + "%"; }
            
        }
}
