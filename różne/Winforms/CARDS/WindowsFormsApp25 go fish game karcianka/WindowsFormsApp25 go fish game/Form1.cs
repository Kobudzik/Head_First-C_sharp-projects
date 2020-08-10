using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp25_go_fish_game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Game game;

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textName.Text))//sprawdzanie czy podano imie
            {
                MessageBox.Show("Please enter your name", "Can't start the game yet");
                return;
            }

            game = new Game(textName.Text, new List<string> { "Joe", "Bob" }, textProgress);
            buttonStart.Enabled = false;
            textName.Enabled = false;
            buttonAsk.Enabled = true;
            UpdateForm();
        }

        private void UpdateForm()//clears and repopulates the ListBox that holds the player’s hand, and then updates the text boxes
        {
            listHand.Items.Clear();//usuwa wszystkie karty gracza

            foreach (String cardName in game.GetPlayerCardNames())
                listHand.Items.Add(cardName);//dodaje wszystkie karty gracza

            textBooks.Text = game.DescribeBooks();
            textProgress.Text += game.DescribePlayerHands();
            textProgress.SelectionStart = textProgress.Text.Length;
            textProgress.ScrollToCaret();
        }

        private void buttonAsk_Click(object sender, EventArgs e)
        {
            textProgress.Text = "";//wyczyszcza proggres text

            if (listHand.SelectedIndex < 0)//jesli gracz nie wybral karty
            {
                MessageBox.Show("Please select a card");
                return;
            }
            if (game.PlayOneRound(listHand.SelectedIndex))//jesli koniec gry
            {
                textProgress.Text += "The winner is... " + game.GetWinnerName();
                textBooks.Text = game.DescribeBooks();
                buttonAsk.Enabled = false;
            }

            else
                UpdateForm();
        }
    }
}