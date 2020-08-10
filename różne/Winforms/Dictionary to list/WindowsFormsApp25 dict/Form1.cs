using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp25_dict
{
    public partial class Form1 : Form
    {
        Dictionary<int, JerseyPlayer> retiredPlayersDictionary = new Dictionary<int, JerseyPlayer>() 
        {
            { 3, new JerseyPlayer("Babe Ruth", 1948) },
            { 4, new JerseyPlayer("Lou Gehrig", 1939) },
            { 5, new JerseyPlayer("Joe DiMaggio", 1952) },
            { 7, new JerseyPlayer("Mickey Mantle", 1969) }, 
            { 8, new JerseyPlayer("Yogi Berra", 1972) },
            { 10, new JerseyPlayer("Phil Rizzuto", 1985) },
            { 23, new JerseyPlayer("Don Mattingly", 1997) },
            { 42, new JerseyPlayer("Jackie Robinson", 1993) }, 
            { 44, new JerseyPlayer("Reggie Jackson", 1993) },
        };

        public Form1()
        {
            InitializeComponent();

            foreach (int key in retiredPlayersDictionary.Keys)
            { 
                number.Items.Add(key);
            }
        }



        private void number_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            JerseyPlayer jerseyNumber = retiredPlayersDictionary[(int)number.SelectedItem];
            nameLabel.Text = jerseyNumber.FullName;
            yearLabel.Text = jerseyNumber.YearRetired.ToString();
        }
    }
}
